using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic; // Added for List<JobPosting>

namespace ResumeApp.Controllers
{
    public class ResumeController : Controller
    {
        private readonly IResumeService _resumeService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IAIService _aiService;
        private readonly IMatchingService _matchingService;

        public ResumeController(
            IResumeService resumeService,
            IWebHostEnvironment webHostEnvironment,
            IAIService aiService,
            IMatchingService matchingService)
        {
            _resumeService = resumeService;
            _webHostEnvironment = webHostEnvironment;
            _aiService = aiService;
            _matchingService = matchingService;
        }

        public IActionResult Index()
        {
            // Şimdilik UserId'yi 1 olarak alıyoruz, daha sonra login sisteminden alınacak
            var userId = 1;
            var resumes = _resumeService.TGetList()
                .Where(r => r.UserId == userId)
                .OrderByDescending(r => r.CreatedDate)
                .ToList();

            return View(resumes);
        }

        public IActionResult Upload()
        {
            return View(new Resume());
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile pdfFile)
        {
            if (pdfFile == null || pdfFile.Length == 0)
            {
                ModelState.AddModelError("", "Lütfen bir PDF dosyası seçin.");
                return View(new Resume());
            }

            if (pdfFile.ContentType != "application/pdf")
            {
                ModelState.AddModelError("", "Sadece PDF dosyaları kabul edilmektedir.");
                return View(new Resume());
            }

            try
            {
                // Uploads klasörünü oluştur
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // PDF'i kaydet
                var fileName = $"{Guid.NewGuid()}.pdf";
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await pdfFile.CopyToAsync(stream);
                }

                // Resume nesnesini oluştur
                var resume = new Resume
                {
                    Title = Path.GetFileNameWithoutExtension(pdfFile.FileName),
                    FilePath = fileName,
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    UserId = 1, // Şimdilik sabit
                    Skills = "", // Boş string olarak başlat
                    Experience = "0", // Default değer
                    Education = "", // Boş string olarak başlat
                    ParsedContent = "", // Boş string olarak başlat
                    Description = "CV yüklendi, henüz analiz edilmedi." // Default açıklama
                };

                // Eğer başka CV yoksa, bunu ana CV yap
                var userHasResumes = _resumeService.TGetList().Any(r => r.UserId == resume.UserId);
                resume.IsMainResume = !userHasResumes;

                // PDF içeriğini parse et
                try
                {
                    resume.ParsedContent = await _aiService.ParsePdfContent(filePath);
                }
                catch (Exception ex)
                {
                    // AI servisi hatası olsa bile CV'yi kaydet
                    resume.ParsedContent = "PDF içeriği analiz edilemedi: " + ex.Message;
                }

                // Veritabanına kaydet
                try
                {
                    var savedResume = await _resumeService.AddAsync(resume);
                    if (savedResume == null)
                    {
                        throw new Exception("CV veritabanına kaydedilemedi.");
                    }
                }
                catch (Exception ex)
                {
                    // Dosyayı sil
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }

                    var message = ex.InnerException != null 
                        ? ex.InnerException.Message 
                        : ex.Message;
                    
                    ModelState.AddModelError("", $"Veritabanı hatası: {message}");
                    return View(new Resume());
                }

                // Eşleşen işleri bul
                try
                {
                    var matchingJobs = await _matchingService.FindMatchingJobs(resume.ParsedContent);
                    TempData["MatchingJobs"] = JsonSerializer.Serialize(matchingJobs);
                }
                catch (Exception ex)
                {
                    // Eşleştirme hatası olsa bile devam et
                    TempData["WarningMessage"] = "İş eşleştirmesi yapılamadı: " + ex.Message;
                }

                TempData["SuccessMessage"] = "CV'niz başarıyla yüklendi.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                var message = ex.InnerException != null 
                    ? ex.InnerException.Message 
                    : ex.Message;
                
                ModelState.AddModelError("", $"CV yüklenirken bir hata oluştu: {message}");
                return View(new Resume());
            }
        }

        public IActionResult MatchResults()
        {
            var matchingJobsJson = TempData["MatchingJobs"] as string;
            if (string.IsNullOrEmpty(matchingJobsJson))
            {
                return RedirectToAction("Index");
            }

            var matchingJobs = JsonSerializer.Deserialize<List<JobPosting>>(matchingJobsJson);
            return View(matchingJobs);
        }

        public async Task<IActionResult> SetMainResume(int id)
        {
            var userId = 1; // Şimdilik sabit
            var resume = await _resumeService.GetByIdAsync(id);

            if (resume == null || resume.UserId != userId)
            {
                return NotFound();
            }

            // Diğer CV'lerin main özelliğini kaldır
            var userResumes = (await _resumeService.GetListAsync())
                .Where(r => r.UserId == userId && r.IsMainResume)
                .ToList();

            foreach (var r in userResumes)
            {
                r.IsMainResume = false;
                await _resumeService.UpdateAsync(r);
            }

            // Seçilen CV'yi main yap
            resume.IsMainResume = true;
            await _resumeService.UpdateAsync(resume);

            TempData["SuccessMessage"] = "Ana CV'niz başarıyla güncellendi.";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var userId = 1; // Şimdilik sabit
            var resume = _resumeService.TGetById(id);

            if (resume == null || resume.UserId != userId)
            {
                return NotFound();
            }

            // Dosyayı sil
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", resume.FilePath);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            _resumeService.TDelete(resume);

            TempData["SuccessMessage"] = "CV başarıyla silindi.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetUserCVs()
        {
            // Şimdilik sabit kullanıcı ID'si
            var userId = 1;
            var resumes = _resumeService.TGetList()
                .Where(r => r.UserId == userId)
                .OrderByDescending(r => r.CreatedDate)
                .Select(r => new
                {
                    r.Id,
                    r.Title,
                    r.Description,
                    r.Skills,
                    r.CreatedDate,
                    r.IsMainResume
                })
                .ToList();

            return Json(resumes);
        }
    }
}

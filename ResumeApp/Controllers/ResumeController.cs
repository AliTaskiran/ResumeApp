using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

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

        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(Resume resume, IFormFile pdfFile)
        {
            if (pdfFile == null || pdfFile.Length == 0)
                return BadRequest("Dosya yüklenmedi.");

            if (pdfFile.ContentType != "application/pdf")
                return BadRequest("Sadece PDF dosyaları kabul edilmektedir.");

            try
            {
                // PDF'i kaydet
                var fileName = $"{Guid.NewGuid()}.pdf";
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await pdfFile.CopyToAsync(stream);
                }

                // Resume nesnesini hazırla
                resume.FilePath = fileName;
                resume.CreatedDate = DateTime.Now;
                resume.IsActive = true;

                // PDF içeriğini parse et (yapay zeka servisi ile)
                resume.ParsedContent = await _aiService.ParsePdfContent(filePath);

                // Veritabanına kaydet
                await _resumeService.AddAsync(resume);

                // Eşleşen işleri bul
                var matchingJobs = await _matchingService.FindMatchingJobs(resume.ParsedContent);

                // Sonuçları TempData'ya aktar
                TempData["MatchingJobs"] = JsonSerializer.Serialize(matchingJobs);

                return RedirectToAction("MatchResults");
            }
            catch (Exception ex)
            {
                // Loglama yap
                return View(resume);
            }
        }
    }
}

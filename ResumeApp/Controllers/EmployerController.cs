using BusinessLayer.Abstract;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.IO;
using System.Linq;

namespace ResumeApp.Controllers
{
    [Authorize(Roles = "Employer")]
    public class EmployerController : Controller
    {
        private readonly IJobApplicationService _jobApplicationService;
        private readonly IJobPostingService _jobPostingService;
        private readonly IResumeService _resumeService;
        private readonly IUserService _userService;

        public EmployerController(
            IJobApplicationService jobApplicationService,
            IJobPostingService jobPostingService,
            IResumeService resumeService,
            IUserService userService)
        {
            _jobApplicationService = jobApplicationService;
            _jobPostingService = jobPostingService;
            _resumeService = resumeService;
            _userService = userService;
        }

        public IActionResult Dashboard()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var companyName = User.FindFirstValue("CompanyName");
            
            ViewBag.CompanyName = companyName;
            ViewBag.UserName = User.FindFirstValue(ClaimTypes.Name);
            
            return View();
        }

        public IActionResult Applications()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            
            // Bu işverene ait iş ilanlarını al
            var employerJobPostings = _jobPostingService.TGetList()
                .Where(jp => jp.CompanyName == User.FindFirstValue("CompanyName"))
                .ToList();

            // Bu iş ilanlarına yapılan başvuruları al
            var applications = new List<object>();
            
            foreach (var jobPosting in employerJobPostings)
            {
                var jobApplications = _jobApplicationService.TGetList()
                    .Where(ja => ja.JobPostingId == jobPosting.Id)
                    .ToList();

                foreach (var application in jobApplications)
                {
                    var resume = _resumeService.TGetById(application.ResumeId);
                    var candidate = _userService.TGetById(application.UserId);

                    applications.Add(new
                    {
                        ApplicationId = application.Id,
                        JobTitle = jobPosting.Title,
                        CandidateName = $"{candidate.FirstName} {candidate.LastName}",
                        CandidateEmail = candidate.Email,
                        ResumeId = resume?.Id ?? 0,
                        ResumeFileName = (!string.IsNullOrEmpty(resume?.FileName) ? resume.FileName : resume?.FilePath) ?? "CV Bulunamadı",
                        ApplicationDate = application.CreatedDate,
                        Status = GetStatusText(application.Status),
                        StatusNumber = application.Status
                    });
                }
            }

            ViewBag.Applications = applications;
            return View();
        }

        public IActionResult JobPostings()
        {
            var companyName = User.FindFirstValue("CompanyName");
            
            var jobPostings = _jobPostingService.TGetList()
                .Where(jp => jp.CompanyName == companyName)
                .ToList();

            return View(jobPostings);
        }

        [HttpGet]
        public IActionResult CreateJobPosting()
        {
            return View(new JobPosting());
        }

        [HttpPost]
        public IActionResult CreateJobPosting(JobPosting jobPosting)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var companyName = User.FindFirstValue("CompanyName");

            // CompanyName kontrol et
            if (string.IsNullOrEmpty(companyName))
            {
                // Kullanıcının profilinden CompanyName'i al
                var user = _userService.TGetById(userId);
                companyName = user?.CompanyName;
                
                if (string.IsNullOrEmpty(companyName))
                {
                    ModelState.AddModelError("", "Şirket adı bulunamadı. Lütfen profil bilgilerinizi güncelleyiniz.");
                    return View(jobPosting);
                }
            }

            // CompanyName'i set et ve ModelState'den hatayı temizle
            jobPosting.CompanyName = companyName;
            ModelState.Remove("CompanyName");

            if (ModelState.IsValid)
            {
                jobPosting.UserId = userId;
                jobPosting.CreatedDate = DateTime.Now;
                jobPosting.IsActive = true;
                jobPosting.IsFilled = false;

                _jobPostingService.TAdd(jobPosting);

                TempData["SuccessMessage"] = "İş ilanı başarıyla oluşturuldu.";
                return RedirectToAction("JobPostings");
            }

            return View(jobPosting);
        }

        [HttpPost]
        public IActionResult DeleteJobPosting(int id)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var jobPosting = _jobPostingService.TGetById(id);

            if (jobPosting != null && jobPosting.UserId == userId)
            {
                _jobPostingService.TDelete(jobPosting);
                TempData["SuccessMessage"] = "İş ilanı başarıyla silindi.";
            }
            else
            {
                TempData["ErrorMessage"] = "İş ilanı bulunamadı veya size ait değil.";
            }

            return RedirectToAction("JobPostings");
        }

        [HttpPost]
        public IActionResult UpdateApplicationStatus(int applicationId, int status)
        {
            var application = _jobApplicationService.TGetById(applicationId);
            if (application != null)
            {
                application.Status = status;
                _jobApplicationService.TUpdate(application);
                
                TempData["SuccessMessage"] = "Başvuru durumu güncellendi.";
            }
            else
            {
                TempData["ErrorMessage"] = "Başvuru bulunamadı.";
            }

            return RedirectToAction("Applications");
        }

        private string GetStatusText(int status)
        {
            return status switch
            {
                0 => "Beklemede",
                1 => "İnceleniyor",
                2 => "Kabul Edildi",
                3 => "Reddedildi",
                _ => "Bilinmiyor"
            };
        }

        public IActionResult ViewResume(int resumeId)
        {
            try
            {
                var resume = _resumeService.TGetById(resumeId);
                if (resume == null)
                {
                    TempData["ErrorMessage"] = "CV bulunamadı.";
                    return RedirectToAction("Applications");
                }

                // Güvenlik kontrolü: Bu CV'nin sahibi bu işverenin iş ilanına başvurmuş mu?
                var companyName = User.FindFirstValue("CompanyName");
                var hasApplication = _jobApplicationService.TGetList()
                    .Any(ja => ja.ResumeId == resumeId && 
                           _jobPostingService.TGetById(ja.JobPostingId).CompanyName == companyName);

                if (!hasApplication)
                {
                    TempData["ErrorMessage"] = "Bu CV'ye erişim yetkiniz yok.";
                    return RedirectToAction("Applications");
                }

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", resume.FilePath);
                
                if (!System.IO.File.Exists(filePath))
                {
                    TempData["ErrorMessage"] = "CV dosyası bulunamadı.";
                    return RedirectToAction("Applications");
                }

                var fileBytes = System.IO.File.ReadAllBytes(filePath);
                var downloadFileName = (!string.IsNullOrEmpty(resume.FileName) ? resume.FileName : resume.FilePath);
                
                // PDF dosyasını tarayıcıda göster
                return File(fileBytes, "application/pdf", downloadFileName);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "CV görüntülenirken bir hata oluştu: " + ex.Message;
                return RedirectToAction("Applications");
            }
        }
    }
} 
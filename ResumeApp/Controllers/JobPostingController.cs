using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Security.Claims;
using EntityLayer;

namespace ResumeApp.Controllers
{
    [Authorize]
    public class JobPostingController : Controller
    {
        private readonly IJobPostingService _jobPostingService;
        private readonly IResumeService _resumeService;
        private readonly IJobApplicationService _jobApplicationService;

        public JobPostingController(IJobPostingService jobPostingService, IResumeService resumeService, IJobApplicationService jobApplicationService)
        {
            _jobPostingService = jobPostingService;
            _resumeService = resumeService;
            _jobApplicationService = jobApplicationService;
        }

        public IActionResult Index()
        {
            var jobs = _jobPostingService.TGetList()
                .Where(j => j.IsActive && !j.IsFilled)
                .OrderByDescending(j => j.CreatedDate)
                .ToList();

            return View(jobs);
        }

        public IActionResult Details(int id)
        {
            var job = _jobPostingService.TGetById(id);
            if (job == null || !job.IsActive || job.IsFilled)
            {
                return NotFound();
            }

            return View(job);
        }

        [HttpPost]
        [Authorize(Roles = "Candidate")]
        public IActionResult Apply(int jobId)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
            if (userId == 0)
            {
                return RedirectToAction("Index", "Login");
            }

            // İş ilanını kontrol et
            var job = _jobPostingService.TGetById(jobId);
            if (job == null || !job.IsActive || job.IsFilled)
            {
                TempData["ErrorMessage"] = "Bu iş ilanı artık aktif değil.";
                return RedirectToAction("Index");
            }

            // Kullanıcının CV'lerini kontrol et
            var userResumes = _resumeService.TGetList()
                .Where(r => r.UserId == userId && !string.IsNullOrEmpty(r.FilePath))
                .ToList();

            if (!userResumes.Any())
            {
                // CV yok, yükleme sayfasına yönlendir
                TempData["InfoMessage"] = "Başvuru yapmak için önce CV yüklemelisiniz.";
                return RedirectToAction("Upload", "Resume", new { returnUrl = Url.Action("Details", "JobPosting", new { id = jobId }) });
            }

            // Ana CV'yi bul veya ilk CV'yi kullan
            var mainResume = userResumes.FirstOrDefault(r => r.IsMainResume) ?? userResumes.First();

            // Daha önce başvuru yapılmış mı kontrol et
            var existingApplication = _jobApplicationService.TGetList()
                .Any(ja => ja.JobPostingId == jobId && ja.UserId == userId);

            if (existingApplication)
            {
                TempData["WarningMessage"] = "Bu iş ilanına zaten başvuru yapmışsınız.";
                return RedirectToAction("Details", new { id = jobId });
            }

            // Başvuru oluştur
            var application = new JobApplication
            {
                JobPostingId = jobId,
                UserId = userId,
                ResumeId = mainResume.Id,
                CoverLetter = "", // Boş cover letter
                CreatedDate = DateTime.Now,
                Status = 0, // Pending
                IsActive = true
            };

            _jobApplicationService.TAdd(application);

            TempData["SuccessMessage"] = "Başvurunuz başarıyla gönderildi!";
            return RedirectToAction("Details", new { id = jobId });
        }

        [HttpGet]
        [Authorize(Roles = "Candidate")]
        public IActionResult CheckApplyStatus(int jobId)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
            if (userId == 0)
            {
                return Json(new { hasCV = false, hasApplied = false });
            }

            // CV kontrolü
            var hasCV = _resumeService.TGetList()
                .Any(r => r.UserId == userId && !string.IsNullOrEmpty(r.FilePath));

            // Başvuru kontrolü
            var hasApplied = _jobApplicationService.TGetList()
                .Any(ja => ja.JobPostingId == jobId && ja.UserId == userId);

            return Json(new { hasCV = hasCV, hasApplied = hasApplied });
        }
    }
} 
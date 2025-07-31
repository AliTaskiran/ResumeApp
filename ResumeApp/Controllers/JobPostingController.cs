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

        public IActionResult Index(string analysis = null, string keywords = null, int? cvId = null)
        {
            var jobs = _jobPostingService.TGetList()
                .Where(j => j.IsActive && !j.IsFilled)
                .OrderByDescending(j => j.CreatedDate)
                .ToList();

            // Debug: Log the incoming parameters
            System.Diagnostics.Debug.WriteLine($"=== JOB FILTERING DEBUG ===");
            System.Diagnostics.Debug.WriteLine($"Analysis: {analysis}");
            System.Diagnostics.Debug.WriteLine($"Keywords: {keywords}");
            System.Diagnostics.Debug.WriteLine($"Total jobs before filtering: {jobs.Count}");

            // If analysis data is provided, filter jobs based on keywords
            if (!string.IsNullOrEmpty(analysis) && !string.IsNullOrEmpty(keywords))
            {
                // Decode URL-encoded parameters
                var decodedAnalysis = System.Web.HttpUtility.UrlDecode(analysis);
                var decodedKeywords = System.Web.HttpUtility.UrlDecode(keywords);
                
                var keywordList = decodedKeywords.Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(k => k.Trim().ToLower())
                    .ToList();

                System.Diagnostics.Debug.WriteLine($"Decoded Analysis: {decodedAnalysis}");
                System.Diagnostics.Debug.WriteLine($"Decoded Keywords: {decodedKeywords}");
                System.Diagnostics.Debug.WriteLine($"Keywords to search: {string.Join(", ", keywordList)}");

                // Filter jobs based on keywords with smarter matching
                var filteredJobs = new List<JobPosting>();
                
                foreach (var job in jobs)
                {
                    var jobText = $"{job.Title} {job.Description} {job.RequiredSkills} {job.CompanyName}".ToLower();
                    var matchedKeywords = new List<string>();
                    
                    // Smart keyword matching with context awareness
                    foreach (var keyword in keywordList)
                    {
                        var lowerKeyword = keyword.ToLower();
                        
                        // Direct matches
                        if (jobText.Contains(lowerKeyword))
                        {
                            matchedKeywords.Add(keyword);
                            continue;
                        }
                        
                        // Context-aware related term matching
                        if (lowerKeyword.Contains("satış") || lowerKeyword.Contains("sales"))
                        {
                            if (jobText.Contains("sales") || jobText.Contains("pazarlama") || jobText.Contains("marketing") || 
                                jobText.Contains("b2b") || jobText.Contains("müşteri") || jobText.Contains("customer"))
                            {
                                matchedKeywords.Add(keyword);
                            }
                        }
                        else if (lowerKeyword.Contains("sağlık") || lowerKeyword.Contains("health"))
                        {
                            if (jobText.Contains("health") || jobText.Contains("medical") || jobText.Contains("hospital") || 
                                jobText.Contains("healthcare") || jobText.Contains("tedavi") || jobText.Contains("treatment"))
                            {
                                matchedKeywords.Add(keyword);
                            }
                        }
                        else if (lowerKeyword.Contains("turizm") || lowerKeyword.Contains("tourism"))
                        {
                            if (jobText.Contains("tourism") || jobText.Contains("travel") || jobText.Contains("hospitality") || 
                                jobText.Contains("otel") || jobText.Contains("hotel") || jobText.Contains("seyahat"))
                            {
                                matchedKeywords.Add(keyword);
                            }
                        }
                        else if (lowerKeyword == "it" && !jobText.Contains("it") && !jobText.Contains("information technology"))
                        {
                            // Skip "it" keyword if it's not explicitly about IT/technology
                            continue;
                        }
                        else if (lowerKeyword.Contains("hr") || lowerKeyword.Contains("human"))
                        {
                            if (jobText.Contains("human") || jobText.Contains("resources") || jobText.Contains("personnel") || 
                                jobText.Contains("recruitment") || jobText.Contains("employee"))
                            {
                                matchedKeywords.Add(keyword);
                            }
                        }
                        else if (lowerKeyword.Contains("yazılım") || lowerKeyword.Contains("software") || lowerKeyword.Contains("developer"))
                        {
                            if (jobText.Contains("software") || jobText.Contains("developer") || jobText.Contains("programming") || 
                                jobText.Contains("coding") || jobText.Contains("development"))
                            {
                                matchedKeywords.Add(keyword);
                            }
                        }
                    }
                    
                    if (matchedKeywords.Any())
                    {
                        filteredJobs.Add(job);
                        System.Diagnostics.Debug.WriteLine($"Job '{job.Title}' matched keywords: {string.Join(", ", matchedKeywords)}");
                    }
                }

                System.Diagnostics.Debug.WriteLine($"Filtered jobs count: {filteredJobs.Count}");

                // If filtered jobs are found, use them; otherwise use all jobs
                if (filteredJobs.Any())
                {
                    jobs = filteredJobs;
                    System.Diagnostics.Debug.WriteLine("Using filtered jobs");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("No matches found, using all jobs");
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("No analysis or keywords provided");
            }

            // Pass analysis data to view
            ViewBag.Analysis = !string.IsNullOrEmpty(analysis) ? System.Web.HttpUtility.UrlDecode(analysis) : analysis;
            ViewBag.Keywords = !string.IsNullOrEmpty(keywords) ? System.Web.HttpUtility.UrlDecode(keywords) : keywords;
            ViewBag.CvId = cvId;
            ViewBag.IsFiltered = !string.IsNullOrEmpty(analysis);

            System.Diagnostics.Debug.WriteLine($"Final jobs count: {jobs.Count}");
            System.Diagnostics.Debug.WriteLine($"IsFiltered: {ViewBag.IsFiltered}");
            System.Diagnostics.Debug.WriteLine($"=== END DEBUG ===");

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
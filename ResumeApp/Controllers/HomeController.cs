using System.Text.Json;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace ResumeApp.Controllers
{
    [Authorize(Roles = "Candidate")]
    public class HomeController : Controller
    {
        private readonly IChatMessageService _chatMessageService;
        private readonly IResumeService _resumeService;
        private readonly IChatbotService _chatbotService;
        private readonly IAIService _aiService;
        private readonly IMatchingService _matchingService;
        private readonly IJobApplicationService _jobApplicationService;
        private readonly IJobPostingService _jobPostingService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(
            IChatMessageService chatMessageService,
            IResumeService resumeService,
            IChatbotService chatbotService,
            IAIService aiService,
            IMatchingService matchingService,
            IJobApplicationService jobApplicationService,
            IJobPostingService jobPostingService,
            ILogger<HomeController> logger)
        {
            _chatMessageService = chatMessageService;
            _resumeService = resumeService;
            _chatbotService = chatbotService;
            _aiService = aiService;
            _matchingService = matchingService;
            _jobApplicationService = jobApplicationService;
            _jobPostingService = jobPostingService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Index sayfası çağrıldı");
            
            // Kullanıcının başvuru durumlarını getir
            var userId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "0");
            if (userId > 0)
            {
                var userApplications = _jobApplicationService.TGetList()
                    .Where(ja => ja.UserId == userId)
                    .OrderByDescending(ja => ja.CreatedDate)
                    .Take(5) // Son 5 başvuru
                    .Select(ja => new
                    {
                        ApplicationId = ja.Id,
                        JobTitle = _jobPostingService.TGetById(ja.JobPostingId)?.Title ?? "İş İlanı Bulunamadı",
                        CompanyName = _jobPostingService.TGetById(ja.JobPostingId)?.CompanyName ?? "Şirket Bulunamadı",
                        ApplicationDate = ja.CreatedDate,
                        Status = ja.Status,
                        StatusText = GetStatusText(ja.Status)
                    })
                    .Cast<object>()
                    .ToList();

                ViewBag.UserApplications = userApplications;
            }
            
            return View();
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

        public IActionResult MyApplications()
        {
            var userId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "0");
            if (userId == 0)
            {
                return RedirectToAction("Index", "Login");
            }

            var userApplications = _jobApplicationService.TGetList()
                .Where(ja => ja.UserId == userId)
                .OrderByDescending(ja => ja.CreatedDate)
                .Select(ja => new
                {
                    ApplicationId = ja.Id,
                    JobTitle = _jobPostingService.TGetById(ja.JobPostingId)?.Title ?? "İş İlanı Bulunamadı",
                    CompanyName = _jobPostingService.TGetById(ja.JobPostingId)?.CompanyName ?? "Şirket Bulunamadı",
                    ApplicationDate = ja.CreatedDate,
                    Status = ja.Status,
                    StatusText = GetStatusText(ja.Status),
                    JobPosting = _jobPostingService.TGetById(ja.JobPostingId)
                })
                .Cast<object>()
                .ToList();

            return View(userApplications);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendMessage([FromBody] ChatMessageRequest request)
        {
            _logger.LogInformation("SendMessage çağrıldı: {Message}", request?.Content);

            try
            {
                if (request == null)
                {
                    _logger.LogWarning("Request null geldi");
                    return BadRequest(new { success = false, error = "Request null olamaz." });
                }

                if (string.IsNullOrEmpty(request.Content))
                {
                    _logger.LogWarning("Boş mesaj gönderildi");
                    return BadRequest(new { success = false, error = "Mesaj boş olamaz." });
                }

                // Giriş yapan kullanıcının ID'sini al
                var userId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "0");
                if (userId == 0)
                {
                    return Json(new { success = false, error = "Kullanıcı kimliği bulunamadı. Lütfen tekrar giriş yapın." });
                }

                _logger.LogInformation("Kullanıcı mesajı kaydediliyor: {Content}", request.Content);
                
                // Kullanıcı mesajını kaydet
                var userMessage = new ChatMessage
                {
                    Content = request.Content,
                    IsFromBot = false,
                    CreatedDate = DateTime.Now,
                    UserId = userId
                };
                
                var savedUserMessage = await _chatMessageService.AddAsync(userMessage);
                _logger.LogInformation("Kullanıcı mesajı kaydedildi. ID: {Id}", savedUserMessage?.Id);

                _logger.LogInformation("Chatbot'tan yanıt alınıyor...");
                // Chatbot'tan yanıt al
                var response = await _chatbotService.GetResponseAsync(request.Content, userId);
                _logger.LogInformation("Chatbot yanıtı alındı. Uzunluk: {Length}", response?.Length ?? 0);

                // Bot yanıtını kaydet
                var botMessage = new ChatMessage
                {
                    Content = response,
                    IsFromBot = true,
                    CreatedDate = DateTime.Now,
                    UserId = userId
                };
                
                var savedBotMessage = await _chatMessageService.AddAsync(botMessage);
                _logger.LogInformation("Bot mesajı kaydedildi. ID: {Id}", savedBotMessage?.Id);

                return Json(new { success = true, response = botMessage.Content });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Mesaj gönderme sırasında hata: {Message}", ex.Message);
                return Json(new { success = false, error = "Bir hata oluştu: " + ex.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AnalyzeCV([FromBody] AnalyzeCVRequest request)
        {
            _logger.LogInformation("AnalyzeCV çağrıldı: CV ID {CvId}", request?.CvId);

            try
            {
                if (request == null)
                {
                    _logger.LogWarning("AnalyzeCV request null geldi");
                    return BadRequest(new { success = false, error = "Request null olamaz." });
                }

                if (request.CvId <= 0)
                {
                    _logger.LogWarning("Geçersiz CV ID: {CvId}", request.CvId);
                    return BadRequest(new { success = false, error = "Geçersiz CV ID." });
                }

                var resume = await _resumeService.GetByIdAsync(request.CvId);
                if (resume == null)
                {
                    _logger.LogWarning("CV bulunamadı: {CvId}", request.CvId);
                    return BadRequest(new { success = false, error = "CV bulunamadı." });
                }

                _logger.LogInformation("CV bulundu: {Title}", resume.Title);

                // CV içeriğini analiz et
                var message = $"CV ID {request.CvId} için analiz:\n\n" +
                            $"Başlık: {resume.Title}\n" +
                            $"Yetenekler: {resume.Skills}\n" +
                            $"Deneyim: {resume.Experience}\n" +
                            $"Eğitim: {resume.Education}\n" +
                            $"İçerik: {resume.ParsedContent}";

                // Giriş yapan kullanıcının ID'sini al (AnalyzeCV için de)
                var userId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "0");
                
                _logger.LogInformation("Chatbot'tan CV analizi isteniyor");
                var analysis = await _chatbotService.GetResponseAsync(message, userId);
                _logger.LogInformation("Chatbot CV analizi yanıtı alındı. Uzunluk: {Length}", analysis?.Length ?? 0);

                // Analiz sonucunu Session'a kaydet
                HttpContext.Session.SetString("LastAnalysis", analysis ?? "Analiz sonucu alınamadı");

                // İş ilanlarını al
                var matchingJobs = new List<object>();
                if (!string.IsNullOrEmpty(resume.ParsedContent))
                {
                    try
                    {
                        var jobs = await _matchingService.FindMatchingJobs(resume.ParsedContent);
                        matchingJobs = jobs.Take(6).Select(job => (object)new
                        {
                            title = job.Title,
                            company = job.CompanyName,
                            location = job.Location,
                            description = job.Description.Length > 100 ? job.Description.Substring(0, 100) + "..." : job.Description,
                            salary = $"{job.SalaryMin:N0} - {job.SalaryMax:N0} TL",
                            skills = job.RequiredSkills,
                            url = $"/JobPosting/Details/{job.Id}"
                        }).ToList();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "İş eşleştirme sırasında hata");
                    }
                }

                return Json(new { 
                    success = true, 
                    response = analysis,
                    jobRecommendations = matchingJobs
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CV analizi sırasında hata: {Message}", ex.Message);
                return Json(new { success = false, error = "Bir hata oluştu: " + ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> SaveAnalysisToChat()
        {
            try
            {
                // Session'dan analiz sonucunu al
                var analysisResult = HttpContext.Session.GetString("LastAnalysis");
                if (string.IsNullOrEmpty(analysisResult))
                {
                    return Json(new { success = false, error = "Analiz sonucu bulunamadı." });
                }

                // Giriş yapan kullanıcının ID'sini al
                var userId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "0");
                if (userId == 0)
                {
                    return Json(new { success = false, error = "Kullanıcı kimliği bulunamadı. Lütfen tekrar giriş yapın." });
                }

                // Kullanıcı mesajını kaydet
                var userMessage = new ChatMessage
                {
                    Content = "CV Analizi Talebi",
                    IsFromBot = false,
                    CreatedDate = DateTime.Now,
                    UserId = userId
                };
                
                await _chatMessageService.AddAsync(userMessage);

                // Bot yanıtını kaydet
                var botMessage = new ChatMessage
                {
                    Content = analysisResult,
                    IsFromBot = true,
                    CreatedDate = DateTime.Now,
                    UserId = userId
                };
                
                await _chatMessageService.AddAsync(botMessage);

                // Session'dan temizle
                HttpContext.Session.Remove("LastAnalysis");

                return Json(new { success = true, response = analysisResult });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Analiz sohbete kaydedilirken hata: {Message}", ex.Message);
                return Json(new { success = false, error = "Bir hata oluştu: " + ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetChatMessages()
        {
            try
            {
                var userId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "0");
                if (userId == 0)
                {
                    return Json(new { success = true, messages = new List<object>() });
                }

                var messages = _chatMessageService.TGetList()
                    .Where(m => m.UserId == userId)
                    .OrderBy(m => m.CreatedDate)
                    .Select(m => new
                    {
                        content = m.Content,
                        isFromBot = m.IsFromBot,
                        createdDate = m.CreatedDate
                    })
                    .ToList();

                return Json(new { success = true, messages = messages });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Mesajlar alınırken hata: {Message}", ex.Message);
                return Json(new { success = false, error = "Bir hata oluştu: " + ex.Message });
            }
        }
    }

    public class ChatMessageRequest
    {
        public required string Content { get; set; }
    }

    public class AnalyzeCVRequest
    {
        public int CvId { get; set; }
    }
}
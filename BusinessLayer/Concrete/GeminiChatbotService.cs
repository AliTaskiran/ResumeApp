using BusinessLayer.Abstract;
using EntityLayer;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class GeminiChatbotService : IChatbotService
    {
        private readonly string _apiKey;
        private readonly HttpClient _httpClient;
        private readonly IJobPostingService _jobPostingService;
        private readonly IResumeService _resumeService;
        private const string GEMINI_API_URL = "https://generativelanguage.googleapis.com/v1beta/models/gemini-pro:generateContent";

        private const string SYSTEM_PROMPT = @"Sen bir CV-İş Eşleştirme asistanısın. Görevin:
1. Kullanıcıların CV'lerini analiz etmek
2. Mevcut iş ilanlarıyla eşleştirmek
3. Kullanıcılara kariyer tavsiyeleri vermek
4. CV'lerini geliştirmeleri için önerilerde bulunmak

Şu konularda yardımcı olabilirsin:
- CV analizi ve değerlendirmesi
- İş ilanlarıyla eşleştirme
- Kariyer tavsiyeleri
- CV geliştirme önerileri
- Mülakat tavsiyeleri

Cevaplarını Türkçe, profesyonel ve yardımsever bir tonda ver.";

        public GeminiChatbotService(
            IConfiguration configuration,
            IJobPostingService jobPostingService,
            IResumeService resumeService)
        {
            _apiKey = configuration["Gemini:ApiKey"];
            _httpClient = new HttpClient();
            _jobPostingService = jobPostingService;
            _resumeService = resumeService;
        }

        public async Task<string> GetResponseAsync(string userMessage, string context = "")
        {
            try
            {
                // Aktif iş ilanlarını al
                var activeJobs = await _jobPostingService.GetActiveJobsAsync();
                var jobContext = FormatJobsForContext(activeJobs);

                // Eğer kullanıcının CV'si varsa, onu da ekle
                var userResume = context; // Bu, CV içeriği olacak

                var fullContext = $"{SYSTEM_PROMPT}\n\nMevcut İş İlanları:\n{jobContext}\n\nKullanıcı CV'si:\n{userResume}\n\nKullanıcı Mesajı: {userMessage}";

                var requestBody = new
                {
                    contents = new[]
                    {
                        new
                        {
                            parts = new[]
                            {
                                new
                                {
                                    text = fullContext
                                }
                            }
                        }
                    }
                };

                var json = JsonSerializer.Serialize(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(
                    $"{GEMINI_API_URL}?key={_apiKey}",
                    content
                );

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonSerializer.Deserialize<GeminiResponse>(responseContent);
                    return responseObject?.candidates?[0]?.content?.parts?[0]?.text ?? "Üzgünüm, yanıt üretemiyorum.";
                }

                return "API yanıt vermedi. Lütfen daha sonra tekrar deneyin.";
            }
            catch (Exception ex)
            {
                // Loglama yapılabilir
                return "Bir hata oluştu. Lütfen daha sonra tekrar deneyin.";
            }
        }

        private string FormatJobsForContext(List<JobPosting> jobs)
        {
            if (jobs == null || !jobs.Any())
                return "Şu anda aktif iş ilanı bulunmamaktadır.";

            var sb = new StringBuilder();
            foreach (var job in jobs)
            {
                sb.AppendLine($"İlan Başlığı: {job.Title}");
                sb.AppendLine($"Şirket: {job.CompanyName}");
                sb.AppendLine($"Gerekli Yetenekler: {job.RequiredSkills}");
                sb.AppendLine($"Deneyim: {job.RequiredExperience} yıl");
                sb.AppendLine($"Açıklama: {job.Description}");
                sb.AppendLine("---");
            }

            return sb.ToString();
        }
    }

    // Gemini API response modeli
    public class GeminiResponse
    {
        public Candidate[] candidates { get; set; }
    }

    public class Candidate
    {
        public Content content { get; set; }
    }

    public class Content
    {
        public Part[] parts { get; set; }
    }

    public class Part
    {
        public string text { get; set; }
    }
} 
using BusinessLayer.Abstract;
using EntityLayer;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text.RegularExpressions;

namespace BusinessLayer.Concrete
{
    public class MatchingService : IMatchingService
    {
        private readonly IJobPostingService _jobPostingService;

        public MatchingService(IJobPostingService jobPostingService)
        {
            _jobPostingService = jobPostingService;
        }

        public async Task<List<JobPosting>> FindMatchingJobs(string resumeContent)
        {
            try
            {
                // Tüm aktif iş ilanlarını al
                var allJobs = _jobPostingService.TGetList();
                var activeJobs = allJobs.Where(j => j.IsActive && !j.IsFilled).ToList();

                if (string.IsNullOrEmpty(resumeContent))
                {
                    return activeJobs.Take(5).ToList(); // Boş CV için ilk 5 iş
                }

                var matchingJobs = new List<JobPosting>();
                var resumeContentLower = resumeContent.ToLower();

                foreach (var job in activeJobs)
                {
                    var score = CalculateMatchScore(resumeContentLower, job);
                    if (score > 0.3) // %30'dan fazla eşleşme varsa
                    {
                        matchingJobs.Add(job);
                    }
                }

                // Skora göre sırala ve en iyi 10 tanesini döndür
                return matchingJobs
                    .OrderByDescending(j => CalculateMatchScore(resumeContentLower, j))
                    .Take(10)
                    .ToList();
            }
            catch
            {
                // Hata durumunda boş liste döndür
                return new List<JobPosting>();
            }
        }

        private double CalculateMatchScore(string resumeContent, JobPosting job)
        {
            double score = 0;
            var jobSkills = job.RequiredSkills?.ToLower() ?? "";
            var jobTitle = job.Title?.ToLower() ?? "";
            var jobDescription = job.Description?.ToLower() ?? "";

            // Yetenek eşleştirmesi
            if (!string.IsNullOrEmpty(jobSkills))
            {
                var skills = jobSkills.Split(',', ';', ' ').Where(s => !string.IsNullOrWhiteSpace(s));
                foreach (var skill in skills)
                {
                    var cleanSkill = skill.Trim();
                    if (resumeContent.Contains(cleanSkill))
                    {
                        score += 0.2; // Her yetenek için 0.2 puan
                    }
                }
            }

            // Başlık eşleştirmesi
            var titleKeywords = ExtractKeywords(jobTitle);
            foreach (var keyword in titleKeywords)
            {
                if (resumeContent.Contains(keyword))
                {
                    score += 0.3; // Başlık eşleşmesi için 0.3 puan
                }
            }

            // Açıklama eşleştirmesi
            var descriptionKeywords = ExtractKeywords(jobDescription);
            foreach (var keyword in descriptionKeywords)
            {
                if (resumeContent.Contains(keyword))
                {
                    score += 0.1; // Açıklama eşleşmesi için 0.1 puan
                }
            }

            return Math.Min(score, 1.0); // Maksimum 1.0 puan
        }

        private List<string> ExtractKeywords(string text)
        {
            if (string.IsNullOrEmpty(text))
                return new List<string>();

            // Önemli anahtar kelimeleri çıkar
            var keywords = new List<string>();
            var words = text.Split(' ', ',', '.', ';', ':', '!', '?')
                           .Where(w => !string.IsNullOrWhiteSpace(w))
                           .Select(w => w.ToLower().Trim())
                           .Where(w => w.Length > 2) // 2 karakterden uzun kelimeler
                           .ToList();

            // Tekrar eden kelimeleri kaldır
            return words.Distinct().ToList();
        }

        public async Task<string> GetMatchingJobsSummary(string resumeContent)
        {
            var matchingJobs = await FindMatchingJobs(resumeContent);
            
            if (!matchingJobs.Any())
            {
                return "CV'nizle eşleşen iş ilanı bulunamadı. Daha fazla yetenek ve deneyim ekleyerek CV'nizi geliştirebilirsiniz.";
            }

            var summary = new System.Text.StringBuilder();
            summary.AppendLine($"CV'nizle eşleşen {matchingJobs.Count} iş ilanı bulundu:\n");

            foreach (var job in matchingJobs.Take(5)) // İlk 5 tanesini göster
            {
                var matchScore = CalculateMatchScore(resumeContent.ToLower(), job);
                var matchPercentage = (matchScore * 100).ToString("F0");
                
                summary.AppendLine($"🎯 **{job.Title}** - {job.CompanyName}");
                summary.AppendLine($"📍 Konum: {job.Location}");
                summary.AppendLine($"💰 Maaş: {job.SalaryMin:N0} - {job.SalaryMax:N0} TL");
                summary.AppendLine($"📊 Eşleşme Oranı: %{matchPercentage}");
                summary.AppendLine($"🔧 Gerekli Yetenekler: {job.RequiredSkills}");
                summary.AppendLine($"📝 Açıklama: {job.Description.Substring(0, Math.Min(100, job.Description.Length))}...");
                summary.AppendLine();
            }

            if (matchingJobs.Count > 5)
            {
                summary.AppendLine($"... ve {matchingJobs.Count - 5} iş ilanı daha bulunmaktadır.");
            }

            summary.AppendLine("\n💡 **Öneriler:**");
            summary.AppendLine("• Bu pozisyonlara başvurmak için CV'nizi güçlendirin");
            summary.AppendLine("• Eksik yeteneklerinizi geliştirin");
            summary.AppendLine("• Deneyimlerinizi detaylandırın");

            return summary.ToString();
        }
    }
} 
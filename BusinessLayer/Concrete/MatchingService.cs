using BusinessLayer.Abstract;
using EntityLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MatchingService : IMatchingService
    {
        public async Task<List<JobPosting>> FindMatchingJobs(string resumeContent)
        {
            // TODO: Implement job matching logic
            // Şimdilik boş liste dönüyoruz
            return await Task.FromResult(new List<JobPosting>());
        }
    }
} 
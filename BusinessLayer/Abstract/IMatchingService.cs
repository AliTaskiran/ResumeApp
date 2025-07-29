using System.Collections.Generic;
using System.Threading.Tasks;
using EntityLayer;

namespace BusinessLayer.Abstract
{
    public interface IMatchingService
    {
        Task<List<JobPosting>> FindMatchingJobs(string resumeContent);
        Task<string> GetMatchingJobsSummary(string resumeContent);
    }
} 
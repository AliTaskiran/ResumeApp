using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfJobPostingDal : GenericRepository<JobPosting>, IJobPostingDal
    {
        public async Task<List<JobPosting>> GetActiveJobsAsync()
        {
            using var context = new Context();
            return await context.JobPostings
                .Where(j => j.IsActive && !j.IsFilled)
                .OrderByDescending(j => j.CreatedDate)
                .ToListAsync();
        }
    }
}

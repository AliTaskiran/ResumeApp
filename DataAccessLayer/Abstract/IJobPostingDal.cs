using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IJobPostingDal : IGenericDal<JobPosting>
    {
        Task<List<JobPosting>> GetActiveJobsAsync();
    }
}

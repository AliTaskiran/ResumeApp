using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class JobPostingManager : IJobPostingService
    {
        private readonly IJobPostingDal _jobPostingDal;

        public JobPostingManager(IJobPostingDal jobPostingDal)
        {
            _jobPostingDal = jobPostingDal;
        }

        public async Task<List<JobPosting>> GetActiveJobsAsync()
        {
            return await _jobPostingDal.GetActiveJobsAsync();
        }

        public void TAdd(JobPosting t)
        {
           _jobPostingDal.Insert(t);
        }

        public void TDelete(JobPosting t)
        {
          _jobPostingDal.Delete(t);
        }

        public JobPosting TGetById(int id)
        {
          return _jobPostingDal.GetById(id);
        }

        public List<JobPosting> TGetList()
        {
           return _jobPostingDal.GetList();
        }

        public void TUpdate(JobPosting t)
        {
          _jobPostingDal.Update(t);
        }
    }
}

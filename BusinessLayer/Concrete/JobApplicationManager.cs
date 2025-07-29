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
    public class JobApplicationManager : IJobApplicationService
    {
        IJobApplicationDal _jobApplicationDal;

        public JobApplicationManager(IJobApplicationDal jobApplicationDal)
        {
            _jobApplicationDal = jobApplicationDal;
        }

        public void TAdd(JobApplication t)
        {
           _jobApplicationDal.Insert(t);
        }

        public void TDelete(JobApplication t)
        {
            _jobApplicationDal.Delete(t);
        }

        public JobApplication TGetById(int id)
        {
          return _jobApplicationDal.GetById(id);
        }

        public List<JobApplication> TGetList()
        {
          return _jobApplicationDal.GetList();
        }

        public void TUpdate(JobApplication t)
        {
          _jobApplicationDal.Update(t);
        }
    }
}

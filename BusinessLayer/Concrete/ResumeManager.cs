using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ResumeManager : IResumeService
    {
        private readonly IResumeDal _resumeDal;

        public ResumeManager(IResumeDal resumeDal)
        {
            _resumeDal = resumeDal;
        }

        public async Task<Resume> AddAsync(Resume resume)
        {
            await _resumeDal.AddAsync(resume);
            return resume;
        }

        public void TAdd(Resume t)
        {
            _resumeDal.Insert(t);
        }

        public void TDelete(Resume t)
        {
            _resumeDal.Delete(t);
        }

        public Resume TGetById(int id)
        {
            return _resumeDal.GetById(id);
        }

        public List<Resume> TGetList()
        {
            return _resumeDal.GetList();
        }

        public void TUpdate(Resume t)
        {
            _resumeDal.Update(t);
        }
    }
}

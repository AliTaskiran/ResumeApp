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

        public async Task<Resume> GetByIdAsync(int id)
        {
            return await _resumeDal.GetByIdAsync(id);
        }

        public async Task<List<Resume>> GetListAsync()
        {
            return await _resumeDal.GetListAsync();
        }

        public async Task UpdateAsync(Resume resume)
        {
            await _resumeDal.UpdateAsync(resume);
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

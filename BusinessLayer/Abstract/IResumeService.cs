using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace BusinessLayer.Abstract
{
    public interface IResumeService : IGenericService<Resume>
    {
        Task<Resume> AddAsync(Resume resume);
        Task<Resume> GetByIdAsync(int id);
        Task<List<Resume>> GetListAsync();
        Task UpdateAsync(Resume resume);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace DataAccessLayer.Abstract
{
    public interface IResumeDal : IGenericDal<Resume>
    {
        Task<Resume> AddAsync(Resume entity);
        Task<Resume> GetByIdAsync(int id);
        Task<List<Resume>> GetListAsync();
        Task UpdateAsync(Resume entity);
    }
}

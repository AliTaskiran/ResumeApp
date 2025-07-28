using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfResumeDal : GenericRepository<Resume>, IResumeDal
    {
        public async Task<Resume> AddAsync(Resume entity)
        {
            using var context = new Context();
            await context.Resumes.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }
    }
}

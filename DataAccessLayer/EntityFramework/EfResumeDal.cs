using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Resume> GetByIdAsync(int id)
        {
            using var context = new Context();
            return await context.Resumes.FindAsync(id);
        }

        public async Task<List<Resume>> GetListAsync()
        {
            using var context = new Context();
            return await context.Resumes.ToListAsync();
        }

        public async Task UpdateAsync(Resume entity)
        {
            using var context = new Context();
            context.Resumes.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}

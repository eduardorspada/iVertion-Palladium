using System.Threading.Tasks;
using iVertion.Domain.Interfaces;
using iVertion.Infra.Data.Context;

namespace iVertion.Infra.Data.Repositories
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _context;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<T> CreateAsync<T>(T entity) where T : class
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> RemoveAsync<T>(T entity) where T : class
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync<T>(T entity) where T : class
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}

using System.Threading.Tasks;

namespace iVertion.Domain.Interfaces
{
    public interface IRepository
    {
         Task<T> CreateAsync<T>(T entity) where T : class;
         Task<T> UpdateAsync<T>(T entity) where T : class;
         Task<T> RemoveAsync<T>(T entity) where T : class;   
    }
}
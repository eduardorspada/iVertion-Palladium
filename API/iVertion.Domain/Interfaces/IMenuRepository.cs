using iVertion.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iVertion.Domain.Interfaces
{
    public interface IMenuRepository
    {
        Task<IEnumerable<Menu>> GetMenuAsync(int? page);
        Task<Menu> GetMenuByIdAsync(int? id);
        Task<List<Menu>> GetMenuByNameAsync(string? name);
    }
}
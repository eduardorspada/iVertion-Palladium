
using iVertion.Domain.Entities;
using iVertion.Domain.FiltersDb;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iVertion.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<PagedBaseResponse<Category>> GetCategoryiesAsync(CategoryFilterDb request);
        Task<Category> GetCategoryByIdAsync(int? id);
    }
}
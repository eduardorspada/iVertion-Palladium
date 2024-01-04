using iVertion.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iVertion.Domain.Interfaces
{
    public interface IPageRepository
    {
        Task<IEnumerable<Page>> GetPagesAsync(int? page);
        Task<Page> GetPageByIdAsync(int? id);
        Task<List<Page>> GetPageByTitleAsync(string? title);
    }
}
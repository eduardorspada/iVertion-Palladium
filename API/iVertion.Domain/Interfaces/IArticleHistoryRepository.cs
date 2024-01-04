using System.Threading.Tasks;
using iVertion.Domain.Entities;
using iVertion.Domain.FiltersDb;

namespace iVertion.Domain.Interfaces
{
    public interface IArticleHistoryRepository
    {
        Task<PagedBaseResponse<ArticleHistory>> GetArticleHistoriesAsync(ArticleHistoryFilterDb request);
        Task<ArticleHistory> GetArticleHistoryByIdAsync(int? id);
    }
}
using iVertion.Domain.Entities;
using iVertion.Domain.FiltersDb;
using System.Threading.Tasks;

namespace iVertion.Domain.Interfaces
{
    public interface IArticleRepository
    {
        Task<PagedBaseResponse<Article>> GetArticlesAsync(ArticleFilterDb request);
        Task<Article> GetArticleByIdAsync(int? id);
    }
}
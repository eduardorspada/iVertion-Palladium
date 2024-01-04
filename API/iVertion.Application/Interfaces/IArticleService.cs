

using iVertion.Application.DTOs;
using iVertion.Application.Services;
using iVertion.Domain.FiltersDb;
using System.Threading.Tasks;

namespace iVertion.Application.Interfaces
{
    public interface IArticleService
    {
        Task<ResultService<PagedBaseResponseDTO<ArticleDTO>>> GetArticlesAsync(ArticleFilterDb articleFilterDb);
        Task<ResultService<ArticleDTO>> GetArticleByIdAsync(int? id);
        Task CreateAsync(ArticleDTO ArticleDto);
        Task UpdateAsync(ArticleDTO ArticleDto);
        Task RemoveAsync(int? id);
    }
}
using System.Threading.Tasks;
using iVertion.Application.DTOs;
using iVertion.Application.Services;
using iVertion.Domain.FiltersDb;

namespace iVertion.Application.Interfaces
{
    public interface IArticleHistoryService
    {
        Task<ResultService<PagedBaseResponseDTO<ArticleHistoryDTO>>> GetArticleHistoriesAsync(ArticleHistoryFilterDb articleHistoryFilterDb);
        Task<ResultService<ArticleHistoryDTO>> GetArticleHistoryByIdAsync(int? id);
        Task CreateAsync(ArticleHistoryDTO ArticleHistoryDto);
    }
}
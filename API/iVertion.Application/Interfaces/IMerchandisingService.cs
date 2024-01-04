using System.Threading.Tasks;
using iVertion.Application.DTOs;
using iVertion.Application.Services;
using iVertion.Domain.FiltersDb;

namespace iVertion.Application.Interfaces
{
    public interface IMerchandisingService
    {
        Task<ResultService<PagedBaseResponseDTO<MerchandisingDTO>>> GetMerchandisingsAsync(MerchandisingFilterDb merchandisingFilterDb);
        Task<ResultService<MerchandisingDTO>> GetMerchandisingByIdAsync(int id);
        Task CreateAsync(MerchandisingDTO merchandisingDto);
        Task UpdateAsync(MerchandisingDTO merchandisingDto);
        Task RemoveAsync(int id);
    }
}
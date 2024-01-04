using System.Threading.Tasks;
using iVertion.Application.DTOs;
using iVertion.Application.Services;
using iVertion.Domain.FiltersDb;

namespace iVertion.Application.Interfaces
{
    public interface IPanelMerchandisingService
    {
        Task<ResultService<PagedBaseResponseDTO<PanelMerchandisingDTO>>> GetPanelMerchandisingsAsync(PanelMerchandisingFilterDb panelMerchandisingFilterDb);
        Task CreateAsync(PanelMerchandisingDTO panelMerchandisingDto);
        Task UpdateAsync(PanelMerchandisingDTO panelMerchandisingDto);
        Task RemoveAsync(int panelId, int merchandisingId);
    }
}
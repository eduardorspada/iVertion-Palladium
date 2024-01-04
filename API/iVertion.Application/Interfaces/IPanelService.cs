using System.Threading.Tasks;
using iVertion.Application.DTOs;
using iVertion.Application.Services;
using iVertion.Domain.FiltersDb;

namespace iVertion.Application.Interfaces
{
    public interface IPanelService
    {
        Task<ResultService<PagedBaseResponseDTO<PanelDTO>>> GetPanelsAsync(PanelFilterDb panelFilterDb);
        Task<ResultService<PanelDTO>> GetPanelByIdAsync(int id);
        Task CreateAsync(PanelDTO panelDto);
        Task UpdateAsync(PanelDTO panelDto);
        Task RemoveAsync(int id);
    }
}
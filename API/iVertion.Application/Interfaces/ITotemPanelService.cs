using System.Threading.Tasks;
using iVertion.Application.DTOs;
using iVertion.Application.Services;
using iVertion.Domain.FiltersDb;

namespace iVertion.Application.Interfaces
{
    public interface ITotemPanelService
    {
        Task<ResultService<PagedBaseResponseDTO<TotemPanelDTO>>> GetTotemPanelsAsync(TotemPanelFilterDb totemPanelFilterDb);
        Task CreateAsync(TotemPanelDTO totemPanelDto);
        Task UpdateAsync(TotemPanelDTO totemPanelDto);
        Task RemoveAsync(int totemId, int panelId);
    }
}
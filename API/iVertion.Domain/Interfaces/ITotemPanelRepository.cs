using System.Threading.Tasks;
using iVertion.Domain.Entities;
using iVertion.Domain.FiltersDb;

namespace iVertion.Domain.Interfaces
{
    public interface ITotemPanelRepository
    {
        Task<PagedBaseResponse<TotemPanel>> GetTotemPanelsAsync(TotemPanelFilterDb request);
    }
}
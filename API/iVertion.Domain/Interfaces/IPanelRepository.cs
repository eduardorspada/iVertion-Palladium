using System.Threading.Tasks;
using iVertion.Domain.Entities;
using iVertion.Domain.FiltersDb;

namespace iVertion.Domain.Interfaces
{
    public interface IPanelRepository
    {
        Task<PagedBaseResponse<Panel>> GetPanelsAsync(PanelFilterDb request);
        Task<Panel> GetPanelByIdAsync(int id);
    }
}
using System.Threading.Tasks;
using iVertion.Domain.Entities;
using iVertion.Domain.FiltersDb;

namespace iVertion.Domain.Interfaces
{
    public interface IPanelMerchandisingRepository
    {
        Task<PagedBaseResponse<PanelMerchandising>> GetPanelsMerchandisingAsync(PanelMerchandisingFilterDb request);
    }
}
using System.Linq;
using System.Threading.Tasks;
using iVertion.Domain.Entities;
using iVertion.Domain.FiltersDb;
using iVertion.Domain.Interfaces;
using iVertion.Infra.Data.Context;

namespace iVertion.Infra.Data.Repositories
{
    public class TotemPanelRepository : ITotemPanelRepository
    {
        private readonly ApplicationDbContext _context;
        public TotemPanelRepository(ApplicationDbContext context)
        {
            _context = context;            
        }

        public async Task<PagedBaseResponse<TotemPanel>> GetTotemPanelsAsync(TotemPanelFilterDb request)
        {
            var totemPanels =  _context.TotemPanels.AsQueryable();

            // TotemId
            if (request.TotemId != null)
                totemPanels = totemPanels.Where(p => p.TotemId == request.TotemId);
            // PanelId
            if (request.PanelId != null)
                totemPanels = totemPanels.Where(p => p.PanelId == request.PanelId);

            return await PagedBaseResponseHelper
                            .GetResponseAsync<PagedBaseResponse<TotemPanel>, TotemPanel>(totemPanels, request);
        }
    }
}
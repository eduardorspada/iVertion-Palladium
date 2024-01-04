using System.Linq;
using System.Threading.Tasks;
using iVertion.Domain.Entities;
using iVertion.Domain.FiltersDb;
using iVertion.Domain.Interfaces;
using iVertion.Infra.Data.Context;

namespace iVertion.Infra.Data.Repositories
{
    public class PanelMerchandisingRepository : IPanelMerchandisingRepository
    {
        private readonly ApplicationDbContext _context;
        public PanelMerchandisingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedBaseResponse<PanelMerchandising>> GetPanelsMerchandisingAsync(PanelMerchandisingFilterDb request)
        {
            var panelMerchandisings = _context.PanelMerchandisings.AsQueryable();

            // PanelId
            if (request.PanelId != null)
                panelMerchandisings = panelMerchandisings.Where(p => p.PanelId == request.PanelId);
            // MerchandisingId
            if (request.MerchandisingId != null)
                panelMerchandisings = panelMerchandisings.Where(p => p.MerchandisingId == request.MerchandisingId);
                
            return await PagedBaseResponseHelper
                            .GetResponseAsync<PagedBaseResponse<PanelMerchandising>, PanelMerchandising>(panelMerchandisings, request);

        }
    }
}
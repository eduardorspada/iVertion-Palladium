using System;
using System.Linq;
using System.Threading.Tasks;
using iVertion.Domain.Entities;
using iVertion.Domain.FiltersDb;
using iVertion.Domain.Interfaces;
using iVertion.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace iVertion.Infra.Data.Repositories
{
    public class MerchandisingRepository : IMerchandisingRepository
    {
        private readonly ApplicationDbContext _context;
        public MerchandisingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedBaseResponse<Merchandising>> GetMerchandisingAsync(MerchandisingFilterDb request)
        {
            var merchandisings = _context.Merchandisings.AsQueryable();

            // Name
            if (!String.IsNullOrEmpty(request.Name))
                merchandisings = merchandisings.Where(c => c.Name.Contains(request.Name));
            // Description
            if (!String.IsNullOrEmpty(request.Description))
                merchandisings = merchandisings.Where(c => c.Description.Contains(request.Description));
            // Active
            if (request.Active != null)
                merchandisings = merchandisings.Where(p => p.Active == request.Active);
            // UserId
            if (!String.IsNullOrEmpty(request.UserId))
                merchandisings = merchandisings.Where(p => p.UserId.Contains(request.UserId));
            // PainelId
            if (request.PanelId != null)
                merchandisings = merchandisings.Where(p => p.PanelMerchandising.PanelId == request.PanelId);
            // StartDateFilter
            if (!String.IsNullOrEmpty(request.StartDateFilter.ToString()))
                merchandisings = merchandisings.Where(p => p.CreatedAt > request.StartDateFilter);
            // EndDateFilter
            if (!String.IsNullOrEmpty(request.EndDateFilter.ToString()))
                merchandisings = merchandisings.Where(p => p.CreatedAt > request.EndDateFilter);
            
            return await PagedBaseResponseHelper
                            .GetResponseAsync<PagedBaseResponse<Merchandising>, Merchandising>(merchandisings, request);
        }

        public async Task<Merchandising> GetMerchandisingById(int id)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var  merchandising = await _context.Merchandisings.FindAsync(id);
            return merchandising;
        }
    }
}
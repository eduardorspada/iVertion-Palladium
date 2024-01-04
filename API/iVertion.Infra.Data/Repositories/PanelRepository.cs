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
    public class PanelRepository : IPanelRepository
    {
        private readonly ApplicationDbContext _context;
        public PanelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Panel> GetPanelByIdAsync(int id)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var  panel = await _context.Panels.FindAsync(id);
            return panel;
        }

        public async Task<PagedBaseResponse<Panel>> GetPanelsAsync(PanelFilterDb request)
        {
            var panels = _context.Panels.AsQueryable();

            // Acronym
            if(!String.IsNullOrEmpty(request.Acronym))
                panels = panels.Where(c => c.Acronym.Contains(request.Acronym));
            // Name
            if (!String.IsNullOrEmpty(request.Name))
                panels = panels.Where(c => c.Name.Contains(request.Name));
            // Active
            if (request.Active != null)
                panels = panels.Where(p => p.Active == request.Active);
            // UserId
            if (!String.IsNullOrEmpty(request.UserId))
                panels = panels.Where(p => p.UserId.Contains(request.UserId));


            return await PagedBaseResponseHelper
                            .GetResponseAsync<PagedBaseResponse<Panel>, Panel>(panels, request);
        }
    }
}
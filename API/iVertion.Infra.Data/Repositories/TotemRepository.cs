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
    public class TotemRepository : ITotemRepository
    {
        private readonly ApplicationDbContext _context;
        public TotemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Totem> GetTotemByIdAsync(int id)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var  totem = await _context.Totems.FindAsync(id);
            return totem;
        }

        public async Task<PagedBaseResponse<Totem>> GetTotensAsync(TotemFilterDb request)
        {
            var totems = _context.Totems.AsQueryable();
            // Acronym
            if(!String.IsNullOrEmpty(request.Acronym))
                totems = totems.Where(c => c.Acronym.Contains(request.Acronym));
            // Name
            if (!String.IsNullOrEmpty(request.Name))
                totems = totems.Where(c => c.Name.Contains(request.Name));
            // Active
            if (request.Active != null)
                totems = totems.Where(p => p.Active == request.Active);
            // UserId
            if (!String.IsNullOrEmpty(request.UserId))
                totems = totems.Where(p => p.UserId.Contains(request.UserId));

            return await PagedBaseResponseHelper
                            .GetResponseAsync<PagedBaseResponse<Totem>, Totem>(totems, request);
        }
    }
}
using System;
using System.Threading.Tasks;
using iVertion.Domain.Entities;
using iVertion.Domain.FiltersDb;
using iVertion.Domain.Interfaces;
using iVertion.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace iVertion.Infra.Data.Repositories
{
    public class CounterRepository : ICounterRepository
    {
        private readonly ApplicationDbContext _context;
        public CounterRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Counter> GetCounterById(int id)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var  counter = await _context.Counters.FindAsync(id);
            return counter;
        }

        public async Task<PagedBaseResponse<Counter>> GetCountersAsync(CounterFilterDb request)
        {
            var counters =  _context.Counters.AsQueryable();

            // Name
            if (!String.IsNullOrEmpty(request.Name))
                counters = counters.Where(c => c.Name.Contains(request.Name));
            // PanelId
            if (request.PanelId != null)
                counters = counters.Where(p => p.PanelId == request.PanelId);
            // Active
            if (request.Active != null)
                counters = counters.Where(p => p.Active == request.Active);
            // UserId
            if (!String.IsNullOrEmpty(request.UserId))
                counters = counters.Where(p => p.UserId.Contains(request.UserId));

            
            return await PagedBaseResponseHelper
                            .GetResponseAsync<PagedBaseResponse<Counter>, Counter>(counters, request);

        }
    }
}
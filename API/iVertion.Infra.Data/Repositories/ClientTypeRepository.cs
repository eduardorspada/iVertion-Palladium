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
    public class ClientTypeRepository : IClientTypeRepository
    {
        private readonly ApplicationDbContext _context;
        public ClientTypeRepository(ApplicationDbContext context)
        {
            _context = context;            
        }
        public async Task<PagedBaseResponse<ClientType>> GetClientsTypeAsync(ClientTypeFilterDb request)
        {
            var clientTypes = _context.ClientTypes.AsQueryable();

            if(!String.IsNullOrEmpty(request.Description))
                clientTypes = clientTypes.Where(c => c.Description.Contains(request.Description));
            if(!String.IsNullOrEmpty(request.Acronym))
                clientTypes = clientTypes.Where(c => c.Acronym.Contains(request.Acronym));
            if (request.Active != null)
                clientTypes = clientTypes.Where(p => p.Active == request.Active);
            if (!String.IsNullOrEmpty(request.UserId))
                clientTypes = clientTypes.Where(p => p.UserId.Contains(request.UserId));
            
            return await PagedBaseResponseHelper
                            .GetResponseAsync<PagedBaseResponse<ClientType>, ClientType>(clientTypes ,request);
        }

        public async Task<ClientType> GetClientTypeByIdAsync(int id)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var clientType = await _context.ClientTypes.FindAsync(id);
            return clientType;
        }
    }
}
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
    public class ServiceTypeRepository : IServiceTypeRepository
    {
        private readonly ApplicationDbContext _context;
        public ServiceTypeRepository(ApplicationDbContext context)
        {
            _context = context;            
        }

        public async Task<PagedBaseResponse<ServiceType>> GetServicesTypeAsync(ServiceTypeFilterDb request)
        {
            var serviceTypes = _context.ServiceTypes.AsQueryable();

            if(!String.IsNullOrEmpty(request.Description))
                serviceTypes = serviceTypes.Where(c => c.Description.Contains(request.Description));
            if(!String.IsNullOrEmpty(request.Acronym))
                serviceTypes = serviceTypes.Where(c => c.Acronym.Contains(request.Acronym));
            if (request.Active != null)
                serviceTypes = serviceTypes.Where(p => p.Active == request.Active);
            if (!String.IsNullOrEmpty(request.UserId))
                serviceTypes = serviceTypes.Where(p => p.UserId.Contains(request.UserId));
            
            return await PagedBaseResponseHelper
                            .GetResponseAsync<PagedBaseResponse<ServiceType>, ServiceType>(serviceTypes ,request);
        }

        public async Task<ServiceType> GetServiceTypeByIdAsync(int id)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var serviceType = await _context.ServiceTypes.FindAsync(id);
            return serviceType;
        }
    }
}
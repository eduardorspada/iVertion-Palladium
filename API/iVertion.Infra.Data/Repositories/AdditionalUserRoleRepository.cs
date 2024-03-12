using iVertion.Domain.Entities;
using iVertion.Domain.FiltersDb;
using iVertion.Domain.Interfaces;
using iVertion.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace iVertion.Infra.Data.Repositories
{
    public class AdditionalUserRoleRepository : IAdditionalUserRoleRepository
    {
        private readonly ApplicationDbContext _context;
        public AdditionalUserRoleRepository(ApplicationDbContext context)
        {
            _context = context;            
        }

        public async Task<PagedBaseResponse<AdditionalUserRole>> GetAdditionalUserRoleAsync(AdditionalUserRoleFilterDb request)
        {
            var additionalUserRoles = _context.AdditionalUserRoles.AsQueryable();

            if(!String.IsNullOrEmpty(request.Role))
                additionalUserRoles = additionalUserRoles.Where(c => c.Role.Contains(request.Role));

            if(!String.IsNullOrEmpty(request.TargetUserId))
                additionalUserRoles = additionalUserRoles.Where(c => c.TargetUserId == request.TargetUserId);

            // UserId
            if (!String.IsNullOrEmpty(request.UserId))
                additionalUserRoles = additionalUserRoles.Where(p => p.UserId.Contains(request.UserId));
            return await PagedBaseResponseHelper
                            .GetResponseAsync<PagedBaseResponse<AdditionalUserRole>, AdditionalUserRole>(additionalUserRoles, request);
        }

        public async Task<AdditionalUserRole> GetAdditionalUserRoleByIdAsync(int id)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var  additionalUserRole = await _context.AdditionalUserRoles.FindAsync(id);
            return additionalUserRole;
        }

    }
}
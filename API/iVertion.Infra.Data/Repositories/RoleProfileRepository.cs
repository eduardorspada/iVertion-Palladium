using iVertion.Domain.Entities;
using iVertion.Domain.FiltersDb;
using iVertion.Domain.Interfaces;
using iVertion.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace iVertion.Infra.Data.Repositories
{
    public class RoleProfileRepository : IRoleProfileRepository
    {
        private readonly ApplicationDbContext _context;
        public RoleProfileRepository(ApplicationDbContext context)
        {
            _context = context;            
        }

        public async Task<RoleProfile> GetRoleProfileByIDAsync(int id)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var  roleProfile = await _context.RoleProfiles.FindAsync(id);
            return roleProfile;
        }

        public async Task<PagedBaseResponse<RoleProfile>> GetRoleProfilesAsync(RoleProfileFilterDb request)
        {
            var roleProfiles = _context.RoleProfiles.AsQueryable();

            if(!String.IsNullOrEmpty(request.Role))
                roleProfiles = roleProfiles.Where(c => c.Role.Contains(request.Role));
            // UserId
            if (!String.IsNullOrEmpty(request.UserId))
                roleProfiles = roleProfiles.Where(p => p.UserId.Contains(request.UserId));
            if (request.UserProfileId != null)
                roleProfiles = roleProfiles.Where(p => p.UserProfileId == request.UserProfileId);
            return await PagedBaseResponseHelper
                            .GetResponseAsync<PagedBaseResponse<RoleProfile>, RoleProfile>(roleProfiles, request);
        }

    }
}
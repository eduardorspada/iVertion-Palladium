using iVertion.Domain.Entities;
using iVertion.Domain.FiltersDb;
using iVertion.Domain.Interfaces;
using iVertion.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace iVertion.Infra.Data.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly ApplicationDbContext _context;
        public UserProfileRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedBaseResponse<UserProfile>> GetUserProfileAsync(UserProfileFilterDb request)
        {
            var userProfiles = _context.UserProfiles.AsQueryable();

            if(!String.IsNullOrEmpty(request.Name))
                userProfiles = userProfiles.Where(c => c.Name.Contains(request.Name));

            if (request.Active != null)
                userProfiles = userProfiles.Where(p => p.Active == request.Active);
            // UserId
            if (!String.IsNullOrEmpty(request.UserId))
                userProfiles = userProfiles.Where(p => p.UserId.Contains(request.UserId));

            return await PagedBaseResponseHelper
                            .GetResponseAsync<PagedBaseResponse<UserProfile>, UserProfile>(userProfiles, request);
        }

        public async Task<UserProfile> GetUserProfileByIdAsync(int id)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var  userProfile = await _context.UserProfiles.FindAsync(id);
            return userProfile;
        }

    }
}
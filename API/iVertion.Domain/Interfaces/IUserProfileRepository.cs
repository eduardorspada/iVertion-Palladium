using iVertion.Domain.Entities;
using iVertion.Domain.FiltersDb;

namespace iVertion.Domain.Interfaces
{
    public interface IUserProfileRepository
    {
         Task<PagedBaseResponse<UserProfile>> GetUserProfileAsync(UserProfileFilterDb request);
         Task<UserProfile> GetUserProfileByIdAsync(int id);
    }
}
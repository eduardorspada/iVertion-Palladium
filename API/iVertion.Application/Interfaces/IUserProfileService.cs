using iVertion.Application.DTOs;
using iVertion.Application.Services;
using iVertion.Domain.FiltersDb;

namespace iVertion.Application.Interfaces
{
    public interface IUserProfileService
    {
         Task<ResultService<PagedBaseResponseDTO<UserProfileDTO>>> GetUserProfilesAsync(UserProfileFilterDb userProfileFilterDb);
         Task<ResultService<UserProfileDTO>> GetUserProfileByIdAsync(int id);
         Task CreateUserProfileAsync(UserProfileDTO userProfileDto);
         Task UpdateUserProfileAsync(UserProfileDTO userProfileDto);
         Task RemoveUserProfileAsync(int id);
    }
}
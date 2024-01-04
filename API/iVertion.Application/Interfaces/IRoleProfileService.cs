using iVertion.Application.DTOs;
using iVertion.Application.Services;
using iVertion.Domain.FiltersDb;

namespace iVertion.Application.Interfaces
{
    public interface IRoleProfileService
    {
         Task<ResultService<PagedBaseResponseDTO<RoleProfileDTO>>> GetRoleProfilesAsync(RoleProfileFilterDb roleProfileFilterDb);
         Task<ResultService<RoleProfileDTO>> GetRoleProfileByIdAsync(int id);
         Task CreateRoleProfileAsync(RoleProfileDTO roleProfileDto);
         Task UpdateRoleProfileAsync(RoleProfileDTO roleProfileDto);
         Task RemoveRoleProfileAsync(int id);
    }
}
using iVertion.Application.DTOs;
using iVertion.Application.Services;
using iVertion.Domain.FiltersDb;

namespace iVertion.Application.Interfaces
{
    public interface IAdditionalUserRoleService
    {
         Task<ResultService<PagedBaseResponseDTO<AdditionalUserRoleDTO>>> GetAdditionalUserRolesAsync(AdditionalUserRoleFilterDb addtionalUserRoleFilterDb);
         Task<ResultService<AdditionalUserRoleDTO>> GetAdditionalUserRoleByIdAsync(int id);
         Task CreateAdditionalUserRoleAsync(AdditionalUserRoleDTO addtionalUserRoleDto);
         Task UpdateAdditionalUserRoleAsync(AdditionalUserRoleDTO addtionalUserRoleDto);
         Task RemoveAdditionalUserRoleAsync(int id);
    }
}
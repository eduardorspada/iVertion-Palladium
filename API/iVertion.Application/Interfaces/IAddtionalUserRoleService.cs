using iVertion.Application.DTOs;
using iVertion.Application.Services;
using iVertion.Domain.FiltersDb;

namespace iVertion.Application.Interfaces
{
    public interface IAddtionalUserRoleService
    {
         Task<ResultService<PagedBaseResponseDTO<AddtionalUserRoleDTO>>> GetAddtionalUserRolesAsync(AddtionalUserRoleFilterDb addtionalUserRoleFilterDb);
         Task<ResultService<AddtionalUserRoleDTO>> GetAddtionalUserRoleByIdAsync(int id);
         Task CreateAddtionalUserRoleAsync(AddtionalUserRoleDTO addtionalUserRoleDto);
         Task UpdateAddtionalUserRoleAsync(AddtionalUserRoleDTO addtionalUserRoleDto);
         Task RemoveAddtionalUserRoleAsync(int id);
    }
}
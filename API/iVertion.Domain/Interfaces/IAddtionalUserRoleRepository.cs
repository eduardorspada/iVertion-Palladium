using iVertion.Domain.Entities;
using iVertion.Domain.FiltersDb;

namespace iVertion.Domain.Interfaces
{
    public interface IAddtionalUserRoleRepository
    {
         Task<PagedBaseResponse<AddtionalUserRole>> GetAddtionalUserRoleAsync(AddtionalUserRoleFilterDb request);
         Task<AddtionalUserRole> GetAddtionalUserRoleByIdAsync(int id);
    }
}
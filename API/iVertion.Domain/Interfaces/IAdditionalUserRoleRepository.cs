using iVertion.Domain.Entities;
using iVertion.Domain.FiltersDb;

namespace iVertion.Domain.Interfaces
{
    public interface IAdditionalUserRoleRepository
    {
         Task<PagedBaseResponse<AdditionalUserRole>> GetAdditionalUserRoleAsync(AdditionalUserRoleFilterDb request);
         Task<AdditionalUserRole> GetAdditionalUserRoleByIdAsync(int id);
    }
}
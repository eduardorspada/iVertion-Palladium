using iVertion.Domain.Entities;
using iVertion.Domain.FiltersDb;

namespace iVertion.Domain.Interfaces
{
    public interface IRoleProfileRepository
    {
         Task<PagedBaseResponse<RoleProfile>> GetRoleProfilesAsync(RoleProfileFilterDb request);
         Task<RoleProfile> GetRoleProfileByIDAsync(int id);
    }
}
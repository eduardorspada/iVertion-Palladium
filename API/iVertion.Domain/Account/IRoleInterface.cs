using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iVertion.Domain.Account
{
    public interface IRoleInterface<TRole> where TRole : class
    {
        Task<bool> RoleExistsAsync(string roleName);
        Task<IEnumerable<TRole>> GetRolesAsync();
    }
}
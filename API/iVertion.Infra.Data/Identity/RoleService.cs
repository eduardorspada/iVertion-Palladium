using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iVertion.Domain.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace iVertion.Infra.Data.Identity
{
    public class RoleService : IRoleInterface<IdentityRole>
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleService(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<IEnumerable<IdentityRole>> GetRolesAsync()
        {
            return await _roleManager.Roles.ToListAsync();
        }

        public async Task<bool> RoleExistsAsync(string roleName)
        {
            return await _roleManager.RoleExistsAsync(roleName);
        }
    }
}
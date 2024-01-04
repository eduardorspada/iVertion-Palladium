using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iVertion.Domain.Account
{
    public interface IUserInterface<TUser> where TUser : class
    {
        //Information
        Task<List<TUser>> GetUsersAsync();
        Task<TUser> GetUserByNameAsync(string? userName);
        Task<TUser> GetUserByIdAsync(string? id);
        Task<bool> UpdateUserAsync(TUser user);
        Task<IList<string>> GetUserRolesAsync(string userName);

        //Password

        Task<bool> UpdatePasswordHashAsync(TUser user, string newPassword);

        //Roles

        Task<bool> AddUserToRoleAsync(TUser user, string role);
        Task<bool> IsInRoleAsync(TUser user, string role);
        Task<bool> RemoveFromRoleAsync(TUser user, string role);
    }
}
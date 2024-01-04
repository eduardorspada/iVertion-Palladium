using iVertion.Domain.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iVertion.Infra.Data.Identity
{
    public class UserService : IUserInterface<ApplicationUser>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ApplicationUser> GetUserByIdAsync(string? id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return user;
        }

        public async Task<List<ApplicationUser>> GetUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();

            return users;
        }

        public async Task<ApplicationUser> GetUserByNameAsync(string? userName)
        {
            var user = await _userManager.FindByEmailAsync(userName);
            return user;
        }

        public async Task<bool> UpdateUserAsync(ApplicationUser user)
        {
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }

        public async Task<IList<string>> GetUserRolesAsync(string userName)
        {
            var user = await _userManager.FindByEmailAsync(userName);
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<bool> AddUserToRoleAsync(ApplicationUser user, string role)
        {
            var result = await _userManager.AddToRoleAsync(user, role);

            return result.Succeeded;
        }

        public async Task<bool> IsInRoleAsync(ApplicationUser user, string role)
        {
            var result = await _userManager.IsInRoleAsync(user, role);

            return result;
        }

        public async Task<bool> RemoveFromRoleAsync(ApplicationUser user, string role)
        {
            var result = await _userManager.RemoveFromRoleAsync(user, role);

            return result.Succeeded;
        }

        public async Task<bool> UpdatePasswordHashAsync(ApplicationUser user, string newPassword)
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, newPassword);
            return result.Succeeded;
        }
    }
}
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using iVertion.Domain.Account;
using iVertion.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Configuration;
using iVertion.Infra.Data.Identity;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using iVertion.Application.Interfaces;
using iVertion.Domain.FiltersDb;
using iVertion.Domain.Entities;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace iVertion.WebApi.Controllers
{
    /// <summary>
    /// Token
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthenticate _authentication;
        private readonly IConfiguration _configuration;
        private readonly IUserInterface<ApplicationUser> _userService;
        private readonly IUserProfileService _userProfileService;
        private readonly IRoleProfileService _roleProfileService;
        private readonly IAdditionalUserRoleService _additionalUserRoleService;
        /// <summary>
        /// Contructor.
        /// </summary>
        /// <param name="authentication"></param>
        /// <param name="configuration"></param>
        /// <param name="userService"></param>
        /// <param name="userProfileService"></param>
        /// <param name="roleProfileService"></param>
        /// <param name="additionalUserRoleService"></param>
        public TokenController(IAuthenticate authentication,
                               IConfiguration configuration,
                               IUserInterface<ApplicationUser> userService,
                               IUserProfileService userProfileService,
                               IRoleProfileService roleProfileService,
                               IAdditionalUserRoleService additionalUserRoleService)
        {
            _authentication = authentication ??
                throw new ArgumentNullException(nameof(authentication));
            _userService = userService ??
                throw new ArgumentNullException(nameof(userService));
            _configuration = configuration;

            _userProfileService = userProfileService ??
                throw new ArgumentNullException(nameof(userProfileService));
            _roleProfileService = roleProfileService ??
                throw new ArgumentNullException(nameof(roleProfileService));
            _additionalUserRoleService = additionalUserRoleService ??
                throw new ArgumentNullException(nameof(additionalUserRoleService));
        }
        /// <summary>
        /// Validate the token
        /// </summary>
        /// <returns></returns>
        [HttpGet("ValidateTokenAsync")]
        [Authorize]
        public bool ValidateToken()
        {
            return true;
        }
        /// <summary>
        /// Returns a Bearer Token for the user from "userInfo".
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("LoginUser")]
        public async Task<ActionResult<UserToken>> Login ([FromBody] LoginModel userInfo)
        {
            var result = await _authentication.Authenticate(userInfo.Email, userInfo.Password);
            if (result)
            {
                var user = await _userService.GetUserByNameAsync(userInfo.Email);
                if (user.IsEnabled)
                {
                    return await GenerateTokenAsync(userInfo);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt.");
                    return BadRequest(ModelState);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt.");
                return BadRequest(ModelState);
            }
        }

        private async Task<List<string>> GetAllUserRolesAsync(int userProfileId, string targetUserId){
            var roleProfileFilterdb = new RoleProfileFilterDb(){
            UserProfileId = userProfileId,
            PageSize = 10000, 
            OrderByProperty = "Id", 
            Page=1, 
            Role= null, 
            UserId=null
            };
            var rolesProfiles = await _roleProfileService.GetRoleProfilesAsync(roleProfileFilterdb);
            var additionalUserRolesFilterDb = new AdditionalUserRoleFilterDb(){
            TargetUserId = targetUserId,
            PageSize = 10000, 
            OrderByProperty = "Id", 
            Page=1, 
            Role=null, 
            UserId=null
            };
            var additionalUserRoles = await _additionalUserRoleService.GetAdditionalUserRolesAsync(additionalUserRolesFilterDb);
            

            var roleModel = new List<string>();
            foreach(var role in rolesProfiles.Data.Data){
                roleModel.Add(role.Role);
            }
            foreach(var role in additionalUserRoles.Data.Data){
                roleModel.Add(role.Role);
            }
            return roleModel;
            
        }

        private async Task<bool> UpdateUserRolesAsync(IList<string> oldRoles, List<string> newRoles, ApplicationUser user){
            foreach(var role in oldRoles){
                if (!newRoles.Contains(role)){
                    await _userService.RemoveFromRoleAsync(user, role);
                }
                
            }
            foreach (var role in newRoles){
                if (!oldRoles.Contains(role)){
                    await _userService.AddUserToRoleAsync(user, role);
                }
            }
            return true;
        }
        private async Task<UserToken> GenerateTokenAsync(LoginModel userInfo)
        {
            var user = await _userService.GetUserByNameAsync(userInfo.Email);
            var userProfile = await _userProfileService.GetUserProfileByIdAsync(user.UserProfileId);
            var newRoles = await GetAllUserRolesAsync(user.UserProfileId, user.Id);
            var oldRoles = await _userService.GetUserRolesAsync(userInfo.Email);

            await UpdateUserRolesAsync(oldRoles, newRoles, user);
        
            var roles = await _userService.GetUserRolesAsync(userInfo.Email);


            var claims = new List<Claim>
            {
                new Claim("email", userInfo.Email),
                new Claim("UId", user.Id),
                new Claim("Name", user.FullName),

                // new Claim("Data", roles.ToString()),
                // new Claim(ClaimTypes.Role, roles),

                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            

            foreach (var role in roles) 
            {
                // claims.Add(new Claim(ClaimTypes.Role, role.Name));
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            
            // Generate the Private Key
            var privateKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"])
            );
            // Generate the Digital Signature
            var credentials = new SigningCredentials(
                privateKey, SecurityAlgorithms.HmacSha256
            );
            // Set Expiration Time
            _ = DateTime.UtcNow;
            DateTime expiration;
            if (roles.Contains("TotemPanel") && roles.Count() == 1)
            {
                expiration = DateTime.UtcNow.AddYears(1);
            }
            else
            {
                expiration = DateTime.UtcNow.AddMinutes(120);
            }
            // Generate the Token
            JwtSecurityToken token = new(
                // issuer
                issuer: _configuration["Jwt:Issuer"],
                // audience
                audience: _configuration["Jwt:Audience"],
                // claims
                claims: claims,
                // Expiration Time
                expires: expiration,
                // Digital Signature
                signingCredentials: credentials
            );
            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}
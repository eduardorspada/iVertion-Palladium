using System.Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using iVertion.Domain.Account;
using iVertion.Infra.Data.Identity;
using iVertion.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using iVertion.Application.Interfaces;
using iVertion.Domain.FiltersDb;
using iVertion.Application.DTOs;

namespace iVertion.WebApi.Controllers
{
    /// <summary>
    /// User
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuthenticate _authentication;
        private readonly IRoleInterface<IdentityRole> _roleService;
        private readonly IUserInterface<ApplicationUser> _userService;
        private readonly IUserProfileService _userProfileService;
        private readonly IRoleProfileService _roleProfileService;
        private readonly IAddtionalUserRoleService _addtionalUserRoleService;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="authentication"></param>
        /// <param name="userService"></param>
        /// <param name="roleService"></param>
        /// <param name="userProfileService"></param>
        /// <param name="roleProfileService"></param>
        /// <param name="addtionalUserRoleService"></param>
        public UserController(IAuthenticate authentication,
                              IUserInterface<ApplicationUser> userService,
                              IRoleInterface<IdentityRole> roleService,
                               IUserProfileService userProfileService,
                               IRoleProfileService roleProfileService,
                               IAddtionalUserRoleService addtionalUserRoleService)
        {
            _authentication = authentication ??
                throw new ArgumentNullException(nameof(authentication));
            _userService = userService ??
                throw new ArgumentNullException(nameof(userService));
            _roleService = roleService ??
                throw new ArgumentNullException(nameof(roleService));
            _userProfileService = userProfileService ??
                throw new ArgumentNullException(nameof(userProfileService));
            _roleProfileService = roleProfileService ??
                throw new ArgumentNullException(nameof(roleProfileService));
            _addtionalUserRoleService = addtionalUserRoleService ??
                throw new ArgumentNullException(nameof(addtionalUserRoleService));
        }
        /// <summary>
        /// Returns a list of users.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "GetUsers")]
        public async Task<ActionResult> Get()
        {
            var users = await _userService.GetUsersAsync();
            return Ok(users);
        }
        /// <summary>
        /// Returns a user by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "GetUsers")]
        public async Task<ActionResult> GetUserByIdAsync(string id){
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null){
                return NotFound();
            } else {
                return Ok(user);
            }
        }
        /// <summary>
        /// Creates a new user from the "userInfo" properties.
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        
        [HttpPost("CreateUser")]
        [Authorize(Roles = "AddUser")]
        public async Task<ActionResult> CreateUser ([FromBody] RegisterModel userInfo)
        {
            var result = await _authentication.RegisterUser(userInfo.Email,
                                                            userInfo.Password,
                                                            userInfo.FirstName,
                                                            userInfo.LastName,
                                                            userInfo.IsEnabled,
                                                            userInfo.ProfilePicture,
                                                            userInfo.ProfileCover,
                                                            userInfo.ProfileDescription,
                                                            userInfo.Occupation,
                                                            userInfo.Birthday,
                                                            userInfo.PhoneNumber,
                                                            userInfo.UserProfileId
                                                            );
            if (result)
            {
                return Ok($"User {userInfo.Email} was created successfully.");
            }
            else
            {
                ModelState.AddModelError("error", "We had a problem compiling the data.");
                return BadRequest(ModelState);
            }
        }
        /// <summary>
        /// Retuns user profile information
        /// </summary>
        /// <param name="userProfileFilterDb"></param>
        /// <returns></returns>
        [HttpGet("UsersProfile")]
        [Authorize(Roles = "AddToRole")]
        public async Task<ActionResult> GetUserProfileAsync([FromQuery] UserProfileFilterDb userProfileFilterDb){
            var result = await _userProfileService.GetUserProfilesAsync(userProfileFilterDb);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
        /// <summary>
        /// Returns a user profile information
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("UsersProfile/{id}")]
        [Authorize(Roles = "AddToRole")]
        public async Task<ActionResult> GetUserProfileByIdAsync(int id){
            var result = await _userProfileService.GetUserProfileByIdAsync(id);
            if (result.Data == null)
                return NotFound();
            if (result.IsSuccess){
                return Ok(result);
            }
            return BadRequest(result);
        }
        /// <summary>
        /// Returns a roles of user profile by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("RolesUsersProfile/{id}")]
        [Authorize(Roles = "AddToRole")]
        public async Task<List<string>> GetRolesProfileAsync(int id){
            var roleProfileFilterdb = new RoleProfileFilterDb(){
            UserProfileId = id,
            PageSize = 10000, 
            OrderByProperty = "Id", 
            Page=1, 
            Role= null, 
            UserId=null
            };
            var rolesProfiles = await _roleProfileService.GetRoleProfilesAsync(roleProfileFilterdb);
            

            var roleModel = new List<string>();
            foreach(var role in rolesProfiles.Data.Data){
                roleModel.Add(role.Role);
            }
            return roleModel;
            
        }
        /// <summary>
        /// Adds a Role to a User Profile by User Profile Id.
        /// </summary>
        /// <param name="roleFromUserProfileIdModel"></param>
        /// <returns></returns>
        [HttpPost("AddRoleToUserProfile")]
        [Authorize(Roles = "AddToRole")]
        public async Task<ActionResult> AddRoleToUserProfileAsync([FromBody] RoleFromUserProfileIdModel roleFromUserProfileIdModel) {
            if (!String.IsNullOrEmpty(roleFromUserProfileIdModel.Role) && roleFromUserProfileIdModel.UserProfileId > 0){
                var roleExists = await _roleService.RoleExistsAsync(roleFromUserProfileIdModel.Role);
                if (roleExists){
                    var userProfile = await _userProfileService.GetUserProfileByIdAsync(roleFromUserProfileIdModel.UserProfileId);
                    if (userProfile.Data == null)
                        return NotFound("This Id does not correspond to an existing User Profile.");
                    if (userProfile.IsSuccess){
                        var roleProfileFilterdb = new RoleProfileFilterDb(){
                        UserProfileId = roleFromUserProfileIdModel.UserProfileId,
                        PageSize = 10000, 
                        OrderByProperty = "Id", 
                        Page=1, 
                        Role= roleFromUserProfileIdModel.Role, 
                        UserId=null
                        };
                        var rolesProfiles = await _roleProfileService.GetRoleProfilesAsync(roleProfileFilterdb);
                        

                        var roleModel = new List<string>();
                        var roleProfileId = 0;
                        foreach(var role in rolesProfiles.Data.Data){
                            roleModel.Add(role.Role);
                            roleProfileId = role.Id;
                        }
                        if (!roleModel.Contains(roleFromUserProfileIdModel.Role)){
                            var roleProfileDto = new RoleProfileDTO();
                            var userId = User.FindFirst("UId").Value;
                            var dateNow = DateTime.UtcNow;
                            roleProfileDto.Role = roleFromUserProfileIdModel.Role;
                            roleProfileDto.UserProfileId = roleFromUserProfileIdModel.UserProfileId;
                            roleProfileDto.Active = true;
                            roleProfileDto.UserId = userId;
                            roleProfileDto.CreatedAt = dateNow;
                            roleProfileDto.UpdatedAt = dateNow;
                            await _roleProfileService.CreateRoleProfileAsync(roleProfileDto);
                            return Ok($@"{roleFromUserProfileIdModel.Role} has been successfully added.");
                        }
                        return Conflict($@"{roleFromUserProfileIdModel.Role} already exists in Role Profile");
                    }
                    return BadRequest(userProfile);

                }
                return NotFound(@"The specified role does not exist in the system!");
            }

            
            return BadRequest("Role is not be null or empty and UserProfileId must be greater than zero");
            

        }
        /// <summary>
        /// Removes a Role from a User Profile by the Role name and the User Profile Id.
        /// </summary>
        /// <param name="roleFromUserProfileIdModel"></param>
        /// <returns></returns>
        [HttpDelete("RemoveRoleFromUserProfileId")]
        [Authorize(Roles = "RemoveFromRole")]
        public async Task<ActionResult> RemoveRoleFromUserProfileId([FromBody] RoleFromUserProfileIdModel roleFromUserProfileIdModel){
            if (!String.IsNullOrEmpty(roleFromUserProfileIdModel.Role) && roleFromUserProfileIdModel.UserProfileId > 0){
                var roleExists = await _roleService.RoleExistsAsync(roleFromUserProfileIdModel.Role);
                if (roleExists){
                    var userProfile = await _userProfileService.GetUserProfileByIdAsync(roleFromUserProfileIdModel.UserProfileId);
                    if (userProfile.Data == null)
                        return NotFound("This Id does not correspond to an existing User Profile.");
                    if (userProfile.IsSuccess){
                        var roleProfileFilterdb = new RoleProfileFilterDb(){
                        UserProfileId = roleFromUserProfileIdModel.UserProfileId,
                        PageSize = 10000, 
                        OrderByProperty = "Id", 
                        Page=1, 
                        Role= roleFromUserProfileIdModel.Role, 
                        UserId=null
                        };
                        var rolesProfiles = await _roleProfileService.GetRoleProfilesAsync(roleProfileFilterdb);
                        

                        var roleModel = new List<string>();
                        var roleProfileId = 0;
                        foreach(var role in rolesProfiles.Data.Data){
                            roleModel.Add(role.Role);
                            roleProfileId = role.Id;
                        }
                        if (!roleModel.Contains(roleFromUserProfileIdModel.Role)){
                            return Conflict($@"{roleFromUserProfileIdModel.Role} does not exist in Role Profile");
                        }
                        await _roleProfileService.RemoveRoleProfileAsync(roleProfileId);
                        return Ok($@"{roleFromUserProfileIdModel.Role} has been successfully removed.");
                    }
                    return BadRequest(userProfile);

                }
                return NotFound(@"The specified role does not exist in the system!");
            }

            
            return BadRequest("Role is not be null or empty and UserProfileId must be greater than zero");
        }

        /// <summary>
        /// Retuns role information
        /// </summary>
        /// <param name="roleProfileFilterDb"></param>
        /// <returns></returns>
        [HttpGet("RolesProfile")]
        [Authorize(Roles = "AddToRole")]
        public async Task<ActionResult> GetRoleProfileAsync([FromQuery] RoleProfileFilterDb roleProfileFilterDb){
            var result = await _roleProfileService.GetRoleProfilesAsync(roleProfileFilterDb);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
        /// <summary>
        /// Adds an additional role to a user beyond the role profile they belong to.
        /// </summary>
        /// <param name="addtionalUserRoleModel"></param>
        /// <returns></returns>
        [HttpPost("AddAddtionalUserRole")]
        [Authorize(Roles = "AddToRole")]
        public async Task<ActionResult> AddAddtionalUserRoleAsync([FromBody] AddtionalUserRoleModel addtionalUserRoleModel){
            if (!String.IsNullOrEmpty(addtionalUserRoleModel.Role)) {
                if (!String.IsNullOrEmpty(addtionalUserRoleModel.UserName)){
                    var roleExists = await _roleService.RoleExistsAsync(addtionalUserRoleModel.Role);
                    if (roleExists) {
                        var targetUser = await _userService.GetUserByNameAsync(addtionalUserRoleModel.UserName);
                        try {
                            var targetUserId = targetUser.Id;
                            var userProfileId = targetUser.UserProfileId;

                    var userProfile = await _userProfileService.GetUserProfileByIdAsync(userProfileId);
                    if (userProfile.Data == null)
                        return NotFound("This Id does not correspond to an existing User Profile.");
                    if (userProfile.IsSuccess){
                        var roleProfileFilterdb = new RoleProfileFilterDb(){
                        UserProfileId = userProfileId,
                        PageSize = 10000, 
                        OrderByProperty = "Id", 
                        Page=1, 
                        Role= addtionalUserRoleModel.Role, 
                        UserId=null
                        };
                        var rolesProfiles = await _roleProfileService.GetRoleProfilesAsync(roleProfileFilterdb);
                        

                        var roleModel = new List<string>();
                        var roleProfileId = 0;
                        foreach(var role in rolesProfiles.Data.Data){
                            roleModel.Add(role.Role);
                            roleProfileId = role.Id;
                        }
                        if (!roleModel.Contains(addtionalUserRoleModel.Role)){
                            var addtionalUserRoleDto = new AddtionalUserRoleDTO();
                            var userId = User.FindFirst("UId").Value;
                            var dateNow = DateTime.UtcNow;
                            addtionalUserRoleDto.Role = addtionalUserRoleModel.Role;
                            addtionalUserRoleDto.TargetUserId = targetUserId;
                            addtionalUserRoleDto.UserId = userId;
                            addtionalUserRoleDto.Active = true;
                            addtionalUserRoleDto.CreatedAt = dateNow;
                            addtionalUserRoleDto.UpdatedAt = dateNow;
                            await _addtionalUserRoleService.CreateAddtionalUserRoleAsync(addtionalUserRoleDto);
                            return Ok($@"The {addtionalUserRoleModel.Role} has been successfully assigned to the {targetUser.FullName}.");
                        }
                        return Conflict($@"The {addtionalUserRoleModel.Role} already exists in this {targetUser.FullName}'s role profile.");
                    }
                    return BadRequest(userProfile);
                        } catch {
                            return NotFound($@"The specified user '{addtionalUserRoleModel.UserName}', does not exist in the system!");
                        }
                    }
                    return NotFound($@"The specified role '{addtionalUserRoleModel.Role}', does not exist in the system!");
                }
                return BadRequest("UserName is not be null or empty");
            }
            return BadRequest("Role is not be null or empty");
        }
        /// <summary>
        /// Returns a list of roles.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetRoles")]
        [Authorize(Roles = "AddToRole")]
        public async Task<ActionResult> GetRolesAsync(){
            var roles = await _roleService.GetRolesAsync();
            return Ok(roles);
        }
        /// <summary>
        /// Returns a list of roles off some username.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpGet("GetUserRoles/{userName}")]
        [Authorize(Roles = "AddToRole")]
        public async Task<ActionResult> GetUserRolesAsync(string userName){
            var roles = await _userService.GetUserRolesAsync(userName);
            return Ok(roles);
        }
        /// <summary>
        /// Creates a new user role profile
        /// </summary>
        /// <param name="userProfileModel"></param>
        /// <returns></returns>
        [HttpPost("AddUserRoleProfile")]
        [Authorize(Roles = "AddToRole")]
        public async Task<ActionResult> AddUserRoleAsync([FromBody] UserProfileModel userProfileModel){
            if (userProfileModel == null)
                return BadRequest("The user profile model not be null!");
            var userProfileDto = new UserProfileDTO();
            var userId = User.FindFirst("UId").Value;
            var dateNow = DateTime.UtcNow;
            userProfileDto.Name = userProfileModel.Name;
            userProfileDto.Description = userProfileModel.Description;
            userProfileDto.Active = userProfileModel.Active;
            userProfileDto.CreatedAt = dateNow;
            userProfileDto.UpdatedAt = dateNow;
            userProfileDto.UserId = userId;
            await _userProfileService.CreateUserProfileAsync(userProfileDto);
            return Ok(userProfileDto);
            
        }
        /// <summary>
        /// Adds a user to a given rule from the "roleModel" properties.
        /// </summary>
        /// <param name="roleModel"></param>
        /// <returns></returns>
        [HttpPost("AddUserToRole")]
        [Authorize(Roles = "AddToRole")]
        public async Task<ActionResult> AddRole([FromBody] RoleModel roleModel)
        {
            var user = await _userService.GetUserByNameAsync(roleModel.UserName);
            var roleExists = await _roleService.RoleExistsAsync(roleModel.Role);
            if (roleExists)
            {
                if (user != null)
                {
                    var IsInRole = await _userService.IsInRoleAsync(user, roleModel.Role);
                    if (!IsInRole)
                    {
                        var result = await _userService.AddUserToRoleAsync(user, roleModel.Role);
                        if (result)
                        {
                            return Ok($"{roleModel.Role} added to the user {roleModel.UserName}");
                        }
                        return BadRequest($"Could not add role {roleModel.Role} for user {roleModel.UserName}.");
                    }
                    else
                    {
                        return Conflict($"User already has this role! UserName:{roleModel.UserName} RoleName:{roleModel.Role}");
                    }
                }
                return NotFound($@"No such user exists with name: {roleModel.UserName}");
            }
            return NotFound(@"The specified role does not exist in the system!");
        }
        /// <summary>
        /// Removes a user from a given rule from the "role" and "userName".
        /// </summary>
        /// <param name="role"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpDelete("RemoveUserToRole")]
        [Authorize(Roles = "RemoveFromRole")]
        public async Task<ActionResult> RemoveRole(string role, string userName)
        {
            var roleModel = new RoleModel(role, userName);
            var user = await _userService.GetUserByNameAsync(roleModel.UserName);
            var roleExists = await _roleService.RoleExistsAsync(roleModel.Role);
            if (roleExists)
            {
                if (user != null)
                {
                    var IsInRole = await _userService.IsInRoleAsync(user, roleModel.Role);
                    if (IsInRole)
                    {
                        var result = await _userService.RemoveFromRoleAsync(user, roleModel.Role);
                        if (result)
                        {
                            return Ok($"{roleModel.Role} removed to the user {roleModel.UserName}");
                        }
                        return BadRequest($"Could not remove role {roleModel.Role} for user {roleModel.UserName}.");
                    }
                    else
                    {
                        return Conflict($"User not in this role! UserName:{roleModel.UserName} RoleName:{roleModel.Role}");
                    }
                }
                return NotFound($@"No such user exists with name: {roleModel.UserName}");
            }
            return NotFound(@"The specified role does not exist in the system!");
        }
        /// <summary>
        /// Changes a user's full name from the "userFullNameModel" properties.
        /// </summary>
        /// <param name="userFullNameModel"></param>
        /// <returns></returns>
        [HttpPatch("UpdateUserFullName")]
        [Authorize(Roles = "EditUser")]
        public async Task<ActionResult> EditeUserFullName([FromBody] EditeUserFullNameModel userFullNameModel)
        {
            var user = await _userService.GetUserByIdAsync(userFullNameModel.Id.ToString());
            if (user != null)
            {
                user.FirstName = userFullNameModel.FirstName;
                user.LastName = userFullNameModel.LastName;
                var result = await _userService.UpdateUserAsync(user);
                if (result)
                {
                    return Ok(userFullNameModel);
                }
                return BadRequest("There was an error updating the username!");
                
            }
            return NotFound("User not found in de system!");
        }
        /// <summary>
        /// Changes the authenticated user's full name from the "myUserFullNameModel" properties.
        /// </summary>
        /// <param name="myUserFullNameModel"></param>
        /// <returns></returns>
        [HttpPatch("UpdateMyUserFullName")]
        [Authorize]
        public async Task<ActionResult> EditeMyUserFullName([FromBody] EditeMyUserFullNameModel myUserFullNameModel)
        {
            var userId = User.FindFirst("UId").Value;
            var user = await _userService.GetUserByIdAsync(userId);
            if (user != null)
            {
                user.FirstName = myUserFullNameModel.FirstName;
                user.LastName = myUserFullNameModel.LastName;
                var result = await _userService.UpdateUserAsync(user);
                if (result)
                {
                    return Ok(myUserFullNameModel);
                }
                return BadRequest("There was an error updating the username!");
                
            }
            return NotFound("User not found in de system!");
        }
        /// <summary>
        /// Change a user's password from the "passwordModel" properties.
        /// </summary>
        /// <param name="passwordModel"></param>
        /// <returns></returns>
        [HttpPatch("ResetUserPassword")]
        [Authorize(Roles = "EditUser")]
        public async Task<ActionResult> ResetUserPassword([FromBody] ResetPasswordModel passwordModel)
        {
            var user = await _userService.GetUserByIdAsync(passwordModel.Id.ToString());
            if (user != null)
            {
                var result = await _userService.UpdatePasswordHashAsync(user, passwordModel.Password);
                if (result)
                {
                    return Ok(user);
                }
                return BadRequest("There was an error updating the pasword!");
                
            }
            return NotFound("User not found in de system!");
        }
        /// <summary>
        /// Change the authenticated user's password from the "myPasswordModel" properties.
        /// </summary>
        /// <param name="myPasswordModel"></param>
        /// <returns></returns>
        [HttpPatch("ResetMyUserPassword")]
        [Authorize]
        public async Task<ActionResult> ResetMyUserPassword([FromBody] ResetMyPasswordModel myPasswordModel)
        {
            var userId = User.FindFirst("UId").Value;
            var user = await _userService.GetUserByIdAsync(userId);
            if (user != null)
            {
                var result = await _userService.UpdatePasswordHashAsync(user, myPasswordModel.Password);
                if (result)
                {
                    return Ok(user);
                }
                return BadRequest("There was an error updating the pasword!");
                
            }
            return NotFound("User not found in de system!");
        }
        /// <summary>
        /// Changes a user's username from the "userNameModel" properties.
        /// </summary>
        /// <param name="userNameModel"></param>
        /// <returns></returns>
        [HttpPatch("EditUserName")]
        [Authorize(Roles = "EditUser")]
        public async Task<ActionResult> EditeUserName([FromBody] EditUserNameModel userNameModel)
        {
            var user = await _userService.GetUserByIdAsync(userNameModel.Id.ToString());
            if (user != null)
            {
                user.UserName = userNameModel.Email;
                user.NormalizedUserName = userNameModel.Email.ToUpper();
                user.Email = userNameModel.Email;
                user.NormalizedEmail = userNameModel.Email.ToUpper();
                var result = await _userService.UpdateUserAsync(user);
                if (result)
                {
                    return Ok(userNameModel);
                }
                return BadRequest("There was an error updating the username!");
                
            }
            return NotFound("User not found in de system!");
        }
        /// <summary>
        /// Changes the authenticated user's username from the "myUserNameModel" properties.
        /// </summary>
        /// <param name="myUserNameModel"></param>
        /// <returns></returns>
        [HttpPatch("EditMyUserName")]
        [Authorize]
        public async Task<ActionResult> EditeMyUserName([FromBody] EditMyUserNameModel myUserNameModel)
        {
            var userId = User.FindFirst("UId").Value;
            var user = await _userService.GetUserByIdAsync(userId);
            if (user != null)
            {
                user.UserName = myUserNameModel.Email;
                user.NormalizedUserName = myUserNameModel.Email.ToUpper();
                user.Email = myUserNameModel.Email;
                user.NormalizedEmail = myUserNameModel.Email.ToUpper();
                var result = await _userService.UpdateUserAsync(user);
                if (result)
                {
                    return Ok(myUserNameModel);
                }
                return BadRequest("There was an error updating the username!");
                
            }
            return NotFound("User not found in de system!");
        }
    }
}
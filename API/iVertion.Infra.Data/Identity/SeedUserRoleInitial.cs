using iVertion.Domain.Account;
using iVertion.Infra.Data.Context;
using Microsoft.AspNetCore.Identity;
using System;

namespace iVertion.Infra.Data.Identity
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedUserRoleInitial(UserManager<ApplicationUser> userManager,
                                   RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public void SeedUsers()
        {
            if (_userManager.FindByEmailAsync("usuario@localhost").Result == null)
            {
                ApplicationUser user = new()
                {
                    FirstName = "User",
                    LastName = "",
                    UserName = "usuario@localhost",
                    Email = "usuario@localhost",
                    NormalizedUserName = "USUARIO@LOCALHOST",
                    NormalizedEmail = "USUARIO@LOCALHOST",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    IsEnabled = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserProfileId = 5
                };

                _userManager.CreateAsync(user, "MdRPgW/*-2023");

            }
            if (_userManager.FindByEmailAsync("admin@localhost").Result == null)
            {
                ApplicationUser user = new()
                {
                    FirstName = "Administrator",
                    LastName = "",
                    UserName = "admin@localhost",
                    Email = "admin@localhost",
                    NormalizedUserName = "ADMIN@LOCALHOST",
                    NormalizedEmail = "ADMIN@LOCALHOST",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    IsEnabled = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserProfileId = 1
                };

                IdentityResult result = _userManager.CreateAsync(user, "MdRPgW/*-2023").Result;


            }
            if (_userManager.FindByEmailAsync("totem.panel@localhost").Result == null)
            {
                ApplicationUser user = new()
                {
                    FirstName = "Totem",
                    LastName = "Panel",
                    UserName = "totem.panel@localhost",
                    Email = "totem.panel@localhost",
                    NormalizedUserName = "TOTEM.PANEL@LOCALHOST",
                    NormalizedEmail = "TOTEM.PANEL@LOCALHOST",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    IsEnabled = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserProfileId = 4
                };

                IdentityResult result = _userManager.CreateAsync(user, "MdRPgW/*-2023").Result;

            }

        }
        public void SeedRoles()
        {
            if (!_roleManager.RoleExistsAsync("GetUsers").Result)
            {
                IdentityRole role = new()
                {
                    Name = "GetUsers",
                    NormalizedName = "GETUSERS"
                };
                _ = _roleManager.CreateAsync(role).Result;
            }
            if (!_roleManager.RoleExistsAsync("AddUser").Result)
            {
                IdentityRole role = new()
                {
                    Name = "AddUser",
                    NormalizedName = "ADDUSER"
                };
                _ = _roleManager.CreateAsync(role).Result;
            }
            if (!_roleManager.RoleExistsAsync("EditUser").Result)
            {
                IdentityRole role = new()
                {
                    Name = "EditUser",
                    NormalizedName = "EDITUSER"
                };
                _ = _roleManager.CreateAsync(role).Result;
            }
            if (!_roleManager.RoleExistsAsync("RemoveUser").Result)
            {
                IdentityRole role = new()
                {
                    Name = "RemoveUser",
                    NormalizedName = "REMOVEUSER"
                };
                _ = _roleManager.CreateAsync(role).Result;
            }
            if (!_roleManager.RoleExistsAsync("AddToRole").Result)
            {
                IdentityRole role = new()
                {
                    Name = "AddToRole",
                    NormalizedName = "ADDTOROLE"
                };
                _ = _roleManager.CreateAsync(role).Result;
            }
            if (!_roleManager.RoleExistsAsync("RemoveFromRole").Result)
            {
                IdentityRole role = new()
                {
                    Name = "RemoveFromRole",
                    NormalizedName = "REMOVEFROMROLE"
                };
                _ = _roleManager.CreateAsync(role).Result;
            }
            if (!_roleManager.RoleExistsAsync("TotemPanel").Result)
            {
                IdentityRole role = new()
                {
                    Name = "TotemPanel",
                    NormalizedName = "TOTEMPANEL"
                };
                _ = _roleManager.CreateAsync(role).Result;
            }
            if (!_roleManager.RoleExistsAsync("AddArticle").Result)
            {
                IdentityRole role = new()
                {
                    Name = "AddArticle",
                    NormalizedName = "ADDARTICLE"
                };
                _ = _roleManager.CreateAsync(role).Result;
            }
            if (!_roleManager.RoleExistsAsync("EditArticle").Result)
            {
                IdentityRole role = new()
                {
                    Name = "EditArticle",
                    NormalizedName = "EDITARTICLE"
                };
                _ = _roleManager.CreateAsync(role).Result;
            }
            if (!_roleManager.RoleExistsAsync("RemoveArticle").Result)
            {
                IdentityRole role = new()
                {
                    Name = "RemoveArticle",
                    NormalizedName = "REMOVEARTICLE"
                };
                _ = _roleManager.CreateAsync(role).Result;
            }
            if (!_roleManager.RoleExistsAsync("Manager").Result)
            {
                IdentityRole role = new()
                {
                    Name = "Manager",
                    NormalizedName = "MANAGER"
                };
                _ = _roleManager.CreateAsync(role).Result;
            }
            if (!_roleManager.RoleExistsAsync("Dashboard").Result)
            {
                IdentityRole role = new()
                {
                    Name = "Dashboard",
                    NormalizedName = "DASHBOARD"
                };
                _ = _roleManager.CreateAsync(role).Result;
            }
            if (!_roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new()
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                };
                _ = _roleManager.CreateAsync(role).Result;
            }
            if (!_roleManager.RoleExistsAsync("Blogger").Result)
            {
                IdentityRole role = new()
                {
                    Name = "Blogger",
                    NormalizedName = "BLOGGER"
                };
                _ = _roleManager.CreateAsync(role).Result;
            }
            if (!_roleManager.RoleExistsAsync("Ticketer").Result)
            {
                IdentityRole role = new()
                {
                    Name = "Ticketer",
                    NormalizedName = "TICKETER"
                };
                _ = _roleManager.CreateAsync(role).Result;
            }
            if (!_roleManager.RoleExistsAsync("Traffic").Result)
            {
                IdentityRole role = new()
                {
                    Name = "Traffic",
                    NormalizedName = "TRAFFIC"
                };
                _ = _roleManager.CreateAsync(role).Result;
            }
            if (!_roleManager.RoleExistsAsync("Adsense").Result)
            {
                IdentityRole role = new()
                {
                    Name = "Adsense",
                    NormalizedName = "ADSENSE"
                };
                _ = _roleManager.CreateAsync(role).Result;
            }
            if (!_roleManager.RoleExistsAsync("ManagerArticles").Result)
            {
                IdentityRole role = new()
                {
                    Name = "ManagerArticles",
                    NormalizedName = "MANAGERARTICLES"
                };
                _ = _roleManager.CreateAsync(role).Result;
            }

        }


    }
}
using iVertion.Domain.Account;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace iVertion.Infra.Data.Identity
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _singInManager;
        public AuthenticateService(SignInManager<ApplicationUser> signInManager,
                                   UserManager<ApplicationUser> userManager)
        {
            _singInManager = signInManager;
            _userManager = userManager;
        }
        public async Task<bool> Authenticate(string email,
                                             string password)
        {
            var result = await _singInManager.PasswordSignInAsync(email,
                                                                  password,
                                                                  false,
                                                                  lockoutOnFailure: false);
            return result.Succeeded;
        }

        public async Task Logout()
        {
            await _singInManager.SignOutAsync();
        }

        public async Task<bool> RegisterUser(string email,
                                             string password,
                                             string firstName,
                                             string lastName,
                                             bool isEnabled,
                                             string? profilePicture,
                                             string? profileCover,
                                             string? profileDescription,
                                             string? occupation,
                                             DateTime? birthday,
                                             string? phoneNumber,
                                             int userProfileId)
        {
            ApplicationUser applicationUser = new()
            {
                FirstName = firstName,
                LastName = lastName,
                UserName = email,
                Email = email,
                IsEnabled = isEnabled,
                ProfilePicture = profilePicture,
                ProfileCover = profileCover,
                ProfileDescription = profileDescription,
                Occupation = occupation,
                Birthday = birthday,
                PhoneNumber = phoneNumber,
                UserProfileId = userProfileId
            };
            var result = await _userManager.CreateAsync(applicationUser, password);

            if (result.Succeeded)
            {
                await _singInManager.SignInAsync(applicationUser, isPersistent: false);
            }
            return result.Succeeded;
        }

    }
}
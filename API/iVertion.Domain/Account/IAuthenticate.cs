using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iVertion.Domain.Account
{
    public interface IAuthenticate
    {
        Task<bool> Authenticate(string email, string password);

        Task<bool> RegisterUser(
            string email,
            string password,
            string firstName,
            string lastName,
            bool isEnabled,
            string? profilePicture,
            string? profileCover,
            string? profileDescription,
            string? occupation,
            DateTime? birthday,
            string? phoneNumber
            );

        Task Logout();
    }
}
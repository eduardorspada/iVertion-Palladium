using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace iVertion.Infra.Data.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public bool IsEnabled { get; set; }
        
        [IgnoreDataMember]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public string? ProfilePicture { get; set; }
        public string? ProfileCover { get; set; }
        public string? ProfileDescription { get; set; }
        public string? Occupation { get; set; }
        public DateTime? Birthday { get; set; }
        public int UserProfileId { get; set; }

    }
}
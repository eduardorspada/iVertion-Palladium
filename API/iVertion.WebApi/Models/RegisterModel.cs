using System.ComponentModel.DataAnnotations;

namespace iVertion.WebApi.Models
{
    public class RegisterModel
    {

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        public string ConfirmPassword { get; set;}
        [Required]
        public bool IsEnabled { get; set; }

        public string? ProfilePicture { get; set; }
        public string? ProfileCover { get; set; }
        public string? ProfileDescription { get; set; }
        public string? Occupation { get; set; }
        public DateTime? Birthday { get; set; }
        public string? PhoneNumber { get; set; }
        public int UserProfileId { get; set; }
    }
}
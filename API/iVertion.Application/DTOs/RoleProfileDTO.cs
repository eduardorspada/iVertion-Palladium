using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace iVertion.Application.DTOs
{
    public class RoleProfileDTO : BaseDTO
    {
        [Required(ErrorMessage = "Role is required.")]
        [MinLength(5)]
        [MaxLength(25)]
        [DisplayName("Role")]
        public string? Role { get; set; }
        [Required(ErrorMessage = "User Profile Id is required.")]
        [DisplayName("User Profile Id")]
        public int UserProfileId { get; set; }
        
    }
}
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace iVertion.Application.DTOs
{
    public class AddtionalUserRoleDTO : BaseDTO
    {
        [Required(ErrorMessage = "Role is required.")]
        [MinLength(5)]
        [MaxLength(25)]
        [DisplayName("Role")]
        public string? Role { get; set; }
    }
}
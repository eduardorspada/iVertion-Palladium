using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace iVertion.Application.DTOs
{
    public sealed class UserProfileDTO : BaseDTO
    {
        [Required(ErrorMessage = "Name is required.")]
        [MinLength(5)]
        [MaxLength(25)]
        [DisplayName("Name")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        [MinLength(5)]
        [MaxLength(150)]
        [DisplayName("Description")]
        public string? Description { get; set; }
    }
}
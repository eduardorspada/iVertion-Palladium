using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace iVertion.Application.DTOs
{
    public sealed class ClientTypeDTO : BaseDTO
    {
        [Required(ErrorMessage = "Acronym is required.")]
        [MinLength(1)]
        [MaxLength(1)]
        [DisplayName("Acronym")]
        public string? Acronym{ get; set; }
        [Required(ErrorMessage = "Description is required.")]
        [MinLength(3)]
        [MaxLength(45)]
        [DisplayName("Description")]
        public string? Description { get; set; }
    }
}
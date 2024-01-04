using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace iVertion.Application.DTOs
{
    public sealed class MerchandisingDTO : BaseDTO
    {
        [Required(ErrorMessage = "Name is required.")]
        [MinLength(5)]
        [MaxLength(45)]
        [DisplayName("Name")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        [MinLength(5)]
        [MaxLength(250)]
        [DisplayName("Description")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Image is required.")]
        [MinLength(5)]
        [MaxLength(250)]
        [DisplayName("Image")]
        public string? Image { get; set; }
        public PanelMerchandisingDTO? PanelMerchandising { get; set; }
    }
}
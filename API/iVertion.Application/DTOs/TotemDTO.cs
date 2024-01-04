using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace iVertion.Application.DTOs
{
    public sealed class TotemDTO : BaseDTO
    {
        [Required(ErrorMessage = "Acronym is required.")]
        [MinLength(1)]
        [MaxLength(5)]
        [DisplayName("Acronym")]
        public string? Acronym{ get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [MinLength(5)]
        [MaxLength(45)]
        [DisplayName("Name")]
        public string? Name { get; set; }
        public IEnumerable<TotemPanelDTO>? TotemPanels { get; set; }
    }
}
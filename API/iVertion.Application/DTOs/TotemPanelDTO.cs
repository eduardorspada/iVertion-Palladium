using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace iVertion.Application.DTOs
{
    public class TotemPanelDTO
    {
        [Required(ErrorMessage = "Totem Id is required.")]
        [DisplayName("Totem Id")]
        public int TotemId { get; private set; }
        public IEnumerable<TotemDTO>? Totems { get; set; }
        [Required(ErrorMessage = "Panel Id is required.")]
        [DisplayName("Panel Id")]
        public int PanelId { get; set; }
        public IEnumerable<PanelDTO>? Panels { get; private set; }
    }
}
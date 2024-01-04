using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace iVertion.Application.DTOs
{
    public class PanelMerchandisingDTO
    {
        [Required(ErrorMessage = "Merchandising Id is required.")]
        [DisplayName("Merchandising Id")]
        public int MerchandisingId { get; private set; }
        public IEnumerable<MerchandisingDTO>? Merchandisings { get; set; }
        [Required(ErrorMessage = "Panel Id is required.")]
        [DisplayName("Panel Id")]
        public int PanelId { get; set; }
        public IEnumerable<PanelDTO>? Panels { get; private set; }
    }
}
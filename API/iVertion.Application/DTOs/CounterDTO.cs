using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace iVertion.Application.DTOs
{
    public sealed class CounterDTO : BaseDTO
    {
        [Required(ErrorMessage = "Name is required.")]
        [MinLength(1)]
        [MaxLength(5)]
        [DisplayName("Name")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Panel Id is required.")]
        [DisplayName("Panel Id")]
        public int PanelId { get; set; }
        public PanelDTO? Panel { get; set; }
        public IEnumerable<TicketDTO>? Tickets { get; set; }
    }
}
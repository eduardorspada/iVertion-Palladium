using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace iVertion.Application.DTOs
{
    public sealed class TicketSubjectDTO : BaseDTO
    {
        [Required(ErrorMessage = "Name is required.")]
        [MinLength(1)]
        [MaxLength(45)]
        [DisplayName("Name")]
        public string? Name { get; set; }
        public IEnumerable<TicketFollowUpDTO>? TicketFollowUps { get; set; }
    }
}
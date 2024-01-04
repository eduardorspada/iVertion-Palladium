using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace iVertion.Application.DTOs
{
    public sealed class TicketFollowUpDTO : BaseDTO
    {
        [Required(ErrorMessage = "Description is required.")]
        [MinLength(5)]
        [MaxLength(250)]
        [DisplayName("Description")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Ticket Id is required.")]
        [DisplayName("Ticket Id")]
        public int TicketId { get; set; }
        public TicketDTO? Ticket { get; set; }
        [Required(ErrorMessage = "Ticket Subject Id is required.")]
        [DisplayName("Ticket Subject Id")]
        public int TicketSubjectId { get; set; }
        public TicketSubjectDTO? TicketSubject { get; set; }
    }
}
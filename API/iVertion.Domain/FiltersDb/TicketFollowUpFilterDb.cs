using System;
using iVertion.Domain.Interfaces;

namespace iVertion.Domain.FiltersDb
{
    public class TicketFollowUpFilterDb : PagedBaseRequest
    {
        public string? Description { get; set; }
        public int? TicketId { get; set; }
        public int? TicketSubjectId { get; set; }
        public bool? Active { get; set; }
        public string? UserId { get; set; }
        public DateTime? StartDateFilter { get; set; }
        public DateTime? EndDateFilter { get; set; }
    }
}
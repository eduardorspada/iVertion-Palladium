using iVertion.Domain.Interfaces;

namespace iVertion.Domain.FiltersDb
{
    public abstract class TicketPanelFilterDb : PagedBaseRequest
    {
        public string? Acronym { get; set; }
        public bool? Active { get; set; }
        public string? UserId { get; set; }
    }
}
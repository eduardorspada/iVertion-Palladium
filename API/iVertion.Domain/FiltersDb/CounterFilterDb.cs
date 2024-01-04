using iVertion.Domain.Interfaces;

namespace iVertion.Domain.FiltersDb
{
    public class CounterFilterDb : PagedBaseRequest
    {
        public string? Name { get; private set; }
        public int? PanelId { get; private set; }
        public bool? Active { get; set; }
        public string? UserId { get; set; }
    }
}
using iVertion.Domain.Interfaces;

namespace iVertion.Domain.FiltersDb
{
    public class TotemPanelFilterDb : PagedBaseRequest
    {
        public int? TotemId { get; set; }
        public int? PanelId { get; set; }
    }
}
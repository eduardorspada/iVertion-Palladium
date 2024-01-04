using iVertion.Domain.Interfaces;

namespace iVertion.Domain.FiltersDb
{
    public class PanelMerchandisingFilterDb : PagedBaseRequest
    {
        public int? PanelId { get; set; }
        public int? MerchandisingId { get; set; }
    }
}
using System;
using iVertion.Domain.Interfaces;

namespace iVertion.Domain.FiltersDb
{
    public class MerchandisingFilterDb : PagedBaseRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool? Active { get; set; }
        public string? UserId { get; set; }
        public int? PanelId { get; set; }
        public DateTime? StartDateFilter { get; set; }
        public DateTime? EndDateFilter { get; set; }
    }
}
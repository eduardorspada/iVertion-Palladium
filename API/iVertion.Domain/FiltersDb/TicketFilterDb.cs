using System;

namespace iVertion.Domain.FiltersDb
{
    public sealed class TicketFilterDb : TicketPanelFilterDb
    {
        public int? Sequential { get; set; }
        public string? ContractNumber { get; set; }
        public string? AttendantName { get; set; }
        public int? PanelId { get; set; }
        public int? PreferenceTypeId { get; set; }
        public int? ServiceTypeId { get; set; }
        public int? ClientTypeId { get; set; }
        public DateTime? StartDateFilter { get; set; }
        public DateTime? EndDateFilter { get; set; }
    }
}
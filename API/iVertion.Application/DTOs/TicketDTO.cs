using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace iVertion.Application.DTOs
{
    public sealed class TicketDTO : BaseDTO
    {
        [Required(ErrorMessage = "Acronym is required.")]
        [MinLength(1)]
        [MaxLength(3)]
        [DisplayName("Acronym")]
        public string? Acronym{ get; set; }
        [Required(ErrorMessage = "Sequential is required.")]
        [DisplayName("Sequential")]
        public int Sequential { get; set; }
        [DisplayName("StartOfService")]
        public DateTime? StartOfService { get; set; }
        [DisplayName("EndOfService")]
        public DateTime? EndOfService { get; set; }
        [Required(ErrorMessage = "ContractNumber is required.")]
        [MinLength(3)]
        [MaxLength(18)]
        [DisplayName("ContractNumber")]
        public string? ContractNumber{ get; set; }
        [Required(ErrorMessage = "AttendantName is required.")]
        [MinLength(3)]
        [MaxLength(150)]
        [DisplayName("AttendantName")]
        public string? AttendantName{ get; set; }
        [Required(ErrorMessage = "Panel Id is required.")]
        [DisplayName("Panel Id")]
        public int PanelId { get; set; }
        public PanelDTO? Panel { get; set; }
        [DisplayName("PreferenceType Id")]
        public int PreferenceTypeId { get; set; }
        public PreferenceTypeDTO? PreferenceType { get; set; }
        [DisplayName("ServiceType Id")]
        public int ServiceTypeId { get; set; }
        public ServiceTypeDTO? ServiceType { get; set; }
        [DisplayName("ClientType Id")]
        public int ClientTypeId { get; set; }
        public ClientTypeDTO? ClientType { get; set; }
        [DisplayName("Counter Id")]
        public int CounterId { get; set; }
        public CounterDTO? Counter { get; set; }
        public IEnumerable<TicketFollowUpDTO>? TicketFollowUps { get; set; }
    }
}
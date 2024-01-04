using System;
using System.Collections.Generic;
using iVertion.Domain.Validation;

namespace iVertion.Domain.Entities
{
    public sealed class Ticket : Entity
    {
        public string? Acronym { get; private set; }
        public int Sequential { get; private set; }
        public DateTime? StartOfService { get; private set; }
        public DateTime? EndOfService { get; private set; }
        public string? ContractNumber { get; private set; }
        public string? AttendantName { get; private set; }
        public int PanelId { get; private set; }
        public Panel? Panel { get; set; }
        public int PreferenceTypeId { get; private set; }
        public PreferenceType? PreferenceType { get; set; }
        public int ServiceTypeId { get; private set; }
        public ServiceType? ServiceType { get; set; }
        public int ClientTypeId { get; private set; }
        public ClientType? ClientType { get; set; }
        public int? CounterId { get; private set; }
        public Counter? Counter { get; set; }
        public IEnumerable<TicketFollowUp>? TicketFollowUps { get; set; }

        public Ticket(string acronym,
                      int sequential,
                      string? contractNumber,
                      string? attendantName,
                      int panelId,
                      int preferenceTypeId,
                      int serviceTypeId,
                      int clientTypeId,
                      int? counterId,
                      bool active)
        {
            ValidationDomain(acronym,
                             sequential,
                             contractNumber,
                             attendantName,
                             panelId,
                             preferenceTypeId,
                             serviceTypeId,
                             clientTypeId,
                             counterId);
            Active = active;
        }
        public Ticket(int id,
                      string acronym,
                      int sequential,
                      string? contractNumber,
                      string? attendantName,
                      int panelId,
                      int preferenceTypeId,
                      int serviceTypeId,
                      int clientTypeId,
                      int? counterId,
                      bool active)
        {
            DomainExceptionValidation.When(id <= 0,
                                "Invalid Id, must be up to zero.");
            ValidationDomain(acronym,
                             sequential,
                             contractNumber,
                             attendantName,
                             panelId,
                             preferenceTypeId,
                             serviceTypeId,
                             clientTypeId,
                             counterId);
            Active = active;
            Id = id;
        }
        public void Update(string acronym,
                           int sequential,
                           string? contractNumber,
                           string? attendantName,
                           int panelId,
                           int preferenceTypeId,
                           int serviceTypeId,
                           int clientTypeId,
                           int? counterId,
                           bool active)
        {
            ValidationDomain(acronym,
                             sequential,
                             contractNumber,
                             attendantName,
                             panelId,
                             preferenceTypeId,
                             serviceTypeId,
                             clientTypeId,
                             counterId);
            Active = active;
        }

        private void ValidationDomain(string acronym,
                                      int sequential,
                                      string? contractNumber,
                                      string? attendantName,
                                      int panelId,
                                      int preferenceTypeId,
                                      int serviceTypeId,
                                      int clientTypeId,
                                      int? counterId)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(acronym),
                                           "Invalid Name, must not be null or empity.");
            DomainExceptionValidation.When(acronym.Length < 1,
                                           "Invalid Name, too short, must be 1 or more characters.");
            DomainExceptionValidation.When(acronym.Length > 3,
                                           "Invalid Name, too long, must be up to 3 characters.");
            DomainExceptionValidation.When(sequential <= 0,
                                           "Invalid Sequential, must be up to zero.");
            if (contractNumber != null)
            {
                DomainExceptionValidation.When(contractNumber.Length < 3,
                                            "Invalid Contract Number, too short, must be 3 or more characters.");
                DomainExceptionValidation.When(contractNumber.Length > 18,
                                            "Invalid Contract Number, too long, must be up to 18 characters.");
            }
            if (attendantName != null)
            {
                DomainExceptionValidation.When(attendantName.Length < 3,
                                            "Invalid Attendant Name, too short, must be 3 or more characters.");
                DomainExceptionValidation.When(attendantName.Length > 150,
                                            "Invalid Attendant Name, too long, must be up to 150 characters.");
            }
            DomainExceptionValidation.When(panelId <= 0,
                                           "Invalid Panel Id, must be up to zero.");
            DomainExceptionValidation.When(preferenceTypeId <= 0,
                                           "Invalid Preference Type Id, must be up to zero.");
            DomainExceptionValidation.When(serviceTypeId <= 0,
                                           "Invalid Service Type Id, must be up to zero.");
            DomainExceptionValidation.When(clientTypeId <= 0,
                                           "Invalid Client Type Id, must be up to zero.");
            if (counterId != null)
            {
                DomainExceptionValidation.When(counterId <= 0,
                                            "Invalid Counter Id, must be up to zero.");
            }
            Acronym = acronym;
            Sequential = sequential;
            ContractNumber = contractNumber;
            AttendantName = attendantName;
            PanelId = panelId;
            PreferenceTypeId = preferenceTypeId;
            ServiceTypeId = serviceTypeId;
            ClientTypeId = clientTypeId;
            CounterId = counterId;
        }
    }
}
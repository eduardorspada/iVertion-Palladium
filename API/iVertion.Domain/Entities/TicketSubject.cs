using System.Collections.Generic;
using iVertion.Domain.Validation;

namespace iVertion.Domain.Entities
{
    public sealed class TicketSubject : Entity
    {
        public string? Name { get; private set; }
        public IEnumerable<TicketFollowUp>? TicketFollowUps { get; set; }
        public TicketSubject(string name,
                             bool active)
        {
            ValidationDomain(name);
            Active = active;
        }
        public TicketSubject(int id,
                             string name,
                             bool active)
        {
            DomainExceptionValidation.When(id <= 0,
                                           "Invalid Id, must be up to zero.");
            ValidationDomain(name);
            Active = active;
            Id = id;
        }
        public void Update(string name, 
                           bool active)
        {
            ValidationDomain(name);
            Active = active;
        }

        private void ValidationDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                                           "Invalid Name, must not be null or empty.");
            DomainExceptionValidation.When(name.Length < 5,
                                           "Invalid Name, too short, must be 5 character.");
            DomainExceptionValidation.When(name.Length > 45,
                                           "Invalid Name, too long, must be 5 character.");
            Name = name;
        }
    }
}
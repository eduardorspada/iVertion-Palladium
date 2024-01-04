using System.Collections.Generic;
using iVertion.Domain.Validation;

namespace iVertion.Domain.Entities
{
    public sealed class Counter : Entity
    {
        public string? Name { get; private set; }
        public int PanelId { get; private set; }
        public Panel? Panel { get; set; }
        public IEnumerable<Ticket>? Tickets { get; set; }

        public Counter(string name,
                       int panelId,
                       bool active)
        {
            ValidationDomain(name,
                             panelId);
            Active = active;
        }
        public Counter(int id,
                       string name,
                       int panelId,
                       bool active)
        {
            DomainExceptionValidation.When(id <= 0,
                                           "Invalid Id, must be up to zero.");
            ValidationDomain(name,
                             panelId);
            Id = id;
            Active = active;
        }
        public void Update(string name,
                           int panelId,
                           bool active)
        {
            ValidationDomain(name,
                             panelId);
            Active = active;
        }

        private void ValidationDomain(string name,
                                      int panelId)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                                           "Invalid Name, must not be null or empty.");
            DomainExceptionValidation.When(name.Length > 5,
                                           "Invalid Name, too long, must be up to 5 character.");
            DomainExceptionValidation.When(panelId <= 0,
                                           "Invalid Panel Id, must be up to zero.");
            Name = name;
            PanelId = panelId;
        }
    }
}
using System.Collections.Generic;
using iVertion.Domain.Validation;

namespace iVertion.Domain.Entities
{
    public sealed class PreferenceType : Entity
    {
        public string? Acronym { get; private set; }
        public string? Description { get; private set; }
        public IEnumerable<Ticket>? Tickets { get; set; }

        public PreferenceType(string acronym,
                              string description,
                              bool active)
        {
            ValidationDomain(acronym,
                             description);
            Active = active;
        }
        public PreferenceType(int id,
                              string acronym,
                              string description,
                              bool active)
        {
            DomainExceptionValidation.When(id <= 0,
                                           "Invalid Id, must be up to zero.");
            ValidationDomain(acronym,
                             description);
            Active = active;
            Id = id;
        }
        public void Update(string acronym,
                           string description,
                           bool active)
        {
            ValidationDomain(acronym,
                             description);
            Active = active;
        }

        private void ValidationDomain(string acronym,
                                      string description)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(acronym),
                                           "Invalid Acronym, must not be null or empty.");
            DomainExceptionValidation.When(acronym.Length < 1 || acronym.Length > 1,
                                           "Invalid Acronym, length must be one character.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                                           "Invalid Description, must not be null or empty.");
            DomainExceptionValidation.When(description.Length < 3,
                                           "Invalid Description, too short, must be at least 3 characters long.");
            DomainExceptionValidation.When(description.Length > 45,
                                           "Invalid Description, too long, must be 45 characters or less.");
            Acronym = acronym;
            Description = description;        
        }
    }
}
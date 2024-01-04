using System.Collections.Generic;
using iVertion.Domain.Validation;

namespace iVertion.Domain.Entities
{
    public sealed class Totem : Entity
    {
        public string? Acronym { get; private set; }
        public string? Name { get; private set; }
        public IEnumerable<TotemPanel>? TotemPanels { get; set; }

        public Totem(string acronym,
                     string name,
                     bool active)
        {
            ValidationDomain(acronym,
                             name);
            Active = active;
        }
        public Totem(int id,
                     string acronym,
                     string name,
                     bool active)
        {
            DomainExceptionValidation.When(id <= 0,
                                           "Invalid Id, must be up to zero.");
            ValidationDomain(acronym,
                             name);
            Id = id;                             
            Active = active;
        }
        public void Update(string acronym,
                           string name,
                           bool active)
        {
            ValidationDomain(acronym,
                             name);
            Active = active;
        }

        private void ValidationDomain(string acronym, string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(acronym),
                                           "Invalid Acronym, must not be empty or null.");
            DomainExceptionValidation.When(acronym.Length <= 1 ,
                                           "Invalid Acronym, too short, must be longer than 1 character.");
            DomainExceptionValidation.When(acronym.Length > 5 ,
                                           "Invalid Acronym, too long, must be up to 5 character.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                                           "Invalid Name, must not be empty or null.");
            DomainExceptionValidation.When(name.Length <= 5 ,
                                           "Invalid Name, too short, must be longer than 5 character.");
            DomainExceptionValidation.When(name.Length > 45 ,
                                           "Invalid Name, too long, must be up to 45 character.");

            Acronym = acronym;
            Name    = name;
        }
    }
}
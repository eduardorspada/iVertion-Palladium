

using iVertion.Domain.Validation;

namespace iVertion.Domain.Entities
{
    public sealed class UserProfile : Entity
    {
        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public IEnumerable<RoleProfile>? RoleProfiles { get; set; }

        public UserProfile(string name,
                           string description,
                           bool active)
        {
            ValidationDomain(name,
                             description);
            Active = active;
        }
        public UserProfile(int id,
                           string name,
                           string description,
                           bool active)
        {
            DomainExceptionValidation.When(id < 0,
                                           "Invalid Id, must be up to zero.");
            ValidationDomain(name,
                             description);
            Id = id;
            Active = active;
        }
        public void Update(string name,
                           string description,
                           bool active)
        {
            ValidationDomain(name,
                             description);
            Active = active;
        }

        private void ValidationDomain(string name,
                                      string description)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                                           "Invalid Name, must not be null or empty.");
            DomainExceptionValidation.When(name.Length < 5,
                                           "Invalid Name, too short, must be at least 5 characters long.");
            DomainExceptionValidation.When(name.Length > 25,
                                           "Invalid Name, too long, max 25 characters.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                                           "Invalid Description, must not be null or empty.");
            DomainExceptionValidation.When(description.Length < 5,
                                           "Invalid Description, too short, must be at least 5 characters long.");
            DomainExceptionValidation.When(description.Length > 150,
                                           "Invalid Description, too long, max 150 characters.");

            Name = name;
            Description = description;
        }
    }
}
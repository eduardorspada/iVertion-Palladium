using iVertion.Domain.Validation;

namespace iVertion.Domain.Entities
{
    public sealed class AdditionalUserRole : Entity
    {
        public string? Role { get; private set; }
        public string? TargetUserId { get; private set; }

        public AdditionalUserRole(string role,
                                  string targetUserId,
                                  bool active)
        {
            ValidationDomain(role,
                             targetUserId);
            Active = active;
        }
        public AdditionalUserRole(int id,
                                  string role,
                                  string targetUserId,
                                  bool active)
        {
            DomainExceptionValidation.When(id < 0,
                                           "Invalid Id, must be up to zero.");
            ValidationDomain(role,
                             targetUserId);
            Id = id;
            Active = active;
        }
        public void Update(string role,
                           string targetUserId,
                           bool active)
        {
            ValidationDomain(role,
                             targetUserId);
            Active = active;
        }

        private void ValidationDomain(string role,
                                      string targetUserId)
        {
            DomainExceptionValidation.When(String.IsNullOrEmpty(role),
                                           "Role must not be null or empty!");
            DomainExceptionValidation.When(role.Length < 5,
                                           "Invalid Role, too short, minimum 5 characters!");
            DomainExceptionValidation.When(role.Length > 25,
                                           "Invalid Role, too long, max 150 characters!");
            DomainExceptionValidation.When(String.IsNullOrEmpty(targetUserId),
                                           "Target User Id must not be null or empty!");
            
            Role = role;
            TargetUserId = targetUserId;
        }
    }
}
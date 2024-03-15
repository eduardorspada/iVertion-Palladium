
using iVertion.Domain.Validation;

namespace iVertion.Domain.Entities
{
    public sealed class TemporaryUserRole : Entity
    {
        public string? Role { get; private set; }
        public string? TargetUserId { get; private set; }
        public DateTime? ExpirationDate { get; private set; }

        private void ValidationDomain(string role,
                                      string targetUserId,
                                      DateTime? expirationDate)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(role),
                                           "Invalid Role, must not be null or empty.");
            DomainExceptionValidation.When(role.Length < 5,
                                           "Invalid Role, too short, must be at least 5 characters long.");
            DomainExceptionValidation.When(role.Length > 25,
                                           "Invalid Role, too long, max 25 characters.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(targetUserId),
                                           "Invalid Target User Id, must not be null or empty.");
            DomainExceptionValidation.When(expirationDate > DateTime.Now,
                                           "Invalid Expiration Date, must be greater than the current date.");

            Role = role;
            TargetUserId = targetUserId;
            ExpirationDate = expirationDate;
            
        }
    }
}
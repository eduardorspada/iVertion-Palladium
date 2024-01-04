using iVertion.Domain.Validation;

namespace iVertion.Domain.Entities
{
    public sealed class RoleProfile : Entity
    {
        public string? Role { get; private set; }
        public int UserProfileId { get; private set; }
        public UserProfile? UserProfile { get; set; }

        public RoleProfile(string role,
                           int userProfileId,
                           bool active)
        {
            ValidationDomain(role,
                             userProfileId);
            
            Active = active;
        }
        public RoleProfile(int id,
                           string role,
                           int userProfileId,
                           bool active)
        {
            DomainExceptionValidation.When(id < 0,
                                "Invalid Id, must be up to zero.");
            ValidationDomain(role,
                             userProfileId);
            Id = id;
            Active = active;
        }
        public void Update(string role,
                           int userProfileId,
                           bool active)
        {
            ValidationDomain(role,
                             userProfileId);
            
            Active = active;
        }

        private void ValidationDomain(string role,
                                      int userProfileId)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(role),
                                           "Invalid Role, must not be null or empty.");
            DomainExceptionValidation.When(role.Length < 5,
                                           "Invalid Role, too short, must be at least 5 characters long.");
            DomainExceptionValidation.When(role.Length > 25,
                                           "Invalid Role, too long, max 25 characters.");
            DomainExceptionValidation.When(userProfileId <= 0,
                                           "Invalid UserProfileId Id, must be up to zero.");
            
            Role = role;
            UserProfileId = userProfileId;
        }
    }
}
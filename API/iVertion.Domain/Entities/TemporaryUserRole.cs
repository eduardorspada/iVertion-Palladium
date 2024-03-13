
namespace iVertion.Domain.Entities
{
    public sealed class TemporaryUserRole : Entity
    {
        public string? Role { get; private set; }
        public string? TargetUserId { get; private set; }
        public DateTime? ExpirationDate { get; private set; }
    }
}
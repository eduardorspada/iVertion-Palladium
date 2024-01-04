using iVertion.Domain.Interfaces;

namespace iVertion.Domain.FiltersDb
{
    public class RoleProfileFilterDb  : PagedBaseRequest
    {
        public string? Role { get; set; }
        public int? UserProfileId { get; set; }
        public string? UserId { get; set; }
    }
}
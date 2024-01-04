using iVertion.Domain.Interfaces;

namespace iVertion.Domain.FiltersDb
{
    public class AddtionalUserRoleFilterDb : PagedBaseRequest
    {
        public string? Role { get; set; }
        public string? TargetUserId { get; set; }
        public string? UserId { get; set; }
    }
}
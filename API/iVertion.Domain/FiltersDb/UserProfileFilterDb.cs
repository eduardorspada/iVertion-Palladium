using iVertion.Domain.Interfaces;

namespace iVertion.Domain.FiltersDb
{
    public class UserProfileFilterDb : PagedBaseRequest
    {
        public string? Name { get; set; }
        public bool? Active { get; set; }
        public string? UserId { get; set; }
    }
}
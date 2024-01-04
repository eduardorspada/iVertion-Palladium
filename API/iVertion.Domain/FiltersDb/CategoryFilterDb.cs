using iVertion.Domain.Interfaces;

namespace iVertion.Domain.FiltersDb
{
    public class CategoryFilterDb : PagedBaseRequest
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool? Active { get; set; }
        public string? UserId { get; set; }
    }
}
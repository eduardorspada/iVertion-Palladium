using iVertion.Domain.Interfaces;

namespace iVertion.Domain.FiltersDb
{
    public class ArticleFilterDb : PagedBaseRequest
    {
        public string? Title { get; set; }
        public bool? Active { get; set; }
        public int? CategoryId { get; set; }
        public string? UserId { get; set; }
    }
}
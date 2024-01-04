using iVertion.Domain.Interfaces;

namespace iVertion.Domain.FiltersDb
{
    public class ArticleHistoryFilterDb : PagedBaseRequest
    {
        public string? Title { get; set; }
        public bool? Active { get; set; }
        public int? ArticleId { get; set; }
        public string? UserId { get; set; }
    }
}
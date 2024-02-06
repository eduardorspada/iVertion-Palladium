namespace iVertion.Domain.Interfaces
{
    public class PagedBaseRequest
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string  OrderByProperty { get; set; }
        public string? Sort { get; set; }
        public PagedBaseRequest()
        {
            Page = 1;
            PageSize = 20;
            OrderByProperty = "Id";
            Sort = null;
        }
    }
}
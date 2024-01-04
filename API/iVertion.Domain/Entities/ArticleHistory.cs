using iVertion.Domain.Validation;

namespace iVertion.Domain.Entities
{
    public sealed class ArticleHistory : EntityHistory
    {
        public string? Title { get; private set; }
        public string? Description { get; private set; }
        public string? Author { get; private set; }
        public int CategoryId { get; private set; }
        public int ArticleId { get; private set; }
        public Article? Article { get; set; }

        public ArticleHistory(string title,
                              string description,
                              string author,
                              int categoryId,
                              int articleId,
                              bool active)
        {
            ValidationDomain(title,
                             description,
                             categoryId,
                             articleId);
            Active = active;
            Author = author;
        }
        public ArticleHistory(int id,
                              string title,
                              string description,
                              string author,
                              int categoryId,
                              int articleId,
                              bool active)
        {
            DomainExceptionValidation.When(id < 0,
                                           "Invalid Id, must be up to zero.");
            ValidationDomain(title,
                             description,
                             categoryId,
                             articleId);
            Id = id;
            Active = active;
            Author = author;
        }
        public void Update(string title,
                           string description,
                           string author,
                           int categoryId,
                           int articleId,
                           bool active)
        {
            ValidationDomain(title,
                             description,
                             categoryId,
                             articleId);
            Active = active;
            Author = author;
        }

        private void ValidationDomain(string title,
                                      string description,
                                      int categoryId,
                                      int articleId)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(title),
                                           "Invalid Title, must not be empty or null.");
            DomainExceptionValidation.When(title.Length < 5,
                                           "Invalid Title, too short, minimum 5 characters.");
            DomainExceptionValidation.When(title.Length > 150,
                                           "Invalid Title, too long, max 150 characters.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                                           "Invalid Description, must not be empty or null.");
            DomainExceptionValidation.When(description.Length < 5,
                                           "Invalid Description, too short, minimum 5 characters.");
            DomainExceptionValidation.When(description.Length > 25000,
                                           "Invalid Description, too long, max 25000 characters.");
            DomainExceptionValidation.When(categoryId <= 0,
                                           "Invalid Category Id, must be up to zero.");
            DomainExceptionValidation.When(articleId <= 0,
                                           "Invalid Article Id, must be up to zero.");
            Title = title;
            Description = description;
            CategoryId = categoryId;
            ArticleId = articleId;
        }
    }
}
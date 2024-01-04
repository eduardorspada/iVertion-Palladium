using iVertion.Domain.Validation;

namespace iVertion.Domain.Entities
{
    public sealed class Comment : Entity
    {
        public string? Name { get; private set; }
        public string? Body { get; private set; }
        public bool Read { get; private set; }
        public int ArticleId { get; private set; }
        public Article? Article { get; set; }

        public Comment(string name,
                       string body,
                       bool read,
                       int articleId,
                       bool active)
        {
            ValidationDomain(name,
                             body,
                             articleId);
            Read = read;
            Active = active;

        }
        public Comment(int id,
                       string name,
                       string body,
                       bool read,
                       int articleId,
                       bool active)
        {
            DomainExceptionValidation.When(id <= 0,
                                           "Invalid Id, must be up to zero.");
            ValidationDomain(name,
                             body,
                             articleId);
            Id = id;
            Read = read;
            Active = active;

        }
        public void Update(string name,
                           string body,
                           bool read,
                           int articleId,
                           bool active)
        {
            ValidationDomain(name,
                             body,
                             articleId);
            Read = read;
            Active = active;

        }

        private void ValidationDomain(string name,
                                      string body,
                                      int articleId)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                                           "Invalid Name, must not be empty or null.");
            DomainExceptionValidation.When(name.Length < 3,
                                           "Invalid Name, to short, minimum 3 characters.");
            DomainExceptionValidation.When(name.Length > 500,
                                           "Invalid Name, to long, max 500 characters.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(body),
                                           "Invalid Body, must not be empty or null.");
            DomainExceptionValidation.When(body.Length < 3,
                                           "Invalid Body, to short, minimum 3 characters.");
            DomainExceptionValidation.When(body.Length > 2000,
                                           "Invalid Body, to long, max 2000 characters.");
            DomainExceptionValidation.When(articleId <= 0,
                                           "Invalid Article Id, must be up to zero.");

            Name = name;
            Body = body;
            ArticleId = articleId;
        }
    }
}
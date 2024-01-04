using iVertion.Domain.Validation;

namespace iVertion.Domain.Entities
{
    public class CategoryHistory : EntityHistory
    {
        public string? Title { get; private set; }
        public string? Description { get; private set; }
        public int CategoryId { get; private set; }
        public Category? Category { get; set; }
        public CategoryHistory(string title,
                               string description,
                               int categoryId,
                               bool active)
        {
            ValidationDomain(title,
                             description,
                             categoryId); 
            Active = active;
        }
        public CategoryHistory(int id,
                               string title,
                               string description,
                               int categoryId,
                               bool active)
        {
            DomainExceptionValidation.When(id <= 0,
                                           "Invalid Id, must be up to zero.");
            ValidationDomain(title,
                             description,
                             categoryId);
            Id = id;  
            Active = active;
        }
        public void Update(string title,
                           string description,
                           int categoryId,
                           bool active)
        {
            ValidationDomain(title,
                             description,
                             categoryId);  
            Active = active;
        }

        private void ValidationDomain(string title,
                                      string description,
                                      int categoryId)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(title),
                                           "Invalid Title, must not be empty or null.");
            DomainExceptionValidation.When(title.Length < 5,
                                           "Invalid Title, too short, minimum 5 characters.");
            DomainExceptionValidation.When(title.Length > 150,
                                           "Invalid Title, too long, minimum 150 characters.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                                           "Invalid Description, must not be empty or null.");
            DomainExceptionValidation.When(description.Length < 5,
                                           "Invalid Description, too short, minimum 5 characters.");
            DomainExceptionValidation.When(description.Length > 25000,
                                           "Invalid Description, too long, minimum 25000 characters.");
            DomainExceptionValidation.When(categoryId <= 0,
                                           "Invalid Category Id, must be up to zero.");
            
            Title = title;
            Description = description;
            CategoryId = categoryId;
        }
        
    }
}
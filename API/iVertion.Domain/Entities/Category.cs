
using iVertion.Domain.Validation;
using System.Collections.Generic;

namespace iVertion.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string? Title { get; private set; }
        public string? Description { get; private set; }
        public IEnumerable<Article>? Articles { get; set; }
        public IEnumerable<CategoryHistory>? CategoryHistories { get; set; }


        public Category(string title,
                        string description,
                        bool active)
        {
            ValidationDomain(title,
                             description); 
            Active = active;
        }
        public Category(int id,
                        string title,
                        string description,
                        bool active)
        {
            DomainExceptionValidation.When(id <= 0,
                                           "Invalid Id, must be up to zero.");
            ValidationDomain(title,
                             description);
            Id = id;  
            Active = active;
        }
        public void Update(string title,
                           string description,
                           bool active)
        {
            ValidationDomain(title,
                             description);  
            Active = active;
        }

        private void ValidationDomain(string title,
                                      string description)
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
            
            Title = title;
            Description = description;
        }
        
    }
}
using iVertion.Domain.Validation;

namespace iVertion.Domain.Entities
{
    public sealed class Merchandising : Entity
    {
        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public string? Image { get; private set; }
        public PanelMerchandising? PanelMerchandising { get; set; }

        public Merchandising(string name,
                             string description,
                             string image,
                             bool active)
        {
            ValidationDomain(name,
                             description,
                             image);
            Active = active;
        }
        public Merchandising(int id,
                             string name,
                             string description,
                             string image,
                             bool active)
        {
            DomainExceptionValidation.When(id <= 0,
                                           "Invalid Id, must be up to zero.");
            ValidationDomain(name,
                             description,
                             image);
            Active = active;
            Id = id;
        }
        public void Update(string name,
                           string description,
                           string image, 
                           bool active)
        {
            ValidationDomain(name,
                             description,
                             image);
            Active = active;
        }

        private void ValidationDomain(string name,
                                      string description,
                                      string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                                           "Invalid Name, must not be null or empty.");
            DomainExceptionValidation.When(name.Length < 5,
                                           "Invalid Name, too short, must be 5 character.");
            DomainExceptionValidation.When(name.Length > 45,
                                           "Invalid Name, too long, must be 5 character.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                                           "Invalid Description, must not be null or empty.");
            DomainExceptionValidation.When(description.Length < 5,
                                           "Invalid Description, too short, must be at least 5 characters long.");
            DomainExceptionValidation.When(description.Length > 250,
                                           "Invalid Description, too long, must be 250 characters or less.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(image),
                                           "Invalid Image, must not be null or empty.");
            DomainExceptionValidation.When(image.Length < 5,
                                           "Invalid Image, too short, must be at least 5 characters long.");
            DomainExceptionValidation.When(image.Length > 250,
                                           "Invalid Image, too long, must be 250 characters or less.");
            Name = name;
            Description = description;
            Image = image;    
        }
    }
}
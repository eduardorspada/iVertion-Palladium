
using iVertion.Domain.Validation;

namespace iVertion.Domain.Entities
{
    public sealed class ContactForm : Entity
    {
        public string? Name { get; private set; }
        public string? Value { get; private set; }
        public string? Url { get; private set; }
        public string? Icon { get; private set; }

        public ContactForm(string name,
                           string value,
                           string url,
                           string icon,
                           bool active)
        {
            ValidationDomain(name,
                             value,
                             url,
                             icon); 
            Active = active;
        }
        public ContactForm(int id,
                           string name,
                           string value,
                           string url,
                           string icon,
                           bool active)
        {
            DomainExceptionValidation.When(id <= 0,
                                           "Invalid Id, must be up to zero.");
            ValidationDomain(name,
                             value,
                             url,
                             icon);
            Id = id;
            Active = active;
        }
        public void Update(string name,
                           string value,
                           string url,
                           string icon,
                           bool active)
        {
            ValidationDomain(name,
                             value,
                             url,
                             icon);  
            Active = active;
        }

        private void ValidationDomain(string name,
                                      string value,
                                      string url,
                                      string icon)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                                           "Invalid Name, must not be empty or null.");
            DomainExceptionValidation.When(name.Length < 5,
                                           "Invalid Name, too short, minimum 5 characters.");
            DomainExceptionValidation.When(name.Length > 150,
                                           "Invalid Name, too long, minimum 150 characters.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(value),
                                           "Invalid Value, must not be empty or null.");
            DomainExceptionValidation.When(value.Length < 5,
                                           "Invalid Value, too short, minimum 5 characters.");
            DomainExceptionValidation.When(value.Length > 500,
                                           "Invalid Value, too long, max 500 characters.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(url),
                                           "Invalid Url, must not be empty or null.");
            DomainExceptionValidation.When(url.Length < 5,
                                           "Invalid Url, too short, minimum 5 characters.");
            DomainExceptionValidation.When(url.Length > 500,
                                           "Invalid Url, too long, max 500 characters.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(icon),
                                           "Invalid Icon, must not be empty or null.");
            DomainExceptionValidation.When(icon.Length < 5,
                                           "Invalid Icon, too short, minimum 5 characters.");
            DomainExceptionValidation.When(icon.Length > 500,
                                           "Invalid Icon, too long, max 500 characters.");
            
            Name = name;
            Value = value;
            Url = url;
            Icon = icon;
        }
    }
}
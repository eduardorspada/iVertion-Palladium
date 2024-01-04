
using iVertion.Domain.Validation;

namespace iVertion.Domain.Entities
{
    public sealed class Contact : Entity 
    {
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
        public bool Read { get; set; }
        public Contact(string name,
                       string phone,
                       string email,
                       string subject,
                       string message,
                       bool read,
                       bool active)
        {
            ValidationDomain(name,
                             phone,
                             email,
                             subject,
                             message);
            Read = read;   
            Active = active;
        }
        public Contact(int id,
                       string name,
                       string phone,
                       string email,
                       string subject,
                       string message,
                       bool read,
                       bool active)
        {
            DomainExceptionValidation.When(id <= 0,
                                           "Invalid Id, must be up to zero.");
            ValidationDomain(name,
                             phone,
                             email,
                             subject,
                             message);
            Id = id;
            Read = read;
            Active = active;
        }
        public void Update(string name,
                           string phone,
                           string email,
                           string subject,
                           string message,
                           bool read,
                           bool active)
        {
            ValidationDomain(name,
                             phone,
                             email,
                             subject,
                             message);
            Read = read;   
            Active = active;
        }

        private void ValidationDomain(string name,
                                      string phone,
                                      string email,
                                      string subject,
                                      string message)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                                           "Invalid Name, must not be empty or null.");
            DomainExceptionValidation.When(name.Length < 3,
                                           "Invalid Name, too short, minimum 3 characters.");
            DomainExceptionValidation.When(name.Length > 500,
                                           "Invalid Name, too long, minimum 500 characters.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(phone),
                                           "Invalid Phone, must not be empty or null.");
            DomainExceptionValidation.When(phone.Length < 10,
                                           "Invalid Phone, too short, minimum 10 characters.");
            DomainExceptionValidation.When(phone.Length > 11,
                                           "Invalid Phone, too long, max 11 characters.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(email),
                                           "Invalid Email, must not be empty or null.");
            DomainExceptionValidation.When(email.Length < 5,
                                           "Invalid Email, too short, minimum 5 characters.");
            DomainExceptionValidation.When(email.Length > 250,
                                           "Invalid Email, too long, max 250 characters.");      
            DomainExceptionValidation.When(string.IsNullOrEmpty(subject),
                                           "Invalid Subject, must not be empty or null.");
            DomainExceptionValidation.When(subject.Length < 5,
                                           "Invalid Subject, too short, minimum 5 characters.");
            DomainExceptionValidation.When(subject.Length > 150,
                                           "Invalid Subject, too long, max 150 characters.");      
            DomainExceptionValidation.When(string.IsNullOrEmpty(message),
                                           "Invalid Message, must not be empty or null.");
            DomainExceptionValidation.When(message.Length < 5,
                                           "Invalid Message, too short, minimum 5 characters.");
            DomainExceptionValidation.When(message.Length > 5000,
                                           "Invalid Message, too long, max 5000 characters.");      
            
            Name = name;
            Phone = phone;
            Email = email;
            Subject = subject;
            Message = message;                                   
        }
    }
}

using iVertion.Domain.Validation;

namespace iVertion.Domain.Entities
{
    public sealed class Menu : Entity
    {
        public string? Name { get; private set; }
        public string? Url { get; private set; }
        public string? Icon { get; private set; }
        public int Level { get; private set; }
        // public int? MenuSupId { get; private set; }
        // public Menu? MenuSup { get; set; }
        public Menu(string name,
                    string url,
                    string icon,
                    int level,
                    // int menuSupId,
                    bool active)
        {
            ValidationDomain(name,
                             url,
                             icon,
                             level);
            // MenuSupId = menuSupId;   
            Active = active;
        }
        public Menu(int id,
                    string name,
                    string url,
                    string icon,
                    int level,
                    // int menuSupId,
                    bool active)
        {
            DomainExceptionValidation.When(id <= 0,
                                           "Invalid Id, must be up to zero.");
            ValidationDomain(name,
                             url,
                             icon,
                             level);
            Id = id;
            // MenuSupId = menuSupId;
            Active = active;
        }
        public void Update(string name,
                           string url,
                           string icon,
                           int level,
                        //    int menuSupId,
                           bool active)
        {
            ValidationDomain(name,
                             url,
                             icon,
                             level);
            // MenuSupId = menuSupId;
            Active = active;
        }

        private void ValidationDomain(string name,
                                      string url,
                                      string icon,
                                      int level)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                                           "Invalid Name, must not be empty or null.");
            DomainExceptionValidation.When(name.Length < 5,
                                           "Invalid Name, too short, minimum 5 characters.");
            DomainExceptionValidation.When(name.Length > 150,
                                           "Invalid Name, too long, minimum 150 characters.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(url),
                                           "Invalid Url, must not be empty or null.");
            DomainExceptionValidation.When(url.Length < 5,
                                           "Invalid Url, too short, minimum 5 characters.");
            DomainExceptionValidation.When(url.Length > 500,
                                           "Invalid Url, too long, minimum 500 characters.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(icon),
                                           "Invalid Icon, must not be empty or null.");
            DomainExceptionValidation.When(icon.Length < 5,
                                           "Invalid Icon, too short, minimum 5 characters.");
            DomainExceptionValidation.When(icon.Length > 500,
                                           "Invalid Icon, too long, minimum 500 characters.");
            DomainExceptionValidation.When(level < 0,
                                           "Invalid level, must be up to zero.");
            
            Name = name;
            Url = url;
            Icon = icon;
            Level = level;
        }
    }
}
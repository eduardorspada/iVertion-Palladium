using iVertion.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iVertion.Domain.Interfaces
{
    public interface IContactFormRepository
    {
        Task<IEnumerable<ContactForm>> GetContactFormsAsync(int? page);
        Task<List<ContactForm>> GetActivesContactFormsAsync();
        Task<ContactForm> GetContactFormByIdAsync(int? id);
        Task<List<ContactForm>> GetContactFormByNameAsync(string? name);
    }
}
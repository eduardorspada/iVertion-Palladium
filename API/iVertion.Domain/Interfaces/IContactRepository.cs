using iVertion.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iVertion.Domain.Interfaces
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetContactsAsync(int? page);
        Task<Contact> GetContactByIdAsync(int? id);
        Task<List<Contact>> GetContactByNameAsync(string? name, int? page);
    }
}
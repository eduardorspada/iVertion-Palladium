using System.Threading.Tasks;
using iVertion.Domain.Entities;
using iVertion.Domain.FiltersDb;

namespace iVertion.Domain.Interfaces
{
    public interface ITotemRepository
    {
        Task<PagedBaseResponse<Totem>> GetTotensAsync(TotemFilterDb request);
        Task<Totem> GetTotemByIdAsync(int id);
    }
}
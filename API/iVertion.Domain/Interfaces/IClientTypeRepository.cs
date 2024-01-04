using System.Threading.Tasks;
using iVertion.Domain.Entities;
using iVertion.Domain.FiltersDb;

namespace iVertion.Domain.Interfaces
{
    public interface IClientTypeRepository
    {
        Task<PagedBaseResponse<ClientType>> GetClientsTypeAsync(ClientTypeFilterDb request);
        Task<ClientType> GetClientTypeByIdAsync(int id);
    }
}
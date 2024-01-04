using System.Threading.Tasks;
using iVertion.Domain.Entities;
using iVertion.Domain.FiltersDb;

namespace iVertion.Domain.Interfaces
{
    public interface IServiceTypeRepository
    {
        Task<PagedBaseResponse<ServiceType>> GetServicesTypeAsync(ServiceTypeFilterDb request);
        Task<ServiceType> GetServiceTypeByIdAsync(int id);
    }
}
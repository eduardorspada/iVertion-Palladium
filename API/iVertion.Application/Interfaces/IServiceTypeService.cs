using System.Threading.Tasks;
using iVertion.Application.DTOs;
using iVertion.Application.Services;
using iVertion.Domain.FiltersDb;

namespace iVertion.Application.Interfaces
{
    public interface IServiceTypeService
    {
        Task<ResultService<PagedBaseResponseDTO<ServiceTypeDTO>>> GetServiceTypesAsync(ServiceTypeFilterDb serviceTypeFilterDb);
        Task<ResultService<ServiceTypeDTO>> GetServiceTypeByIdAsync(int id);
        Task CreateAsync(ServiceTypeDTO serviceTypeDto);
        Task UpdateAsync(ServiceTypeDTO serviceTypeDto);
        Task RemoveAsync(int id);
    }
}
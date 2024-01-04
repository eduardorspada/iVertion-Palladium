using System.Threading.Tasks;
using iVertion.Application.DTOs;
using iVertion.Application.Services;
using iVertion.Domain.FiltersDb;

namespace iVertion.Application.Interfaces
{
    public interface IClientTypeService
    {
        Task<ResultService<PagedBaseResponseDTO<ClientTypeDTO>>> GetClientTypesAsync(ClientTypeFilterDb clientTypeFilterDb);
        Task<ResultService<ClientTypeDTO>> GetClientTypeByIdAsync(int id);
        Task CreateAsync(ClientTypeDTO clientTypeDto);
        Task UpdateAsync(ClientTypeDTO clientTypeDto);
        Task RemoveAsync(int id);
    }
}
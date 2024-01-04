using System.Threading.Tasks;
using iVertion.Application.DTOs;
using iVertion.Application.Services;
using iVertion.Domain.FiltersDb;

namespace iVertion.Application.Interfaces
{
    public interface IPreferenceTypeService
    {
        Task<ResultService<PagedBaseResponseDTO<PreferenceTypeDTO>>> GetPreferenceTypesAsync(PreferenceTypeFilterDb preferenceTypeFilterDb);
        Task<ResultService<PreferenceTypeDTO>> GetPreferenceTypeByIdAsync(int id);
        Task CreateAsync(PreferenceTypeDTO preferenceTypeDto);
        Task UpdateAsync(PreferenceTypeDTO preferenceTypeDto);
        Task RemoveAsync(int id);
    }
}
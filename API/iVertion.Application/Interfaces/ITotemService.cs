using System.Threading.Tasks;
using iVertion.Application.DTOs;
using iVertion.Application.Services;
using iVertion.Domain.FiltersDb;

namespace iVertion.Application.Interfaces
{
    public interface ITotemService
    {
        Task<ResultService<PagedBaseResponseDTO<TotemDTO>>> GetTotemsAsync(TotemFilterDb totemFilterDb);
        Task<ResultService<TotemDTO>> GetTotemByIdAsync(int? id);
        Task CreateAsync(TotemDTO totemDto);
        Task UpdateAsync(TotemDTO totemDto);
        Task RemoveAsync(int id);
    }
}
using System.Threading.Tasks;
using iVertion.Application.DTOs;
using iVertion.Application.Services;
using iVertion.Domain.FiltersDb;

namespace iVertion.Application.Interfaces
{
    public interface ICounterService
    {
        Task<ResultService<PagedBaseResponseDTO<CounterDTO>>> GetCountersAsync(CounterFilterDb counterFilterDb);
        Task<ResultService<CounterDTO>> GetCounterByIdAsync(int id);
        Task CreateAsync(CounterDTO counterDto);
        Task UpdateAsync(CounterDTO counterDto);
        Task RemoveAsync(int id);
    }
}
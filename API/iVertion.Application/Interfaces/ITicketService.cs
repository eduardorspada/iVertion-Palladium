using System.Threading.Tasks;
using iVertion.Application.DTOs;
using iVertion.Application.Services;
using iVertion.Domain.FiltersDb;

namespace iVertion.Application.Interfaces
{
    public interface ITicketService
    {
        Task<ResultService<PagedBaseResponseDTO<TicketDTO>>> GetTicketsAsync(TicketFilterDb ticketFilterDb);
        Task<ResultService<TicketDTO>> GetTicketByIdAsync(int id);
        Task CreateAsync(TicketDTO ticketDto);
        Task UpdateAsync(TicketDTO ticketDto);
        Task RemoveAsync(int id);
    }
}
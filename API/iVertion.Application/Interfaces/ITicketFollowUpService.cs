using System.Threading.Tasks;
using iVertion.Application.DTOs;
using iVertion.Application.Services;
using iVertion.Domain.FiltersDb;

namespace iVertion.Application.Interfaces
{
    public interface ITicketFollowUpService
    {
        Task<ResultService<PagedBaseResponseDTO<TicketFollowUpDTO>>> GetTicketFollowUpsAsync(TicketFollowUpFilterDb ticketFollowUpFilterDb);
        Task<ResultService<TicketFollowUpDTO>> GetTicketFollowUpByIdAsync(int id);
        Task CreateAsync(TicketFollowUpDTO ticketFollowUpDto);
        Task UpdateAsync(TicketFollowUpDTO ticketFollowUpDto);
        Task RemoveAsync(int id);
    }
}
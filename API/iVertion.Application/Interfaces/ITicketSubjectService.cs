using System.Threading.Tasks;
using iVertion.Application.DTOs;
using iVertion.Application.Services;
using iVertion.Domain.FiltersDb;

namespace iVertion.Application.Interfaces
{
    public interface ITicketSubjectService
    {
        Task<ResultService<PagedBaseResponseDTO<TicketSubjectDTO>>> GetTicketSubjectsAsync(TicketSubjectFilterDb ticketSubjectFilterDb);
        Task<ResultService<TicketSubjectDTO>> GetTicketSubjectByIdAsync(int id);
        Task CreateAsync(TicketSubjectDTO ticketSubjectDto);
        Task UpdateAsync(TicketSubjectDTO ticketSubjectDto);
        Task RemoveAsync(int id);
    }
}
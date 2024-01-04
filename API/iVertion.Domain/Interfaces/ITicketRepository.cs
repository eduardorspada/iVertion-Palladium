using System.Threading.Tasks;
using iVertion.Domain.Entities;
using iVertion.Domain.FiltersDb;

namespace iVertion.Domain.Interfaces
{
    public interface ITicketRepository
    {
        Task<PagedBaseResponse<Ticket>> GetTicketsAsync(TicketFilterDb request);
        Task<Ticket> GetTicketByIdAsync(int id);
    }
}
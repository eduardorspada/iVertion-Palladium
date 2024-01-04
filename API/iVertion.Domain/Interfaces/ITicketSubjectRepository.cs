using System.Threading.Tasks;
using iVertion.Domain.Entities;
using iVertion.Domain.FiltersDb;

namespace iVertion.Domain.Interfaces
{
    public interface ITicketSubjectRepository
    {
        Task<PagedBaseResponse<TicketSubject>> GetTicketsSubjectAsync(TicketSubjectFilterDb request);
        Task<TicketSubject> GetTicketByIdAsync(int id);
    }
}
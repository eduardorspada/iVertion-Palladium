using System.Threading.Tasks;
using iVertion.Domain.Entities;
using iVertion.Domain.FiltersDb;

namespace iVertion.Domain.Interfaces
{
    public interface ITicketFollowUpRepository
    {
        Task<PagedBaseResponse<TicketFollowUp>> GetTiketsFollowUpsAsync(TicketFollowUpFilterDb request);
        Task<TicketFollowUp> GetTicketFollowUpByIdAsync(int id);
    }
}
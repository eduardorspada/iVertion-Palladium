using System;
using System.Linq;
using System.Threading.Tasks;
using iVertion.Domain.Entities;
using iVertion.Domain.FiltersDb;
using iVertion.Domain.Interfaces;
using iVertion.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace iVertion.Infra.Data.Repositories
{
    public class TicketSubjectRepository : ITicketSubjectRepository
    {
        private readonly ApplicationDbContext _context;
        public TicketSubjectRepository(ApplicationDbContext context)
        {
            _context = context;            
        }

        public async Task<TicketSubject> GetTicketByIdAsync(int id)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var  ticketSubject = await _context.TicketSubjects.FindAsync(id);
            return ticketSubject;
        }

        public async Task<PagedBaseResponse<TicketSubject>> GetTicketsSubjectAsync(TicketSubjectFilterDb request)
        {
            var ticketsSubjects =  _context.TicketSubjects.AsQueryable();

            // Name
            if (!String.IsNullOrEmpty(request.Name))
                ticketsSubjects = ticketsSubjects.Where(c => c.Name.Contains(request.Name));
            // Active
            if (request.Active != null)
                ticketsSubjects = ticketsSubjects.Where(p => p.Active == request.Active);
            // UserId
            if (!String.IsNullOrEmpty(request.UserId))
                ticketsSubjects = ticketsSubjects.Where(p => p.UserId.Contains(request.UserId));

            return await PagedBaseResponseHelper
                            .GetResponseAsync<PagedBaseResponse<TicketSubject>, TicketSubject>(ticketsSubjects, request);
        }
    }
}
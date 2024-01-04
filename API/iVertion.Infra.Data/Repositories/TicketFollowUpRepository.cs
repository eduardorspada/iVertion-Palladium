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
    public class TicketFollowUpRepository : ITicketFollowUpRepository
    {
        private readonly ApplicationDbContext _context;
        public TicketFollowUpRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TicketFollowUp> GetTicketFollowUpByIdAsync(int id)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var  panel = await _context.TicketFollowUps.FindAsync(id);
            return panel;
        }

        public async Task<PagedBaseResponse<TicketFollowUp>> GetTiketsFollowUpsAsync(TicketFollowUpFilterDb request)
        {
            var ticketFollowUps = _context.TicketFollowUps.AsQueryable();

            // Description 
            if(!String.IsNullOrEmpty(request.Description))
                ticketFollowUps = ticketFollowUps.Where(c => c.Description.Contains(request.Description));
            // TicketId 
            if (request.TicketId != null)
                ticketFollowUps = ticketFollowUps.Where(p => p.TicketId == request.TicketId);
            // TicketSubjectId 
            if (request.TicketSubjectId != null)
                ticketFollowUps = ticketFollowUps.Where(p => p.TicketSubjectId == request.TicketSubjectId);
            // Active 
            if (request.Active != null)
                ticketFollowUps = ticketFollowUps.Where(p => p.Active == request.Active);
            // UserId 
            if (!String.IsNullOrEmpty(request.UserId))
                ticketFollowUps = ticketFollowUps.Where(p => p.UserId.Contains(request.UserId));
            // StartDateFilter
            if (request.StartDateFilter != null)
                ticketFollowUps = ticketFollowUps.Where(p => p.CreatedAt.Value.Date == request.StartDateFilter.Value.Date);
            // EndDateFilter
            if (request.EndDateFilter != null)
                ticketFollowUps = ticketFollowUps.Where(p => p.CreatedAt.Value.Date == request.EndDateFilter.Value.Date);

            return await PagedBaseResponseHelper
                            .GetResponseAsync<PagedBaseResponse<TicketFollowUp>, TicketFollowUp>(ticketFollowUps, request);
        }
    }
}
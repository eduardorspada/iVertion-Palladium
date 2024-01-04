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
    public class TicketRepository : ITicketRepository
    {
        private readonly ApplicationDbContext _context;
        public TicketRepository(ApplicationDbContext context)
        {
            _context = context;            
        }

        public async Task<Ticket> GetTicketByIdAsync(int id)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var  ticket = await _context.Tickets.FindAsync(id);
            return ticket;
        }

        public async Task<PagedBaseResponse<Ticket>> GetTicketsAsync(TicketFilterDb request)
        {
            var tickets =  _context.Tickets.AsQueryable();

            // Acronym
            if(!String.IsNullOrEmpty(request.Acronym))
                tickets = tickets.Where(c => c.Acronym.Contains(request.Acronym));
            // Active
            if (request.Active != null)
                tickets = tickets.Where(p => p.Active == request.Active);
            // UserId
            if (!String.IsNullOrEmpty(request.UserId))
                tickets = tickets.Where(p => p.UserId.Contains(request.UserId));
            // Sequential
            if (request.Sequential != null)
                tickets = tickets.Where(p => p.Sequential == request.Sequential);
            // ContractNumber
            if (!String.IsNullOrEmpty(request.ContractNumber))
                tickets = tickets.Where(p => p.ContractNumber.Contains(request.ContractNumber));
            // AttendantName
            if (!String.IsNullOrEmpty(request.AttendantName))
                tickets = tickets.Where(p => p.AttendantName.Contains(request.AttendantName));
            // PanelId
            if (request.PanelId != null)
                tickets = tickets.Where(p => p.PanelId == request.PanelId);
            // PreferenceTypeId
            if (request.PreferenceTypeId != null)
                tickets = tickets.Where(p => p.PreferenceTypeId == request.PreferenceTypeId);
            // ServiceTypeId
            if (request.ServiceTypeId != null)
                tickets = tickets.Where(p => p.ServiceTypeId == request.ServiceTypeId);
            // ClientTypeId
            if (request.ClientTypeId != null)
                tickets = tickets.Where(p => p.ClientTypeId == request.ClientTypeId);
            // StartDateFilter
            if (request.StartDateFilter != null)
                tickets = tickets.Where(p => p.CreatedAt.Value.Date == request.StartDateFilter.Value.Date);
            // EndDateFilter
            if (request.EndDateFilter != null)
                tickets = tickets.Where(p => p.CreatedAt.Value.Date == request.EndDateFilter.Value.Date);

            return await PagedBaseResponseHelper
                            .GetResponseAsync<PagedBaseResponse<Ticket>, Ticket>(tickets, request);
        }
    }
}
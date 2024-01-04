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
    public class PreferenceTypeRepository : IPreferenceTypeRepository
    {
        private readonly ApplicationDbContext _context;
        public PreferenceTypeRepository(ApplicationDbContext context)
        {
            _context = context;            
        }

        public async Task<PagedBaseResponse<PreferenceType>> GetPreferencesTypeAsync(PreferenceTypeFilterDb request)
        {
            var preferenceTypes = _context.PreferenceTypes.AsQueryable();

            if(!String.IsNullOrEmpty(request.Description))
                preferenceTypes = preferenceTypes.Where(c => c.Description.Contains(request.Description));
            if(!String.IsNullOrEmpty(request.Acronym))
                preferenceTypes = preferenceTypes.Where(c => c.Acronym.Contains(request.Acronym));
            if (request.Active != null)
                preferenceTypes = preferenceTypes.Where(p => p.Active == request.Active);
            if (!String.IsNullOrEmpty(request.UserId))
                preferenceTypes = preferenceTypes.Where(p => p.UserId.Contains(request.UserId));
            
            return await PagedBaseResponseHelper
                            .GetResponseAsync<PagedBaseResponse<PreferenceType>, PreferenceType>(preferenceTypes ,request);
        }

        public async Task<PreferenceType> GetPreferenceTypeByIdAsync(int id)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var preferenceType = await _context.PreferenceTypes.FindAsync(id);
            return preferenceType;
        }
    }
}
using iVertion.Domain.Entities;
using iVertion.Domain.FiltersDb;
using iVertion.Domain.Interfaces;
using iVertion.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace iVertion.Infra.Data.Repositories
{
    public class AddtionalUserRoleRepository : IAddtionalUserRoleRepository
    {
        private readonly ApplicationDbContext _context;
        public AddtionalUserRoleRepository(ApplicationDbContext context)
        {
            _context = context;            
        }

        public async Task<PagedBaseResponse<AddtionalUserRole>> GetAddtionalUserRoleAsync(AddtionalUserRoleFilterDb request)
        {
            var addtionalUserRoles = _context.AddtionalUserRoles.AsQueryable();

            if(!String.IsNullOrEmpty(request.Role))
                addtionalUserRoles = addtionalUserRoles.Where(c => c.Role.Contains(request.Role));

            if(!String.IsNullOrEmpty(request.TargetUserId))
                addtionalUserRoles = addtionalUserRoles.Where(c => c.TargetUserId == request.TargetUserId);

            // UserId
            if (!String.IsNullOrEmpty(request.UserId))
                addtionalUserRoles = addtionalUserRoles.Where(p => p.UserId.Contains(request.UserId));
            return await PagedBaseResponseHelper
                            .GetResponseAsync<PagedBaseResponse<AddtionalUserRole>, AddtionalUserRole>(addtionalUserRoles, request);
        }

        public async Task<AddtionalUserRole> GetAddtionalUserRoleByIdAsync(int id)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var  addtionalUserRole = await _context.AddtionalUserRoles.FindAsync(id);
            return addtionalUserRole;
        }

    }
}
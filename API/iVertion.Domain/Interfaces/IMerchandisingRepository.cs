using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iVertion.Domain.Entities;
using iVertion.Domain.FiltersDb;

namespace iVertion.Domain.Interfaces
{
    public interface IMerchandisingRepository
    {
        Task<PagedBaseResponse<Merchandising>> GetMerchandisingAsync(MerchandisingFilterDb request);
        Task<Merchandising> GetMerchandisingById(int id);
    }
}
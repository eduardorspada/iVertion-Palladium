using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iVertion.Domain.Entities;
using iVertion.Domain.FiltersDb;

namespace iVertion.Domain.Interfaces
{
    public interface ICounterRepository
    {
        Task<PagedBaseResponse<Counter>> GetCountersAsync(CounterFilterDb request);
        Task<Counter> GetCounterById(int id);
    }
}
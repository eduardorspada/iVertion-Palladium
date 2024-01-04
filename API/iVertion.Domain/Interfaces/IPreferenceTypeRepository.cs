using System.Threading.Tasks;
using iVertion.Domain.Entities;
using iVertion.Domain.FiltersDb;

namespace iVertion.Domain.Interfaces
{
    public interface IPreferenceTypeRepository
    {
        Task<PagedBaseResponse<PreferenceType>> GetPreferencesTypeAsync(PreferenceTypeFilterDb request);
        Task<PreferenceType> GetPreferenceTypeByIdAsync(int id);
    }
}
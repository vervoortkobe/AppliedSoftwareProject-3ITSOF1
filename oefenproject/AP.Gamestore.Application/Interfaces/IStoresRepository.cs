using AP.MyGameStore.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AP.MyGameStore.Application.Interfaces
{
    public interface IStoresRepository : IGenericRepository<Store>
    {
        Task<IEnumerable<Store>> GetAll(string? nameFilter = null, SortBy? sortBy = null, int pageNumber = 1, int pageLength = 10);

        public enum SortBy
        {
            ByNameAscending,
            ByNameDescending,
            ByZipCodeAscending,
            ByZipcodeDescending
        }
        Store GetByName(string name);
    }
}

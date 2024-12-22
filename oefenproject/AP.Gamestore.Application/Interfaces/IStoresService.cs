using AP.MyGameStore.Application.CQRS.People;
using AP.MyGameStore.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AP.MyGameStore.Application.Interfaces
{
    public interface IStoresService
    {
        public Task<IEnumerable<Store>> GetAll(int pageNr, int pageSize, IStoresRepository.SortBy orderBy, string name);
        public Task<Store> GetById(int id);
        public Task<Store> Add(Store store);
        public Task Delete(int id);
        public Task<Store> Update(Store store);
        public IEnumerable<Person> GetEmployees(int storeId);
        public void DeleteEmployees(int storeId);


    }


}

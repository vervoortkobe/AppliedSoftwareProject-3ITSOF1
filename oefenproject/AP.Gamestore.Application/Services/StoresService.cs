using AP.MyGameStore.Application.CQRS.People;
using AP.MyGameStore.Application.Exceptions;
using AP.MyGameStore.Application.Interfaces;
using AP.MyGameStore.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AP.MyGameStore.Application.Services
{
    public class StoresService : IStoresService
    {
        private readonly IUnitofWork uow;

        public StoresService(IUnitofWork uow)
        {
            this.uow = uow;
        }
        public async Task<IEnumerable<Store>> GetAll(int pageNr, int pageSize, IStoresRepository.SortBy orderBy, string name)
        {
            return await uow.StoresRepository.GetAll(name, orderBy, pageNr, pageSize );
        }

        public async Task<Store> GetById(int id)
        {
            return await uow.StoresRepository.GetById(id);
        }

        public async Task<Store> Add(Store store)
        {
            var existing = uow.StoresRepository.GetByName(store.Name);
            if (existing != null)
                throw new ValidationException("A store with this name already exists");

            await uow.StoresRepository.Create(store);
            await uow.Commit();
            return store;
        }

        public async Task Delete(int id)
        {
            var store = await uow.StoresRepository.GetById(id);
            if (store == null)
                throw new KeyNotFoundException("the store was not found");

            if (uow.PeopleRepository.AnyWithEmployer(store.Id))
                throw new ValidationException("There are still employees in this store");

            uow.StoresRepository.Delete(store);
            await uow.Commit();
        }

        public async Task<Store> Update(Store store)
        {
            var existing = await uow.StoresRepository.GetById(store.Id);
            if (existing == null)
                throw new KeyNotFoundException("The store was not found");

            if (existing.Name != store.Name)
            {
                var exists = uow.StoresRepository.GetByName(store.Name);
                if (exists != null)
                    throw new ValidationException("A store with this name already exists");
            }

            existing.Name = store.Name;
            existing.Street = store.Street;
            existing.Number = store.Number;
            existing.Zipcode = store.Zipcode;
            existing.City = store.City;
            existing.IsFranchiseStore = store.IsFranchiseStore;
            existing.Addition = store.Addition;

            //context.Stores.Update(existing);
            await uow.Commit();
            return existing;
        }

        public IEnumerable<Person> GetEmployees(int storeId)
        {
            return uow.PeopleRepository.GetByEmployer(storeId);
        }

        public void DeleteEmployees(int storeId)
        {
            var list = uow.PeopleRepository.GetByEmployer(storeId);
            uow.PeopleRepository.Delete(list);
            uow.Commit();
        }
    }
}

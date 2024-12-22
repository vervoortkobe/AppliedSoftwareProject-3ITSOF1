using AP.MyGameStore.Application.CQRS.People;
using AP.MyGameStore.Application.Exceptions;
using AP.MyGameStore.Application.Interfaces;
using AP.MyGameStore.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AP.MyGameStore.Application.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly IUnitofWork uow;

        public PeopleService(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public async Task<IEnumerable<Person>> GetAll(int pageNr, int pageSize)
        {
            return await uow.PeopleRepository.GetAll(pageNr, pageSize);
        }

        public async Task<Person> GetById(int id)
        {
            return await uow.PeopleRepository.GetById(id);
        }

        public async Task<Person> Update(Person person)
        {
            var existing = await uow.PeopleRepository.GetById(person.Id);
            if (existing == null)
                throw new KeyNotFoundException("the person was not found");

            var employer = await uow.StoresRepository.GetById(person.EmployerId);
            if (employer == null)
                throw new RelationNotFoundException("The specified employer does not exist");

            existing.FirstName = person.FirstName;
            existing.LastName = person.LastName;
            existing.BirthDate = person.BirthDate;
            existing.Gender = person.Gender;
            existing.EmployerId = person.EmployerId;
            await uow.Commit();
            return existing;
        }

        public async Task<Person> Add(Person person)
        {
            var employer = await uow.StoresRepository.GetById(person.EmployerId);
            if (employer == null)
                throw new RelationNotFoundException("The specified employer does not exist");

            await uow.PeopleRepository.Create(person);
            await uow.Commit();
            return person;
        }

        public async Task Delete(int id)
        {
            var person = await uow.PeopleRepository.GetById(id);
            if (person == null)
                throw new KeyNotFoundException("the person was not found");

            uow.PeopleRepository.Delete(person);
            await uow.Commit();
        }

    }
}

using AP.MyGameStore.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AP.MyGameStore.Application.Interfaces
{
    public interface IPeopleService
    {
        public Task<IEnumerable<Person>> GetAll(int pageNr, int pageSize);
        public Task<Person> GetById(int id);
        public Task<Person> Add(Person person);
        public Task Delete(int id);
        public Task<Person> Update(Person person);
    }
}

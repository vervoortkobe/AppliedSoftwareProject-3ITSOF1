using AP.MyGameStore.Domain;
using System.Collections.Generic;

namespace AP.MyGameStore.Application.Interfaces
{
    public interface IPeopleRepository : IGenericRepository<Person>
    {
        bool AnyWithEmployer(int employerId);

        IEnumerable<Person> GetByEmployer(int employerId);

        void Delete(IEnumerable<Person> people);


    }
}

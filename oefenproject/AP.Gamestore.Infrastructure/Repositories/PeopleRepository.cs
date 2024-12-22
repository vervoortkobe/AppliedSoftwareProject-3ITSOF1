using AP.MyGameStore.Application.Interfaces;
using AP.MyGameStore.Domain;
using AP.MyGameStore.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AP.MyGameStore.Infrastructure.Repositories
{
    public class PeopleRepository : GenericRepository<Person>, IPeopleRepository
    {
        private readonly MyGameStoreContext context;

        public PeopleRepository(MyGameStoreContext context) : base(context)
        {
            this.context = context;
        }

        public bool AnyWithEmployer(int employerId)
        {
            return context.People.Any(p => p.EmployerId == employerId);
        }

        public IEnumerable<Person> GetByEmployer(int employerId)
        {
            return context.People.Where(p => p.EmployerId == employerId);
        }

        public void Delete(IEnumerable<Person> people)
        {
            context.People.RemoveRange(people);
        }
    }
}

using AP.MyGameStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.MyGameStore.Application.CQRS.People
{
    public  class PersonDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Gender Gender { get; set; }

        public DateTime BirthDate { get; set; }
        public int EmployerId { get; set; }
    }
}

using AP.MyGameStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AP.MyGameStore.Application.CQRS.Stores
{
    public class StoreDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Addition { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public bool IsFranchiseStore { get; set; }
        public ICollection<Person> Employees { get; set; }
    }
}

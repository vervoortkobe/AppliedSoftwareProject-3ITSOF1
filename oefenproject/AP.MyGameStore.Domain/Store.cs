using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AP.MyGameStore.Domain
{
    //[Table("tblStores", Schema ="Store")]
    //[Index(nameof(Name), IsUnique = true)]
    public class Store
    {
        //[Column("Id", TypeName = "int")]
        //[Key]
        public int Id { get; set; }
        //[Column("Name", TypeName = "nvarchar(30)")]
        //[Required]
        public string Name { get; set; }
        //[Column("Street", TypeName = "nvarchar(60)")]
        //[Required]
        public string Street { get; set; }
        //[Column("Number", TypeName = "nvarchar(5)")]
        //[Required]
        public string Number { get; set; }
        //[Column("Addition", TypeName = "nvarchar(2)")]
        public string Addition { get; set; }
        //[Column("ZipCode", TypeName = "nvarchar(6)")]
        //[Required]
        public string Zipcode { get; set; }
        //[Column("Place", TypeName = "nvarchar(60)")]
        public string City { get; set; }

        //[Column("IsFranchiseStore", TypeName = "bit")]
        public bool IsFranchiseStore { get; set; }

        [JsonIgnore]
        public ICollection<Person> Employees { get; set; }
    }
}

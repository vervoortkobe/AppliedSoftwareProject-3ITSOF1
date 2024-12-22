using System;
using System.Text.Json.Serialization;

namespace AP.MyGameStore.Domain
{
    //[Table("tblPeople", Schema = "Person")]
    //[Index(nameof(Email), IsUnique = true)]
    public class Person
    {
        //[Column("Id", TypeName = "int")]
        //[Key]
        public int Id { get; set; }
        //[Column("LastName",TypeName = "nvarchar(70)")]
        //[Required]
        public string LastName { get; set; }
        //[Column("Firstname", TypeName = "nvarchar(50)")]
        //[Required]
        public string FirstName { get; set; }
        //[Column("Gender", TypeName ="int")]
        public Gender Gender { get; set; }

        public DateTime BirthDate { get; set; }

        //[Column("EmailAddress", TypeName ="nvarchar(100)")]
        public string Email { get; set; }

        public int EmployerId { get; set; }
        [JsonIgnore]
        public Store Employer { get; set; }

    }

    public enum Gender
    {
        Female,
        Male
    }

}

using System;
namespace Geodata.WebApi.Models
{
    public class Person : BaseEntity
    {
        public Person()
        {
        }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public int Age { get; set; }

        public string Name { get; set; }
    }
}

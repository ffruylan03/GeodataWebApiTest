using System;
namespace Geodata.WebApi.ApiModels.Persons
{
    public class PersonEditDto
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public int Age { get; set; }
    }
}

using System;
namespace Geodata.WebApi.ApiModels.Persons
{
    public class PersonCreateDto
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public int Age { get; set; }
    }
}

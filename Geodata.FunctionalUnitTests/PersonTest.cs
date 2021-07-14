using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Geodata.WebApi;
using Geodata.WebApi.ApiModels.Persons;
using Newtonsoft.Json;
using Xunit;

namespace Geodata.FunctionalUnitTests
{
    public class PersonTest : BaseControllerTest
    {
        public PersonTest(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact(DisplayName = "2. Get Persons")]
        public async Task GetPersons()
        {
            var response = await Client.GetAsync("api/persons");
            var stringResponse = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<PersonGetDto>(stringResponse);
            Assert.Contains("Doe", model.Name);
        }

        [Fact(DisplayName = "1. Add New Person")]
        public async Task PostPerson()
        {
            var request = new PersonCreateDto()
            {
                LastName = "Doe",
                FirstName = "John",
                MiddleName = "Dela Cruz",
                Age = 20,
            };

            var json = await Task.Run(() => JsonConvert.SerializeObject(request));
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync("api/persons", content);
            var responseAsString = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseAsString);

            var result = JsonConvert.DeserializeObject<string>(responseAsString);
            Assert.True(int.TryParse(result, out int output));
        }
    }
}

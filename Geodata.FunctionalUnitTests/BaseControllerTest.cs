using System;
using System.Net.Http;
using Geodata.WebApi;
using Xunit;

namespace Geodata.FunctionalUnitTests
{
    public class BaseControllerTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        protected HttpClient Client { get; }

        //// HACK: Change Globl IDs when running test
        public const string _PROVIDER_ID = "1050be81-4002-4665-ac8d-b8f787c889e6";
        public const string _UPI = "889ce3e5-b482-4fcc-a702-056c0580fed7";
        public const string _ENCOUNTER_ID = "94605331-842a-4537-adc2-9db33f7ee777";
        public const string _FACILITY_ID = "534e1c73-5046-455f-8986-a195543863b8";

        //HACK: Laboratory Only - Change DiagnosticServiceID
        public const string _DIAGNOSTIC_ID = "13140bdb-5874-4f1e-98e3-d54caabbd902";

        public BaseControllerTest(CustomWebApplicationFactory<Startup> factory)
        {
            Client = factory.CreateClient();
        }
    }
}

using PactNet.Mocks;
using PactNet.Mocks.MockHttpService;
using PactNet.Mocks.MockHttpService.Models;
using PersonConsumer.Models;
using System.Net.Http.Json;

namespace PersonConsumer.Tests
{
    public class PersonServiceTest:IClassFixture<PersonServiceMock>
    {
        private readonly IMockProviderService _mockProviderService;
        private readonly string _url;
        public PersonServiceTest(PersonServiceMock personSvcMock)
        {
            //PersonServiceMock personSvcMock = new PersonServiceMock();
            _mockProviderService =  personSvcMock.MockProviderService;
            _url = personSvcMock.ServiceUri;
            _mockProviderService.ClearInteractions();
        }
        [Fact]
        public async void get_person_by_Id()
        {
            PersonByIdRequest request = new PersonByIdRequest
            {
                Id = 1,
            };

            _mockProviderService.Given("PersonId")
                .UponReceiving("Return Person With Id 1")
                .With(new ProviderServiceRequest
                {
                    Method = HttpVerb.Post,
                    Path = "/api/people",
                    Body = request,
                    Headers = new Dictionary<string, object>
                    {
                    {"Content-type", "application/json; charset=utf-8" }
                    }
                }).
                WillRespondWith(new ProviderServiceResponse
                {
                    Status = 200,
                    Headers = new Dictionary<string, object>
                    {
                    {"Content-type", "application/json; charset=utf-8"  }
                    },
                    Body = new PersonResponse
                    {
                        Id = 1,
                        FirstName = "Abbas",
                        LastName = "Vosoughi",
                        Age = 33
                    }
                });


            var httpClinet = new HttpClient();

            var response = await httpClinet.PostAsJsonAsync($"{_url}/api/people", request);
            var personReponse = await response.Content.ReadFromJsonAsync<PersonResponse>();

            Assert.NotNull(personReponse);
            Assert.Equal(1, personReponse.Id);
            Assert.Equal("Abbas", personReponse.FirstName);
            Assert.Equal("Vosoughi", personReponse.LastName);
            Assert.Equal(33, personReponse.Age);

        }
    }
}
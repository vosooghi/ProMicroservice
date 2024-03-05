using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ObservabilitySamples.API01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        public PersonController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("Person");
        }
        [HttpGet(Name = "GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _httpClient.GetStringAsync("/api/Person");
            return Ok(result);
        }
    }
}

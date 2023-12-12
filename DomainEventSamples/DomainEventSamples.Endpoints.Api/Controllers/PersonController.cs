using DomainEventSamples.Core.ApplicationServices;
using Microsoft.AspNetCore.Mvc;

namespace DomainEventSamples.Endpoints.Api.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        public PersonController(PersonService personService)
        {
            _personService = personService;
        }

        public PersonService _personService { get; }

        [HttpPost("/CreatePerson")]
        public async Task<IActionResult> Create(string firstName, string lastName)
        {
            await _personService.AddPerson(firstName, lastName);
            return Ok();
        }
        [HttpPut("/ChangeFirstName")]
        public async Task<IActionResult> ChangeFirstName(int id, string firstName)
        {
            await _personService.SetFirstName(id, firstName);
            return Ok();
        }
        [HttpPut("/ChangeLastName")]
        public async Task<IActionResult> ChangeLastName(int id, string lastName)
        {
            await _personService.SetLastName(id, lastName);
            return Ok();
        }
    }
}

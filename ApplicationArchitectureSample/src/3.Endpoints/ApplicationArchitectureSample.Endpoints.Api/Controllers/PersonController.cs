using ApplicationArchitectureSample.Core.ApplicationServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationArchitectureSample.Endpoints.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private PersonApplicationService _personApplicationService;

        public PersonController(PersonApplicationService personApplicationService)
        {
            _personApplicationService = personApplicationService;
        }
        [HttpPost]
        public IActionResult AddPerson(CreatePersonInputDto dto)
        {
            _personApplicationService.AddPerson(dto);
            return Ok();
        }
        [HttpPut]
        public IActionResult AddNumberToPerson(AddNumberToPersonDto dto)
        {
            _personApplicationService.AddNumberToPerson(dto);
            return Ok();
        }
    }
}

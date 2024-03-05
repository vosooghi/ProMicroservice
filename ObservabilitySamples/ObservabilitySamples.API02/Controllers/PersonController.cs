using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ObservabilitySamples.API02.Models;

namespace ObservabilitySamples.API02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        public PersonController(PeopleContext peopleContext )
        {
            _peopleContext = peopleContext;
        }

        public PeopleContext _peopleContext { get; }

        [HttpGet(Name = "GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _peopleContext.People.ToListAsync());
        }
    }
}

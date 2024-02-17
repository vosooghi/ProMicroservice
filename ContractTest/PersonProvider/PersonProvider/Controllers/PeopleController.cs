using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonProvider.Models;

namespace PersonProvider.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(PersonByIdRequest request)
        {
            return Ok(new PersonResponse
            {
                FirstName = "Abbas",
                LastName = "Vosoughi",
                Id = 1,
                Age = 33
            });
        }

    }
}

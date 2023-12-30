using Ground.Samples.Core.Domain.People.ValueObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ground.Samples.Endpoints.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        [HttpGet("CheckValueObject")]
        public IActionResult CheckFirstNameValueObject(string firstname)
        {
            FirstName fname =new FirstName( firstname);
            return Ok();
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace YarpSamples.FirstName.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FNameController : ControllerBase
    {
        private readonly List<string> fNames = new List<string>
        {
            "Abbas",
            "Radmehr",
            "Alex",
            "Atarin",
            "Niv",
        };
        private readonly Random _random= new Random();
        [HttpGet]
        public IActionResult Get()
        {
            var index = _random.Next(0, fNames.Count-1);
            return Ok(fNames[index]);
        }
    }
}

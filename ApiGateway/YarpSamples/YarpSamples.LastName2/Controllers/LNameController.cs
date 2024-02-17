using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace YarpSamples.LastName2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LNameController : ControllerBase
    {
        public LNameController(IServer server)
        {
            _server = server;
        }
        private readonly List<string> lNames = new List<string>
        {
            "Vosoughi2",
            "Miraei2",
            "Lopez2",
            "Biden2",
            "Trump2",
        };
        private readonly Random _random = new Random();
        private readonly IServer _server;

        [HttpGet]
        public IActionResult Get()
        {
            //_server.Features.Get<IServerAddressesFeature>().Addresses.First();
            var index = _random.Next(0, lNames.Count - 1);
            return Ok(lNames[index]);
        }
    }
}

using EntitySamples.IdGenerators.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntitySamples.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdGeneratorController : ControllerBase
    {
        private readonly IIdGenerator _idGenerator;

        public IdGeneratorController(IIdGenerator idGenerator)
        {
            _idGenerator = idGenerator;
        }

        [HttpGet(Name ="Generate")]
        public long Get()
        {
            return _idGenerator.Next();
        }
    }
}

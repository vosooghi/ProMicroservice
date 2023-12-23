using EventSourcingSample.Domain.Prdocuts;
using EventSourcingSample.Domain.Prdocuts.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventSourcingSample.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        private readonly IProductRepository _productRepository;
        [HttpPost]
        public async Task<IActionResult> Post(long id, string name, string description, int price)
        {
            Product product = new Product(id, name, description, price);
            product.ChangePrice(price - 10);
            product.ChangePrice(price - 5);
            product.ChangeName(name + "Test");
            _productRepository.Save(product);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get(long id)
        {
            var product = _productRepository.Get(id);
            return Ok(product);
        }
            
    }
}

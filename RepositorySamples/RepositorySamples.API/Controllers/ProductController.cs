using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using RepositorySamples.DAL.Products;
using RepositorySamples.Domain.Products;
using RepositorySamples.Domain.Products.Entities;

namespace RepositorySamples.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _efProductRepository;

        public ProductController(IProductRepository efProductRepository)
        {
            _efProductRepository = efProductRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Post(string title,string description, int price,int categoryId)
        {
            var product = new Product(title, description, price, categoryId);
            _efProductRepository.Add(product);
            await _efProductRepository.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Put(long id, string title,int value)
        {
            var p = _efProductRepository.Get(id);
            p.AddDiscount(title, value);
                                    
            await _efProductRepository.SaveChangesAsync();
            return Ok();
        }
    }
}

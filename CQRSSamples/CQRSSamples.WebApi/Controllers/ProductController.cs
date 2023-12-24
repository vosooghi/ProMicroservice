using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using CQRSSamples.Command.DAL.Products;
using CQRSSamples.Domain.Products;
using CQRSSamples.Domain.Products.Entities;
using CQRSSamples.ApplicationService.Products;
using CQRSSamples.ApplicationService.Products.Commands.CreateProducts;
using CQRSSamples.ApplicationService.Products.Commands.AddDiscounts;

namespace CQRSSamples.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //private readonly ProductService _productService;

        //public ProductController(ProductService productService)
        //{
        //    _productService = productService;
        //}
        [HttpPost]
        public async Task<IActionResult> Post([FromServices] CreateProductHandler handler,CreateProdcut createProdcut)
        {            
           await handler.Handle(createProdcut);            
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromServices] AddDiscountHandler handler,AddDiscount addDiscount)
        {            
            await handler.Handle(addDiscount);            
            return Ok();
        }
    }
}

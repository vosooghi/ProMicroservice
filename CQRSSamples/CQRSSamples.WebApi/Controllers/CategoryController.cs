using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CQRSSamples.Domain.Categories;
using CQRSSamples.Domain.Categories.Entities;
using CQRSSamples.Domain.Common;
using CQRSSamples.ApplicationService.Categories;
using CQRSSamples.ApplicationService.Categories.Commands.CreateCategories;
using CQRSSamples.ApplicationService.Categories.Commands.UpdateCategories;

namespace CQRSSamples.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        
        //Fat Controller...
        //private readonly CategoryServices _categoryServices;

        //public CategoryController(CategoryServices categoryServices)
        //{            
        //    _categoryServices = categoryServices;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="createCategoryHandler">when we want to create category, we don't need to inject update dependencies.</param>
        /// <param name="createCategory"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromServices]CreateCategoryHandler handler,CreateCategory createCategory)
        {            
           await handler.Handle(createCategory);
           
            return Ok();
        }
        /// <summary>
        /// all dependencies are injected.
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="updateCategory"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put([FromServices] UpdateCategoryHandler handler,UpdateCategory updateCategory)
        {
            await handler.Handle(updateCategory);
            return Ok();
        }
    }
}

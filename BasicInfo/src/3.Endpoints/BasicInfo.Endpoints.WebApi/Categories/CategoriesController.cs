using BasicInfo.Core.Contracts.Categoires.Commands.CreateCategories;
using Ground.Endpoints.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace BasicInfo.Endpoints.WebApi.Categorys
{
    [Route("api/[controller]")]    
    public class CategoriesController : BaseController
    {
        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CreateCategory createCategory)
        {
            return await Create<CreateCategory,long>(createCategory);
        }

        /*
        [HttpPost("ChangeTitle")]
        public async Task<IActionResult> ChangeTitle(ChangeTitle changeTitle)
        {
            return await Edit(changeTitle);
        }

        [HttpPost("Active")]
        public async Task<IActionResult> Active(ActiveCategory activeCategory)
        {
            return await Edit(activeCategory);
        }
        [HttpPost("Inactive")]
        public async Task<IActionResult> Inactive(InactiveCategory inactiveCategory)
        {
            return await Edit(inactiveCategory);
        }

        [HttpGet("SearchTitleAndStatus")]
        public async Task<IActionResult> SearchTitleAndStatus(TitleAndStatus titleAndStatus)
        {
            return await Query<TitleAndStatus,PageData<CategorySearchResult>>(titleAndStatus);
        }
        */
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositorySamples.Domain.Categories;
using RepositorySamples.Domain.Categories.Entities;
using RepositorySamples.Domain.Common;

namespace RepositorySamples.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        /// <summary>
        /// here we have one aggregate, so we don't need to UoW
        /// </summary>
        private readonly IRepositorySampleDomainUnitOfWork _repositorySampleDomainUnitOfWork;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(IRepositorySampleDomainUnitOfWork repositorySampleDomainUnitOfWork,ICategoryRepository categoryRepository)
        {
            _repositorySampleDomainUnitOfWork = repositorySampleDomainUnitOfWork;
            _categoryRepository = categoryRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Post(string title)
        {
            var category = new Category(title);
            //we have implemented savechange
            //_repositorySampleDomainUnitOfWork.BeginTransaction();
            _categoryRepository.Add(category);
            await _categoryRepository.SaveChangesAsync();
            //_repositorySampleDomainUnitOfWork.CommitTransaction();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Put(long id,string title)
        {
            var category = _categoryRepository.Get(id);
            category.SetTitle(title);                        
            
            await _categoryRepository.SaveChangesAsync();
            
            return Ok();
        }
    }
}

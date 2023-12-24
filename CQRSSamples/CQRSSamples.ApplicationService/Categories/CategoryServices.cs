using CQRSSamples.ApplicationService.Categories.Commands.CreateCategories;
using CQRSSamples.ApplicationService.Categories.Commands.UpdateCategories;
using CQRSSamples.Domain.Categories;
using CQRSSamples.Domain.Categories.Entities;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSSamples.ApplicationService.Categories
{
    public class CategoryServices
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryServices(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task Handle(CreateCategory createCategory)
        {
            var category = new Category(createCategory.CategoryName);            
            _categoryRepository.Add(category);
            await _categoryRepository.SaveChangesAsync();            
        }

        public async Task Handle(UpdateCategory updateCategory)
        {
            var category = _categoryRepository.Get(updateCategory.CategoryId);
            category.SetTitle(updateCategory.CategoryName);

            await _categoryRepository.SaveChangesAsync();
            
        }
    }
}

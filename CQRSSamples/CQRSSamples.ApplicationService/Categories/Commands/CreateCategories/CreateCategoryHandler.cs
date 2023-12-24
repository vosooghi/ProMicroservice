using CQRSSamples.Domain.Categories;
using CQRSSamples.Domain.Categories.Entities;
using CQRSSamples.Framework;

namespace CQRSSamples.ApplicationService.Categories.Commands.CreateCategories
{
    public class CreateCategoryHandler : ICommandHandler<CreateCategory>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task Handle(CreateCategory createCategory)
        {
            var category = new Category(createCategory.CategoryName);
            _categoryRepository.Add(category);
            await _categoryRepository.SaveChangesAsync();
        }
    }
}

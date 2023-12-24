using CQRSSamples.Domain.Categories;
using CQRSSamples.Framework;

namespace CQRSSamples.ApplicationService.Categories.Commands.UpdateCategories
{
    public class UpdateCategoryHandler : ICommandHandler<UpdateCategory>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task Handle(UpdateCategory updateCategory)
        {
            var category = _categoryRepository.Get(updateCategory.CategoryId);
            category.SetTitle(updateCategory.CategoryName);

            await _categoryRepository.SaveChangesAsync();
        }
    }
}

using BasicInfo.Core.Contracts.Categoires.Commands.CreateCategories;
using BasicInfo.Core.Contracts.Categoires.DAL;
using BasicInfo.Core.Domain.Categoris.Entities;
using BasicInfo.Core.Domain.Keywords.ValueObjects;
using Ground.Core.ApplicationServices.Commands;
using Ground.Core.RequestResponse.Commands;
using Ground.Utilities;

namespace BasicInfo.Core.ApplicationServices.Categories.Commands.CreateCategories
{
    public class CreateCategoryCommandHandler : CommandHandler<CreateCategory,long>
    {
        private readonly ICategoryCommandRepository _repository;

        public CreateCategoryCommandHandler(GroundServices groundServices,ICategoryCommandRepository repository) : base(groundServices)
        {
            _repository = repository;
        }

        public override async Task<CommandResult<long>> Handle(CreateCategory command)
        {
            Category category = new(command.Name, command.Title);
            await _repository.InsertAsync(category);
            await _repository.CommitAsync();
            return Ok(category.Id);
        }
    }
}

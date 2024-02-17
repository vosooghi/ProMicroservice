using BasicInfo.Core.Contracts.Categoires.DAL;
using BasicInfo.Core.Domain.Categoris.Entities;
using BasicInfo.Infra.Data.Sql.Commands.Common;
using Ground.Infra.Data.Sql.Commands;

namespace BasicInfo.Infra.Data.Sql.Commands.Categories
{
    public class CategoryCommandRepository : BaseCommandRepository<Category, BasicInfoCommandDbContext>, ICategoryCommandRepository
    {
        public CategoryCommandRepository(BasicInfoCommandDbContext dbContext) : base(dbContext)
        {
        }
    }
}

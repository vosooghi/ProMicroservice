using BasicInfo.Core.Domain.Categoris.Entities;
using Ground.Core.Contracts.Data.Commands;

namespace BasicInfo.Core.Contracts.Categoires.DAL
{
    public interface ICategoryCommandRepository:ICommandRepository<Category,long>
    {

    }
}

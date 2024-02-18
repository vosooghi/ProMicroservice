using Ground.Core.Contracts.Data.Commands;

namespace NewsCMS.Core.Contracts.News.DAL
{
    public interface INewsCommandRepository:ICommandRepository<NewsCMS.Core.Domain.News.Entities.News,long>
    {
    }
}

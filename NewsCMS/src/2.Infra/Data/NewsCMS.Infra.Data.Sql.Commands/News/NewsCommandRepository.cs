using Ground.Infra.Data.Sql.Commands;
using NewsCMS.Core.Contracts.News.DAL;
using NewsCMS.Infra.Data.Sql.Commands.Common;

namespace NewsCMS.Infra.Data.Sql.Commands.News
{
    public class NewsCommandRepository : BaseCommandRepository<Core.Domain.News.Entities.News, NewsCMSCommandDbContext>, INewsCommandRepository
    {
        public NewsCommandRepository(NewsCMSCommandDbContext dbContext) : base(dbContext)
        {
        }
    }
}

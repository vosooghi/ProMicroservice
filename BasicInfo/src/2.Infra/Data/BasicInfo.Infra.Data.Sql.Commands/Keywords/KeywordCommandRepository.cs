using BasicInfo.Core.Contracts.Keywords.Dal;
using BasicInfo.Core.Domain.Keywords.Entities;
using BasicInfo.Infra.Data.Sql.Commands.Common;
using Ground.Infra.Data.Sql.Commands;

namespace BasicInfo.Infra.Data.Sql.Commands.Keywords
{
    public class KeywordCommandRepository : BaseCommandRepository<Keyword, BasicInfoCommandDbContext>, IKeywordCommandRepository
    {
        public KeywordCommandRepository(BasicInfoCommandDbContext dbContext) : base(dbContext)
        {
        }
    }
}

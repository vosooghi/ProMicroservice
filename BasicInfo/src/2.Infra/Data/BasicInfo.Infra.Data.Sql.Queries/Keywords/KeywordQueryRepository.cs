using BasicInfo.Core.Contracts.Keywords.Dal;
using BasicInfo.Core.Contracts.Keywords.Queries.SearchTitleAndStatus;
using BasicInfo.Infra.Data.Sql.Queries.Common;
using Ground.Core.RequestResponse.Queries;
using Ground.Infra.Data.Sql.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicInfo.Infra.Data.Sql.Queries.Keywords
{
    public class KeywordQueryRepository : BaseQueryRepository<BasicInfoQueryDbContext>, IKeywordQueryRepository
    {
        public KeywordQueryRepository(BasicInfoQueryDbContext dbContext) : base(dbContext)
        {
        }

        public PageData<KeywordSearchResult> Query(TitleAndStatus titleAndStatus)
        {
            PageData<KeywordSearchResult> result = new();
            var query = _dbContext.keywords.AsNoTracking();
            if (titleAndStatus.Status.HasValue)
            {
                query = query.Where(w => w.Status == titleAndStatus.Status.Value);
            }
            if (!string.IsNullOrEmpty(titleAndStatus.Title))
            {
                query = query.Where(w => w.Title.StartsWith(titleAndStatus.Title));
            }
            result.QueryResult = query.OrderBy(w => w.Title).Skip(titleAndStatus.SkipCount).Take(titleAndStatus.PageSize)
                                .Select(w => new KeywordSearchResult
                                {
                                    Title = w.Title,
                                    Status = w.Status,
                                    BusinessId = w.BusinessId,
                                    Id = w.Id
                                }).ToList();
            if (titleAndStatus.NeedTotalCount)//need Pagination
                result.TotalCount = query.Count();
            return result;
        }
    }
}

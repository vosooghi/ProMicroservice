using Ground.Core.RequestResponse.Queries;
using Ground.Infra.Data.Sql.Queries;
using Microsoft.EntityFrameworkCore;
using NewsCMS.Core.Contracts.News.DAL;
using NewsCMS.Core.Contracts.News.Queries.NewsDetailes;
using NewsCMS.Core.Contracts.News.Queries.NewsLists;
using NewsCMS.Infra.Data.Sql.Queries.Common;

namespace NewsCMS.Infra.Data.Sql.Queries.News
{
    public class NewsQueryRepository : BaseQueryRepository<NewsCMSQueryDbContext>, INewsQueryRepository
    {
        public NewsQueryRepository(NewsCMSQueryDbContext dbContext) : base(dbContext)
        {
        }


        public PageData<NewsListResult> Query(NewsList newsList)
        {
            PageData<NewsListResult> result = new();
            var query = _dbContext.News.AsNoTracking();

            result.QueryResult = query.OrderByDescending(c => c.Id).Skip(newsList.SkipCount)
                        .Take(newsList.PageSize)
                        .Select(c => new NewsListResult
                        {
                            Description = c.Description,
                            InsertDate = c.CreatedDateTime,
                            Title = c.Title,
                            Id = c.Id
                        }).ToList();


            if (newsList.NeedTotalCount)
            {
                result.TotalCount = query.Count();
            }

            return result;
        }

        public NewsDetaileResult Query(NewsDetaile newsDetaile)
        {
            return _dbContext.News.Include(c => c.NewsKeywords).ThenInclude(c => c.Keyword).Where(c => c.Id == newsDetaile.NewsId).Select(c => new NewsDetaileResult
            {
                Body = c.Body,
                Id = c.Id,
                Description = c.Description,
                InsertDate = c.CreatedDateTime,
                Title = c.Title,
                Keywords = c.NewsKeywords.Select(w=>w.BusinessId).ToList(),
            }).FirstOrDefault();
        }
    }
}

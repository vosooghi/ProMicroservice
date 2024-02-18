using Ground.Core.Contracts.Data.Queries;
using Ground.Core.RequestResponse.Queries;
using NewsCMS.Core.Contracts.News.Queries.NewsDetailes;
using NewsCMS.Core.Contracts.News.Queries.NewsLists;

namespace NewsCMS.Core.Contracts.News.DAL
{
    public interface INewsQueryRepository : IQueryRepository
    {
        PageData<NewsListResult> Query(NewsList newsList);
        NewsDetaileResult Query(NewsDetaile newsDetaile);
    }
}

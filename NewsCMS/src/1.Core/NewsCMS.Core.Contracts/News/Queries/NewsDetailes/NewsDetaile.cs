using Ground.Core.RequestResponse.Queries;

namespace NewsCMS.Core.Contracts.News.Queries.NewsDetailes
{
    public class NewsDetaile : IQuery<NewsDetaileResult>
    {
        public long NewsId { get; set; }

    }
}

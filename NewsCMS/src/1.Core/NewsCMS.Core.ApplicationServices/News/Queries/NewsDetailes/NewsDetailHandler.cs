using Ground.Core.ApplicationServices.Queries;
using Ground.Core.RequestResponse.Queries;
using Ground.Utilities;
using NewsCMS.Core.Contracts.News.DAL;
using NewsCMS.Core.Contracts.News.Queries.NewsDetailes;

namespace NewsCMS.Core.ApplicationServices.News.Queries.NewsDetailes
{
    public class NewsDetailHandler : QueryHandler<NewsDetaile, NewsDetaileResult>
    {
        private readonly INewsQueryRepository _repository;

        public NewsDetailHandler(GroundServices groundServices, INewsQueryRepository repository) : base(groundServices)
        {
            _repository = repository;
        }

        public override Task<QueryResult<NewsDetaileResult>> Handle(NewsDetaile query)
        {
            var result = _repository.Query(query);
            return ResultAsync(result);
        }
    }
}

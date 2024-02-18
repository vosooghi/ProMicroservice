using Ground.Core.ApplicationServices.Queries;
using Ground.Core.RequestResponse.Queries;
using Ground.Utilities;
using NewsCMS.Core.Contracts.News.DAL;
using NewsCMS.Core.Contracts.News.Queries.NewsLists;

namespace NewsCMS.Core.ApplicationServices.News.Queries.NewsLists
{
    public class NewsListHandler : QueryHandler<NewsList, PageData<NewsListResult>>
    {
        private readonly INewsQueryRepository _repository;

        public NewsListHandler(GroundServices groundServices, INewsQueryRepository repository) : base(groundServices)
        {
            _repository = repository;
        }

        public override Task<QueryResult<PageData<NewsListResult>>> Handle(NewsList request)
        {
            var result = _repository.Query(request);
            return ResultAsync(result);
        }
    }
}

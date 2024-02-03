using BasicInfo.Core.Contracts.Keywords.Dal;
using BasicInfo.Core.Contracts.Keywords.Queries.SearchTitleAndStatus;
using Ground.Core.ApplicationServices.Queries;
using Ground.Core.RequestResponse.Queries;
using Ground.Utilities;

namespace BasicInfo.Core.ApplicationServices.Keywords.Queries.SearchTitleAndStatus
{
    public class TitleAndStatusHandler : QueryHandler<TitleAndStatus, PageData<KeywordSearchResult>>
    {
        private readonly IKeywordQueryRepository _repository;

        public TitleAndStatusHandler(GroundServices groundServices,IKeywordQueryRepository repository) : base(groundServices)
        {
            _repository = repository;
        }

        public override async Task<QueryResult<PageData<KeywordSearchResult>>> Handle(TitleAndStatus query)
        {
            var result = _repository.Query(query);
            return await ResultAsync(result);
        }
    }
}

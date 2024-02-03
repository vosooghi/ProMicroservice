using BasicInfo.Core.Contracts.Keywords.Queries.SearchTitleAndStatus;
using Ground.Core.Contracts.Data.Queries;
using Ground.Core.RequestResponse.Queries;

namespace BasicInfo.Core.Contracts.Keywords.Dal
{
    public interface IKeywordQueryRepository : IQueryRepository
    {
        public PageData<KeywordSearchResult> Query(TitleAndStatus titleAndStatus);
    }
}

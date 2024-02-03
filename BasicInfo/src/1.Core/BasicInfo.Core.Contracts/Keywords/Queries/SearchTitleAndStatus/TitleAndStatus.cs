using BasicInfo.Core.Domain.Keywords.Entities;
using Ground.Core.RequestResponse.Queries;

namespace BasicInfo.Core.Contracts.Keywords.Queries.SearchTitleAndStatus
{
    public class TitleAndStatus:PageQuery<PageData<KeywordSearchResult>>
    {
        public  string Title { get; set; }
        public  KeywordStatus? Status { get; set; }
    }
}

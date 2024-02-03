using BasicInfo.Core.Domain.Keywords.Entities;

namespace BasicInfo.Core.Contracts.Keywords.Queries.SearchTitleAndStatus
{
    public class KeywordSearchResult
    {
        public long Id { get; set; }
        public Guid BusinessId { get; set; }
        public KeywordStatus Status { get; set; }
        public string Title { get; set; }
    }
}

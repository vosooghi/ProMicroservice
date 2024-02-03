using BasicInfo.Core.Domain.Keywords.Entities;

namespace BasicInfo.Infra.Data.Sql.Queries.Keywords.Entities
{
    public class Keyword
    {
        public long Id { get; set; }
        public  Guid BusinessId { get; set; }
        public KeywordStatus Status { get; set; }
        public  string Title { get; set; }
    }
}

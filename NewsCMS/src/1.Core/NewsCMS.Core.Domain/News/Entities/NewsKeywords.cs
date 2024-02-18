using Ground.Core.Domain.Entities;
using Ground.Core.Domain.ValueObjects;

namespace NewsCMS.Core.Domain.News.Entities
{
    public class NewsKeywords:Entity
    {
        public BusinessId KeywordBusinessId { get; set; }
    }
}

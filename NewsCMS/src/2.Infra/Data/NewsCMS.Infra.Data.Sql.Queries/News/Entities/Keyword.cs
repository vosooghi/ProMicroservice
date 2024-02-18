using System.ComponentModel.DataAnnotations;

namespace NewsCMS.Infra.Data.Sql.Queries.News.Entities
{
    public class Keyword
    {
        [Key]
        public Guid KeywordBusinessId { get; set; }
        public string KeywordTitle { get; set; }
    }
}

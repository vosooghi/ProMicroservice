namespace NewsCMS.Infra.Data.Sql.Queries.News.Entities
{
    public class NewsKeywords
    {
        public long Id { get; set; }
        public Guid BusinessId { get; set; }
        public long NewsId { get; set; }
        //public Guid KeywordBusinessId { get; set; }
        public Keyword Keyword { get; set; }

    }
}

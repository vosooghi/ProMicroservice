namespace NewsCMS.Infra.Data.Sql.Queries.News.Entities
{
    public class News
    {
        public long Id { get; set; }
        public Guid BusinessId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public DateTime CreatedDateTime { get; set; }
        public List<NewsKeywords> NewsKeywords { get; set; }

    }
}

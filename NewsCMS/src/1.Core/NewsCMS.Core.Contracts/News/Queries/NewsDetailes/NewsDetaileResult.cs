namespace NewsCMS.Core.Contracts.News.Queries.NewsDetailes
{
    public sealed class NewsDetaileResult
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public List<Guid> Keywords { get; set; }
        public DateTime InsertDate { get; set; }

    }
}

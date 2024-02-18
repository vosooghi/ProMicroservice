namespace NewsCMS.Core.Contracts.News.Queries.NewsLists
{
    public sealed class NewsListResult
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime InsertDate { get; set; }

    }
}

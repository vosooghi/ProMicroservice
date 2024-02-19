namespace NewsCMSClient.Models.NewsViewModels
{
    public class NewsListModel
    {
        public NewsListItem[] queryResult { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public int totalCount { get; set; }
    }
}

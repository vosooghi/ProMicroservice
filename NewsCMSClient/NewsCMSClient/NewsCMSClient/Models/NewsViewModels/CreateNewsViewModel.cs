namespace NewsCMSClient.Models.NewsViewModels
{
    public class CreateNewsViewModel
    {
        #region Props
        public Guid BusunessId { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public List<Guid> KeywordsId { get; set; }
        #endregion
    }
}

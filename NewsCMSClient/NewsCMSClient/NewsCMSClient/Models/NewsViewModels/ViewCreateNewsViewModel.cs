namespace NewsCMSClient.Models.NewsViewModels
{
    public class ViewCreateNewsViewModel
    {
        public CreateNewsViewModel SaveModel { get; set; }
        public Dictionary<string, string> Keywords { get; set; } = new Dictionary<string, string>();
    }
}

using Ground.Core.RequestResponse.Commands;

namespace NewsCMS.Core.Contracts.News.Commands.CreateNews
{
    public class CreateNewsCommand : ICommand<long>
    {
        #region Props
        public string Title { get;  set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public List<Guid> KeywordsId { get; set; }
        #endregion
    }
}

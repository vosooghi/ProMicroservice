using Ground.Core.Domain.Events;

namespace NewsCMS.Core.Domain.News.Events
{
    public class NewsCreated:IDomainEvent
    {
        #region Props
        public Guid BusinessId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Body { get; private set; }
        public string Keyword { get; private set; }
        #endregion

        #region Ctors
        public NewsCreated(Guid businessId, string title, string description, string body, string keywords)
        {
            BusinessId = businessId;
            Title = title;
            Description = description;
            Body = body;
            Keyword = keywords;
        }
        #endregion
    }
}

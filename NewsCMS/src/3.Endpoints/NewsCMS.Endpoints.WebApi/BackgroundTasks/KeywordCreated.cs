using Ground.Core.Domain.Events;

namespace NewsCMS.Endpoints.WebApi.BackgroundTasks
{
    public class KeywordCreated : IDomainEvent
    {
        public Guid BusinessId { get; set; }
        public string Title { get; set; }
        public KeywordCreated(Guid businessId, string title)
        {
            BusinessId = businessId;
            Title = title;
        }
    }
}

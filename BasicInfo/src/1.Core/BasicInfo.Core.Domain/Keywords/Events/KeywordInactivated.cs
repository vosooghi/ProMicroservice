using Ground.Core.Domain.Events;

namespace BasicInfo.Core.Domain.Keywords.Events
{
    public class KeywordInactivated : IDomainEvent
    {
        public Guid BusinessId { get; set; }
        public KeywordInactivated(Guid businessId)
        {
            BusinessId = businessId;
        }
    }
}

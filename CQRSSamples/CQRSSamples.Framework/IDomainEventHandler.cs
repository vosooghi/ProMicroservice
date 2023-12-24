namespace CQRSSamples.Framework
{
    public interface IDomainEventHandler<TDomainEvent> where TDomainEvent : IDomainEvent
    {
        Task Handel(TDomainEvent domainEvent);
    }
}

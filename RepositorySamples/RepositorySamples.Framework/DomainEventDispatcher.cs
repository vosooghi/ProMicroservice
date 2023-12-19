using Microsoft.Extensions.DependencyInjection;

namespace RepositorySamples.Framework
{
    public class DomainEventDispatcher : IDomainEventDispatcher
    {
        private IServiceProvider _services;
        public DomainEventDispatcher(IServiceProvider service)
        {
            _services = service;
        }

        public Task Dispatch(IEnumerable<IDomainEvent> events)
        {
            foreach (dynamic @event in events)
            {
                DispatchEvent(@event);
            }
            return Task.CompletedTask;
        }
        public Task DispatchEvent<TDomainEvent>(TDomainEvent @event) where TDomainEvent : IDomainEvent
        {
            var handlers = _services.GetServices<IDomainEventHandler<TDomainEvent>>().ToList();
            foreach (var handler in handlers)
            {
                handler.Handel(@event);
            }
            return Task.CompletedTask;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingSample.Framework
{
    public class AggregateRoot:Entity
    {
        //nobody can change events expect the entity
        private readonly List<IDomainEvent> _events = new List<IDomainEvent>();
        public IReadOnlyList<IDomainEvent> Events => _events;
        public  int Version { get;private set; }
        public AggregateRoot(IReadOnlyList<IDomainEvent> events)
        {
            if (events == null || events.Count == 0) return;
            foreach (var item in events)
            {
                Mutate(item);
                Version++;
            }
        }
        public AggregateRoot()
        {
            
        }
        protected void AddEvent(IDomainEvent e)
        {
            _events.Add(e);
        }
        public void Apply(IDomainEvent @event)
        {
            Mutate(@event);
            AddEvent(@event);
        }
        public void Mutate(IDomainEvent @event)
        {
            ((dynamic)this).On((dynamic)@event);
        }
        public void ClearEvent()
        {
            _events.Clear();
        }
    }
}

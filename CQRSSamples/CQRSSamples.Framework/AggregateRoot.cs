using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSSamples.Framework
{
    public class AggregateRoot : Entity
    {
        //nobody can change events expect the entity
        private readonly List<IDomainEvent> _events = new List<IDomainEvent>();
        public IReadOnlyList<IDomainEvent> Events => _events;
        protected void AddEvent(IDomainEvent e)
        {
            _events.Add(e);
        }

        public void ClearEvent()
        {
            _events.Clear();
        }
    }
}

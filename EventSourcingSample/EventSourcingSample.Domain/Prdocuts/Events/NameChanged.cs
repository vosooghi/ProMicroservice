using EventSourcingSample.Framework;

namespace EventSourcingSample.Domain.Prdocuts.Events
{
    public class NameChanged:IDomainEvent
    {
        public long Id { get; }
        public string Name { get; }
        public NameChanged(long id, string name)
        {
            
            Id = id;
            Name = name;
        }
    }
}

using EventSourcingSample.Framework;

namespace EventSourcingSample.Domain.Prdocuts.Events
{
    public class PriceChanged:IDomainEvent
    {
        public long Id { get; }
        public int Price { get; }
        public PriceChanged(long id, int price)
        {
            Id = id;
            Price = price;
        }
    }
}

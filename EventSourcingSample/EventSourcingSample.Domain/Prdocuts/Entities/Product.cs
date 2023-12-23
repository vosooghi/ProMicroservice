using EventSourcingSample.Domain.Prdocuts.Events;
using EventSourcingSample.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingSample.Domain.Prdocuts.Entities
{
    public class Product : AggregateRoot
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public Product(long id, string name, string description, int price)
        {
            //validation ...
            /*
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            AddEvent(new ProductCreated(id, name, description, price));*/

            Apply(new ProductCreated(id, name, description, price));
        }
        public Product(IReadOnlyList<IDomainEvent> domainEvents):base(domainEvents)
        {
            //Type 1
            //foreach (var item in domainEvents)
            //{
            //    switch (item)
            //    {
            //        case ProductCreated pc:
            //            On(pc);
            //            break;
            //        case PriceChanged priceChanged:
            //            On(priceChanged);
            //            break;
            //        case NameChanged nc:
            //            On(nc);
            //            break;
            //        default:
            //            break;
            //    }
            //    Version++;
            //}
        }
        public void ChangePrice(int newValue)
        {
            //Price = newValue;
            //AddEvent(new PriceChanged(Id, newValue));
            Apply(new PriceChanged(Id, newValue));
        }
        public void ChangeName(string newValue)
        {
            //Name = newValue;
            //AddEvent(new NameChanged(Id, newValue));
            Apply(new NameChanged(Id, newValue));
        }

        public void On(ProductCreated productCreated)
        {
            Id = productCreated.Id;
            Name = productCreated.Name;
            Description = productCreated.Description;
            Price = productCreated.Price;
        }
        public void On(NameChanged nameChanged) {
            Name = nameChanged.Name;

        }
        public void On(PriceChanged priceChanged) {
            Price = priceChanged.Price;
        }
    }

}

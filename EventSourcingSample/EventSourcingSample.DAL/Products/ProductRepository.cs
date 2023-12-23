using EventSourcingSample.Domain.Prdocuts;
using EventSourcingSample.Domain.Prdocuts.Entities;
using EventSourcingSample.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingSample.DAL.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly IEventStore _eventStore;
        public ProductRepository(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }
        public Product Get(long id)
        {
            string typeName = typeof(Product).Name;
            var events = _eventStore.GetAll(typeName, id);
            return new Product(events);
        }


        public void Save(Product aggregate)
        {
            var events = aggregate.Events;
            string typeName = typeof(Product).Name;
            _eventStore.Save(typeName, aggregate.Id, aggregate.Version, events);
        }
    }
}

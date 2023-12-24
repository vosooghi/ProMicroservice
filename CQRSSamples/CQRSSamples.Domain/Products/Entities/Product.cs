using CQRSSamples.Domain.Products.Events;
using CQRSSamples.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSSamples.Domain.Products.Entities
{
    public class Product : AggregateRoot
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int CategoryId { get; private set; }
        public int Price { get; private set; }
        private List<Discount> _discounts = new List<Discount>();
        public IReadOnlyList<Discount> Discounts => _discounts;
        public Product(string title, string description, int price, int categoryId)
        {
            //validation
            Title = title;
            Description = description;
            Price = price;
            CategoryId = categoryId;
            AddEvent(new ProductCreated(title, description, price, categoryId));
        }
        public void AddDiscount(string title, int value)
        {
            Discount discount = new Discount(title, value);
            _discounts.Add(discount);

            AddEvent(new DiscountCreated(title, value, Id));
        }
    }
}

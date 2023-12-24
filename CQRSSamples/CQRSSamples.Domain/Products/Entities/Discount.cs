using CQRSSamples.Framework;

namespace CQRSSamples.Domain.Products.Entities
{
    public class Discount : Entity
    {
        public int Value { get; private set; }
        public string Title { get; private set; }
        public Discount(string title, int value)
        {
            Value = value;
            Title = title;
        }
    }
}

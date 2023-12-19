using RepositorySamples.Framework;

namespace RepositorySamples.Domain.Products.Events
{
    public class ProductCreated : IDomainEvent
    {
        public string Title { get; }
        public string Description { get; }
        public int CategoryId { get; }
        public int Price { get; }
        public ProductCreated(string title, string description, int price, int categoryId)
        {
            //validation
            Title = title;
            Description = description;
            Price = price;
            CategoryId = categoryId;
        }
    }
}

using DomainModelingBuildingBlock.Aggregate.Products;

namespace DomainModelingBuildingBlock.Aggregate.Orders
{
    public class OrderLine
    {
        public int OrderId { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
    }
}

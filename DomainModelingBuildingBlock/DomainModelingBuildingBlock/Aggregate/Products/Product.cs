using DomainModelingBuildingBlock.Aggregate.Orders;

namespace DomainModelingBuildingBlock.Aggregate.Products
{
    /// <summary>
    /// Product Aggregate
    /// </summary>
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        
    }
}

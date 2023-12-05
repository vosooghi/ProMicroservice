using DomainModelingBuildingBlock.Aggregate.Customers;

namespace DomainModelingBuildingBlock.Aggregate.Orders
{
    /// <summary>
    /// Order Aggregate
    /// </summary>
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public List<OrderLine> OrderLines { get; set; }
    }
}

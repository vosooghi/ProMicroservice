using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModelingBuildingBlock.DomainServices
{
    public enum CustomerType
    {
        Gold,
        Silver,
        Bronze
    }
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CustomerType CustomerType { get; set; }
    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
    }

    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public List<OrderLine> OrderLines { get; set; }
    }

    public class OrderLine
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
    }

    /// <summary>
    /// Domain Service
    /// </summary>
    public class ShippingCustCalculator
    {
        public int Calculate(Customer customer,Order order)
        {
            //Calculate shipping cost
            return 0;
        }
    }
}

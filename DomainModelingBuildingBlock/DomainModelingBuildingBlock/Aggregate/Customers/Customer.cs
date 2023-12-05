using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModelingBuildingBlock.Aggregate.Orders;

namespace DomainModelingBuildingBlock.Aggregate.Customers
{
    /// <summary>
    /// Customer Aggregate
    /// </summary>
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
    }
}

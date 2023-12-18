using AggregateSamples.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction.Orders
{
    public class Order:AggregateRoot
    {
        public Order(int addressLineId,DateTime orderDate,List<OrderLine> orderLines)
        {
            if (addressLineId < 1) throw new InvalidDataException("AddressLine");
            AddressLineId = addressLineId;
            OrderDate = orderDate;
            _orderLines = orderLines;
        }
        public int OrderId { get; set; }
        public  DateTime OrderDate { get; set; }
        public int AddressLineId { get; set; }
        private readonly List<OrderLine> _orderLines = new List<OrderLine>();
        public IReadOnlyList<OrderLine> OrderLines => _orderLines;
    }
}

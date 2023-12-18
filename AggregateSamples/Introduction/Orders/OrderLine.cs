using AggregateSamples.Framework;

namespace Introduction.Orders
{
    public class OrderLine:Entity
    {
        public int LineId { get; set; }
        public int ProductId { get; set; }
        public  int Price { get; set; }
    }
}

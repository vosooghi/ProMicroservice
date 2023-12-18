using AggregateSamples.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction.Products
{
    public class Product:AggregateRoot
    {
        public string Name { get; set; }        
        public Discount Discount { get; set; }
        public int Price { get; set; }
        public void AddDiscount(int value)
        {
            //business rules
            Discount = new Discount
            {
                DiscountValue = value
            };
        }
    }
}

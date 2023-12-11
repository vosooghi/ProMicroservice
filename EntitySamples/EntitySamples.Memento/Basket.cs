using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitySamples.Memento
{
    public class Basket
    {
        public  int Id { get; set; }
        public  int Cost { get; set; }
        private List<BasketItem> items = new List<BasketItem>();
        public BasketSnapshot GetBasketSnapshot()
        {
            return new BasketSnapshot { Id=1, Cost=0 };
        }
        public void LoadSnapshot(BasketSnapshot basketSnapshot)
        {
            Id = basketSnapshot.Id;
            Cost = basketSnapshot.Cost;
        }
        public void AddToBasket(Basket basket)
        {

        }

    }
    public class BasketSnapshot
    {
        public int Id { get; set; }
        public int Cost { get; set; }
    }
    public class BasketItem
    {
        
    }
}

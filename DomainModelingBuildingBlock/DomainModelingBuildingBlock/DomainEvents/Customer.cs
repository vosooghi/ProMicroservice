using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModelingBuildingBlock.DomainEvents
{
    public enum CustomerType
    {
        Gold, Silver, Bronze
    }
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CustomerType CutomerType { get; set; }

        public Customer CreateGoldCustomer(int id, string name)
        {
            return new Customer(id, name, CustomerType.Gold);
        }
        public Customer(int Id, string Name, CustomerType customerType)
        {

        }

        public void ChangeStateIfNeeded(int totalOrder)
        {
            if (totalOrder < 10) this.CutomerType = CustomerType.Bronze;
            else if (totalOrder < 20) this.CutomerType = CustomerType.Silver;
            else if (totalOrder >= 20) this.CutomerType = CustomerType.Gold;
        }
    }
}

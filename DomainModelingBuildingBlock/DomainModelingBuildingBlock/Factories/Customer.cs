using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModelingBuildingBlock.Factories
{
    public enum CustomerType
    {
        Gold,Silver,Bronze
    }
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public  CustomerType CutomerType { get; set; }

        public Customer CreateGoldCustomer(int id, string name)
        {
            return new Customer(id,name, CustomerType.Gold);
        }
        public Customer(int Id,string Name,CustomerType customerType)
        {
            
        }
    }
}

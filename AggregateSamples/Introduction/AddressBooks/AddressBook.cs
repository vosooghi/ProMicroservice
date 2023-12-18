using AggregateSamples.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction.AddressBooks
{
    public class AddressBook:AggregateRoot
    {
        public  int  CustomerId { get; set; }
        private readonly List<AddressLine> _addressLines  = new();
        public IReadOnlyList<AddressLine> AddressLines => _addressLines;
        public void AddAddressLine(string address,string city,bool isDefault)
        {
            AddressLine addressLine = new AddressLine
            {
                Address = address,
                City = city,
                IsDefault = isDefault
            };
            if(isDefault)
                foreach (var item in _addressLines)
                {
                    item.IsDefault = false;
                }
            _addressLines.Add(addressLine);
        }
        public AddressLine GetDefaultAddress()
        {
            return AddressLines.Where(w=>w.IsDefault==true).FirstOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationArchitectureSample.Core.Domain
{
    public class PhoneNumber
    {
        public int ID { get; set; }
        public string Number { get; set; }
        private PhoneNumber()
        {
            
        }
        public PhoneNumber(string number)
        {
            if (number == null) throw new ArgumentNullException("Invalid input for Phone number");
            Number = number;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueObjects.Samples.ValueObjectCollection
{
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //we can not indicate which phone number is desired to update,delete
        //public List<PhoneNumber> PhoneNumbers { get; set; }
        public PhoneBook PhoneBook { get; set; }
    }

    /// <summary>
    /// this code is more clear
    /// </summary>
    public class PhoneBook
    {
        public PhoneNumber HomeNumber { get;private set; }
        public PhoneNumber MobileNumber { get; private set; }
        public PhoneNumber WorkNumber { get; private set; }

        public PhoneBook(PhoneNumber homeNumber) {
        //validate

        }
    }
    public class PhoneNumber
    {
        public string Value { get; private set; }
        public PhoneNumber(string value) { Value = value; }
    }
}

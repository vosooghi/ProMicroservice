using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationArchitectureSample.Core.Domain
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<PhoneNumber> PhoneNumbers { get; set; } = new List<PhoneNumber>();

        private Person() { }
        public Person(string  name, string lastName, PhoneNumber phoneNumber)
        {
            if(name == null || lastName==null|| phoneNumber==null) throw new ArgumentNullException("Invalid input for person");
            Name = name;
            LastName = lastName;
            PhoneNumbers.Add(phoneNumber);
        }

        public void AddPhoneNumber(PhoneNumber phoneNumber)
        {
            if (PhoneNumbers.Any(w => w.Number == phoneNumber.Number)) throw new InvalidDataException("Duplicate phone number");
            PhoneNumbers.Add(phoneNumber);
        }
    }
}


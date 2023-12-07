using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueObjects.Framework
{
    public class FullNameV1 : BaseValueObjectV1<FullNameV1>
    {
        public  string FirstName { get; set; }
        public string LastName { get; set; }
        public override int ObjectGetHashCode()
        {
            return FirstName.GetHashCode() ^ LastName.GetHashCode();
        }
        public FullNameV1(string firstName,string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public override bool ObjectIsEqual(FullNameV1? other)
        {
            return FirstName==other.FirstName && LastName==other.LastName;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModelingBuildingBlock.ValueObjects
{
    public class FirstName
    {
        public string Value { get; private set; }

        public FirstName(string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            Value = value;
        }

        public FirstName SetFirstName(string value)
        {
            return new FirstName(value);
        }

        public override bool Equals(object? obj)
        {
            var other = obj as FirstName;
            if (other == null) return false;
            return other.Value ==Value;
        }
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}

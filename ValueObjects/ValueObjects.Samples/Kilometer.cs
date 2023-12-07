using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueObjects.Samples
{
    public class Kilometer
    {
        public int Distance { get;private set; }

        public Kilometer(int distance) {
            Distance = distance;
        }

        public override bool Equals(object? obj)
        {
            var other = obj as Kilometer;
            if (other == null) return false;
            return Distance == other.Distance;
        }

        public override int GetHashCode()
        {
            return Distance.GetHashCode();
        }

        public static bool operator ==(Kilometer left, Kilometer right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(Kilometer left, Kilometer right)
        {
            return !left.Equals(right);
        }
    }
}

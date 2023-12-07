using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueObjects.Samples
{
    public class Meter
    {
        public int Distance { get; private set; }
        public Meter(int distance) {
            if (distance < 0)
                throw new ValueObjectInvalidState("Distance can not be less than zero");
                //throw new DistanceInMeterCanNotBeLessThanZeroException();
            Distance = distance;
        }

        //Behavior. Value Objects are behavior rich
        public Kilometer ToKilometer(int distance)
        {
            return new Kilometer(distance/1000);
        }
        public Meter AddMeter(Meter meter)
        {
            return new Meter(Distance + meter.Distance);
        }

        //Combinable
        public static Meter operator +(Meter left,Meter right)
        {
            return new Meter(left.Distance + right.Distance);
        }
        public static Meter operator -(Meter left, Meter right)
        {
            return new Meter(left.Distance - right.Distance);
        }
        //Equality rules
        public override bool Equals(object? obj)
        {
            var other = obj as Meter;
            if(other == null) return false;
            return Distance == other.Distance;
        }

        public override int GetHashCode()
        {
            return Distance.GetHashCode();
        }

        public static bool operator ==(Meter left,Meter right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(Meter left,Meter right)
        {
            return !left.Equals(right);
        }
    }
}

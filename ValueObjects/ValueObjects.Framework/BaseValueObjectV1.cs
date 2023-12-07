using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ValueObjects.Framework
{
    public abstract class BaseValueObjectV1<TValueObject> : IEquatable<TValueObject>
        where TValueObject : BaseValueObjectV1<TValueObject>
    {
        public bool Equals(TValueObject? other)
        => this == other;
        public override bool Equals(object? obj)
        {
            return (obj is TValueObject otherObject) && ObjectIsEqual(otherObject);
        }

        public abstract bool ObjectIsEqual(TValueObject? other);

        public override int GetHashCode() => ObjectGetHashCode();

        public abstract int ObjectGetHashCode();
        public static bool operator ==(BaseValueObjectV1<TValueObject> left,BaseValueObjectV1<TValueObject>right)
        {
            if (left == null && right == null) return true;
            if (left == null || right == null) return false;
            return left.Equals(right);
        }
        public static bool operator !=(BaseValueObjectV1<TValueObject> left, BaseValueObjectV1<TValueObject> right)
        =>!(left==right);
    }
}

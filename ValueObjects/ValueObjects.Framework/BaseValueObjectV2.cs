using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueObjects.Framework
{
    public abstract class BaseValueObjectV2<TValueObject> : IEquatable<TValueObject>
        where TValueObject : BaseValueObjectV2<TValueObject>
    {
        public bool Equals(TValueObject? other)
        => this == other;
        public override bool Equals(object? obj)
        {
            return (obj is TValueObject otherObject) && GetEqaulityComponents().SequenceEqual(otherObject.GetEqaulityComponents());
        }

        public abstract IEnumerable<object> GetEqaulityComponents();

        public override int GetHashCode() => GetEqaulityComponents().Select(w => w != null ? w.GetHashCode() : 0).Aggregate((x, y) => x ^ y);
        public static bool operator ==(BaseValueObjectV2<TValueObject> left, BaseValueObjectV2<TValueObject> right)
        {
            if (left == null && right == null) return true;
            if (left == null || right == null) return false;
            return left.Equals(right);
        }
        public static bool operator !=(BaseValueObjectV2<TValueObject> left, BaseValueObjectV2<TValueObject> right)
        => !(left == right);
    }
}

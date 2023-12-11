using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitySamples.Framework
{
    public class BaseEntity:IEquatable<BaseEntity>
    {
        public  long Id { get; set; }

        public bool Equals(BaseEntity? other)
        => this.Id == other.Id;

        public override bool Equals(object? obj)
        {
            return (obj is BaseEntity otherObject) && this.Id==otherObject.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        public static bool operator ==(BaseEntity? left, BaseEntity? right)
        {
            if(left is null || right is null) return false;
            if (left is null && right is null) return true;
            return left.Equals(right);
        }
        public static bool operator !=(BaseEntity? left, BaseEntity? right)
        {
            if (left is null || right is null) return true;
            if (left is null && right is null) return false;
            return left.Equals(right);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSSamples.Framework
{
    public class Entity
    {
        public long Id { get; set; }


        #region Equalities
        public bool Equals(Entity? other)
        => Id == other.Id;

        public override bool Equals(object? obj)
        {
            return obj is Entity otherObject && Id == otherObject.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        public static bool operator ==(Entity? left, Entity? right)
        {
            if (left is null || right is null) return false;
            if (left is null && right is null) return true;
            return left.Equals(right);
        }
        public static bool operator !=(Entity? left, Entity? right)
        {
            if (left is null || right is null) return true;
            if (left is null && right is null) return false;
            return left.Equals(right);
        }
        #endregion
    }
}

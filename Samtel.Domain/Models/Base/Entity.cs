using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samtel.Domain.Models.Base
{
    public abstract class Entity : IEntity
    {
        public Int32 Id { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Entity);
        }

        protected virtual bool Equals(Entity other)
        {
            if (other == null)
                return false;
            if (ReferenceEquals(this, other))
                return true;
            if (!IsTransient(this) &&
                !IsTransient(other) &&
                Equals(Id, other.Id))
            {
                var otherType = other.GetUnproxiedType();
                var thisType = GetUnproxiedType();
                return thisType.IsAssignableFrom(otherType) ||
                       otherType.IsAssignableFrom(thisType);
            }
            return false;
        }

        public static bool operator ==(Entity a, Entity b)
        {
            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            // Return true if the fields match:
            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        private static bool IsTransient(Entity obj)
        {
            return obj != null && Equals(obj.Id, Guid.Empty);
        }

        private Type GetUnproxiedType()
        {
            return GetType();
        }

        public override int GetHashCode()
        {
            if (Equals(Id, Guid.Empty))
                return base.GetHashCode();
            return Id.GetHashCode();
        }
    }
}

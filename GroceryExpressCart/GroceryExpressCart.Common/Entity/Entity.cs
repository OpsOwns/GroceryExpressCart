using System;

namespace GroceryExpressCart.Common.Entity
{
    public class Entity
    {
        public DateTime CreatedAt { get; } = DateTime.UtcNow.Date;
        public DateTime ModifyAt { get; protected set; } = DateTime.UtcNow.Date;
        public int Id { get; protected set; }
        public override bool Equals(object obj)
        {
            var other = obj as Entity;

            if (other is null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (Id == 0 || other.Id == 0)
                return false;

            return Id == other.Id;
        }
        public void SetDateModify(DateTime date) => ModifyAt = date;
        public static bool operator ==(Entity a, Entity b)
        {
            if (a is null && b is null)
                return true;
            if (a is null || b is null)
                return false;
            return a.Equals(b);
        }
        public static bool operator !=(Entity a, Entity b) => !(a == b);
        public override int GetHashCode() => HashCodeGenerator.Of(Id);
    }
}

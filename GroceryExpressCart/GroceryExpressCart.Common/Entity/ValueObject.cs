using System;
using System.Collections.Generic;
using System.Linq;

namespace GroceryExpressCart.Common.Entity
{
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        protected abstract IEnumerable<object> GetEqualityComponents();
        public override bool Equals(object obj)
        {
            var valueObject = obj as T;
            return valueObject == null ? false : EqualsCore(valueObject);
        }
        private bool EqualsCore(ValueObject<T> other) =>
            GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        public override int GetHashCode() =>
             HashCodeGenerator.Of(GetEqualityComponents()
                .Aggregate(1, (current, obj) => (current * 23) + (obj?.GetHashCode() ?? 0)));
        public static bool operator ==(ValueObject<T> a, ValueObject<T> b)
        {
            if (a is null && b is null)
                return true;
            if (a is null || b is null)
                return false;
            return a.Equals(b);
        }
        public static bool operator !=(ValueObject<T> a, ValueObject<T> b) => !(a == b);
    }
}

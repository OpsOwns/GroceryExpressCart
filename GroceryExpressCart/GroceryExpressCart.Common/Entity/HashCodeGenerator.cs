using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace GroceryExpressCart.Common.Entity
{
    public sealed class HashCodeGenerator : IEquatable<HashCodeGenerator>
    {
        private const int EMPTYCOLLECTIONPRIMENUMBER = 19;
        private readonly int value;
        private HashCodeGenerator(int value) => this.value = value;
        public static implicit operator int(HashCodeGenerator hashCode) => hashCode.value;
        public static bool operator ==(HashCodeGenerator left, HashCodeGenerator right) => left.Equals(right);
        public static bool operator !=(HashCodeGenerator left, HashCodeGenerator right) => !(left == right);
        public static HashCodeGenerator Of<T>(T item) => new HashCodeGenerator(GetHashCode(item));
        public static HashCodeGenerator OfEach<T>(IEnumerable<T> items) =>
            items == null ? new HashCodeGenerator(0) : new HashCodeGenerator(GetHashCode(items, 0));
        public HashCodeGenerator And<T>(T item) => new HashCodeGenerator(CombineHashCodes(value, GetHashCode(item)));
        public HashCodeGenerator AndEach<T>(IEnumerable<T> items) =>
            items is null ? new HashCodeGenerator(value) : new HashCodeGenerator(GetHashCode(items, value));
        public bool Equals(HashCodeGenerator other) => value.Equals(other.value);
        public override bool Equals(object obj) => obj is HashCodeGenerator ? Equals((HashCodeGenerator)obj) : false;
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() =>
            throw new NotSupportedException("Implicitly convert this struct to an int to get the hash code.");
        private static int CombineHashCodes(int h1, int h2)
        {
            unchecked
            {
                return ((h1 << 5) + h1) ^ h2;
            }
        }
        private static int GetHashCode<T>(T item) => item?.GetHashCode() ?? 0;
        private static int GetHashCode<T>(IEnumerable<T> items, int startHashCode)
        {
            var enumerator = items.GetEnumerator();
            return enumerator.MoveNext()
                ? CombineHashCodes(startHashCode, GetHashCode(enumerator.Current))
                : CombineHashCodes(startHashCode, EMPTYCOLLECTIONPRIMENUMBER);
        }
    }
}

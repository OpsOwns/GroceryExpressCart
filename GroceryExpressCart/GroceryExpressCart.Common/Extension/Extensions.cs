namespace GroceryExpressCart.Common.Extension
{
    public static class Extensions
    {
        public static bool IsEmpty(this string value) => string.IsNullOrEmpty(value);
        public static bool Length(this string value, int min, int max) =>
            value.Length >= min && value.Length <= max;
    }
}

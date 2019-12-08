namespace GroceryExpressCart.Common.Extension
{
    public static class Extensions
    {
        public static bool IsEmpty(this string value) => string.IsNullOrEmpty(value);
    }
}

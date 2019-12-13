using Microsoft.Extensions.Configuration;

namespace GroceryExpressCart.Common.Extension
{
    public static class Extensions
    {
        public static bool IsEmpty(this string value) => string.IsNullOrEmpty(value);
        public static bool Length(this string value, int min, int max) =>
            value.Length >= min && value.Length <= max;
        public static TModel GetOptions<TModel>(this IConfiguration configuration, string section) where TModel : new()
        {
            var model = new TModel();
            configuration.GetSection(section).Bind(model);
            return model;
        }
    }
}

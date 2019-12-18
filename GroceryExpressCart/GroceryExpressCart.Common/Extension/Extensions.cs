using GroceryExpressCart.Common.SeedWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using System;

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
        public static IApplicationBuilder UseErrorHandler(this IApplicationBuilder builder)
       => builder.UseMiddleware<GlobalHandleMiddleware>();

        public static long ToTimeStamp(this DateTime dateTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var time = dateTime.Subtract(new TimeSpan(epoch.Ticks));
            return time.Ticks / 10000;
        }
    }
}

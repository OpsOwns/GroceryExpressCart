using GroceryExpressCart.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace GroceryExpressCart.Common.SeedWork
{
    public class GlobalHandleMiddleware
    {
        private readonly RequestDelegate _next;
        public GlobalHandleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleErrorAsync(context, exception);
            }
        }

        private static Task HandleErrorAsync(HttpContext context, Exception exception)
        {
            var errorCode = "error";
            const HttpStatusCode statusCode = HttpStatusCode.BadRequest;
            switch (exception)
            {
                case GroceryException e:
                    errorCode = e.Code;
                    break;
            }
            var response = new { code = errorCode, message = exception.Message };
            var payload = JsonConvert.SerializeObject(response);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsync(payload);
        }
    }
}

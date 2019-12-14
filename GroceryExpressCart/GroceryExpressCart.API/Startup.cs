using Autofac;
using GroceryExpressCart.Common.Exceptions;
using GroceryExpressCart.Common.Extension;
using GroceryExpressCart.Infrastructure.Database;
using GroceryExpressCart.Infrastructure.IoC;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GroceryExpressCart.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options =>
            options.RespectBrowserAcceptHeader = true).
            AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver =
                    new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.Formatting = Formatting.Indented;
            });
            services.AddEntityFrameworkSqlServer().
               AddEntityFrameworkInMemoryDatabase().
               AddDbContext<GroceryContext>();
            services.AddProblemDetails(details =>
            details.Map<GroceryValidationException>(exception =>
            new InvalidCommandProblemDetails(exception)));
            services.AddMiddlewareAnalysis();
        }
        public void ConfigureContainer(ContainerBuilder builder) =>
           builder.RegisterModule(new ContainerModule(Configuration));
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            app.UseRouting();
            app.UseErrorHandler();
            app.UseProblemDetails();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

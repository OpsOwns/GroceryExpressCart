using Autofac;
using GroceryExpressCart.Common.Exceptions;
using GroceryExpressCart.Common.Extension;
using GroceryExpressCart.Common.Security;
using GroceryExpressCart.Infrastructure.Database;
using GroceryExpressCart.Infrastructure.IoC;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Text;

namespace GroceryExpressCart.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services, IWebHostEnvironment en)
        {
            services.AddMvc();
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
            {
                details.Map<GroceryValidationException>(exception =>
                new InvalidCommandProblemDetails(exception));
            });
            services.AddMiddlewareAnalysis();
            var jwtSettings = Configuration.GetOptions<JwtSettings>("JwtSettings");
            services.AddAuthentication(schema =>
            {
                schema.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                schema.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                schema.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.SaveToken = true;
                cfg.RequireHttpsMetadata = false;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),
                    ValidIssuer = jwtSettings.Issuer,
                    ValidateAudience = false
                };
            });
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
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

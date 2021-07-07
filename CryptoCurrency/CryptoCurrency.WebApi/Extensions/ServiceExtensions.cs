using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using System.IO;
using System.Reflection;
using System.Text.Json;

namespace CryptoCurrency.WebApi.Extensions
{
    /// <summary>
    /// Class in charge of registering service extensions
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// Register Swagger
        /// </summary>
        /// <param name="services"></param>
        public static void AddSwaggerExtension(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.IncludeXmlComments(XmlCommentsFilePath);
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "CryptoCurrency.WebApi",
                    Description = "This API will be in charge of being a proxy between clients and cryptocurrency API"
                });
            });
        }

        /// <summary>
        /// Register controllers
        /// </summary>
        /// <param name="services"></param>
        public static void AddControllersExtension(this IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                })
                ;
        }

        /// <summary>
        /// Register policy cors
        /// </summary>
        /// <param name="services"></param>
        public static void AddCorsExtension(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });
        }

        /// <summary>
        /// Get XML comments for Swagger
        /// </summary>
        private static string XmlCommentsFilePath
        {
            get
            {
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
                return Path.Combine(basePath, fileName);
            }
        }
    }
}
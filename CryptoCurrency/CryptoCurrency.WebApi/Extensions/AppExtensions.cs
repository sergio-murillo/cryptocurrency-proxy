using Microsoft.AspNetCore.Builder;

namespace CryptoCurrency.WebApi.Extensions
{
    /// <summary>
    /// Class in charge of registering app extensions
    /// </summary>
    public static class AppExtensions
    {
        /// <summary>
        /// Register Swagger
        /// </summary>
        /// <param name="app"></param>
        public static void UseSwaggerExtension(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CryptoCurrency.WebApi");
            });
        }
    }
}
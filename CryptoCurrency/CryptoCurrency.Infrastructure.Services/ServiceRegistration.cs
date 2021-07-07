using CryptoCurrency.Application.DTOs;
using CryptoCurrency.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CryptoCurrency.Infrastructure.Services
{
    /// <summary>
    /// Class in charge of registering services for the infrastructure layer
    /// </summary>
    public static class ServiceRegistration
    {
        /// <summary>
        /// Register services
        /// </summary>
        /// <param name="services"></param>
        /// <param name="_config">Appsettings configuration</param>
        public static void AddServiceInfrastructure(this IServiceCollection services, IConfiguration _config)
        {
            services.Configure<ApiSettings>(_config.GetSection("ApiSettings"));
            services.AddHttpClient<ICryptoCurrencyService, CryptoCurrencyService>();
            services.AddTransient<ICryptoCurrencyService, CryptoCurrencyService>();
        }
    }
}
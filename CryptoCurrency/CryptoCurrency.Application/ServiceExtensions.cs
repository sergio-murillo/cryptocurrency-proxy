using CryptoCurrency.Application.Clients;
using CryptoCurrency.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CryptoCurrency.Application
{
    /// <summary>
    /// Class in charge of registering services for the application layer
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// Register services
        /// </summary>
        /// <param name="services"></param>
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddTransient<ICoinClient, CoinClient>();
            services.AddTransient<IMarketClient, MarketClient>();
            services.AddTransient<IExchangeClient, ExchangeClient>();
        }
    }
}
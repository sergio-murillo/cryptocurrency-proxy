using CryptoCurrency.Application.DTOs;
using CryptoCurrency.Application.DTOs.Coin;
using CryptoCurrency.Application.DTOs.Exchange;
using CryptoCurrency.Application.DTOs.Market;
using CryptoCurrency.Application.Exceptions;
using CryptoCurrency.Application.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CryptoCurrency.Infrastructure.Services
{
    /// <summary>
    /// Class in charge of calling external cryptocurrency services
    /// </summary>
    public class CryptoCurrencyService : ICryptoCurrencyService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ApiSettings ApiSettings { get; }
        public ILogger<CryptoCurrencyService> Logger { get; }
        public HttpClient HttpClient { get; }

        public CryptoCurrencyService(
            IOptions<ApiSettings> apiSettings,
            ILogger<CryptoCurrencyService> logger,
            IHttpClientFactory httpClientFactory)
        {
            ApiSettings = apiSettings.Value;
            Logger = logger;
            _httpClientFactory = httpClientFactory;
            HttpClient = _httpClientFactory.CreateClient();
        }

        /// <summary>
        /// Get information about crypto market
        /// </summary>
        /// <returns>Cryptocurrency overview</returns>
        public async Task<List<GlobalCryptoResponse>> GetGlobalCryptoData()
        {
            try
            {
                var url = $"{ApiSettings.BaseUrl}{ApiSettings.GlobalCrypto}";
                var response =  await HttpClient.GetAsync(url);
                Logger.LogInformation("Response GetGlobalCryptoData: " + response);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<List<GlobalCryptoResponse>>();
            }
            catch (System.Exception ex)
            {
                Logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }
        }

        /// <summary>
        /// Get all coins
        /// </summary>
        /// <param name="request">Pagination</param>
        /// <returns>Information about all coins</returns>
        public async Task<AllCoinsResponse> GetAllCoins(AllCoinsRequest request)
        {
            try
            {
                var url = $"{ApiSettings.BaseUrl}{ApiSettings.Coins}/?start={request.Start}&limit={request.Limit}";
                var response = await HttpClient.GetAsync(url);
                Logger.LogInformation("Response GetAllCoins: " + response);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<AllCoinsResponse>();
            }
            catch (System.Exception ex)
            {
                Logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }
        }

        /// <summary>
        /// Get specific coin
        /// </summary>
        /// <param name="request">Coin id</param>
        /// <returns>Coin</returns>
        public async Task<List<Ticker>> GetSpecificCoin(SpecificCoinRequest request)
        {
            try
            {
                var url = $"{ApiSettings.BaseUrl}{ApiSettings.Coin}/?id={request.Id}";
                var response = await HttpClient.GetAsync(url);
                Logger.LogInformation("Response GetSpecificCoin: " + response);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<List<Ticker>>();
            }
            catch (System.Exception ex)
            {
                Logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }
        }

        /// <summary>
        /// Get markets for coin
        /// </summary>
        /// <param name="request">Coin Id</param>
        /// <returns>Markets</returns>
        public async Task<List<MarketResponse>> GetMarketForCoin(MarketForCoinRequest request)
        {
            try
            {
                var url = $"{ApiSettings.BaseUrl}{ApiSettings.MarketForCoin}/?id={request.Id}";
                var response = await HttpClient.GetAsync(url);
                Logger.LogInformation("Response GetMarketForCoin: " + response);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<List<MarketResponse>>();
            }
            catch (System.Exception ex)
            {
                Logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }
        }

        /// <summary>
        /// Get all exchanges
        /// </summary>
        /// <returns>List of exchanges</returns>
        public async Task<AllExchangeResponse> GetAllExchanges()
        {
            try
            {
                var url = $"{ApiSettings.BaseUrl}{ApiSettings.AllExchanges}";
                var response = await HttpClient.GetAsync(url);
                Logger.LogInformation("Response GetAllExchanges: " + response);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<AllExchangeResponse>();
            }
            catch (System.Exception ex)
            {
                Logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }
        }

        /// <summary>
        /// Get specific exchange
        /// </summary>
        /// <param name="request">Exchange Id</param>
        /// <returns>Exchange</returns>
        public async Task<ExchangeResponse> GetSpecificExchange(SpecificExchangeRequest request)
        {
            try
            {
                var url = $"{ApiSettings.BaseUrl}{ApiSettings.SpecificExchange}/?id={request.Id}";
                var response = await HttpClient.GetAsync(url);
                Logger.LogInformation("Response GetSpecificExchange: " + response);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<ExchangeResponse>();
            }
            catch (System.Exception ex)
            {
                Logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }
        }
    }
}
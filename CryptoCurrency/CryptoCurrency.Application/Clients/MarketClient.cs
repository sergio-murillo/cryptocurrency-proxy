using CryptoCurrency.Application.DTOs.Market;
using CryptoCurrency.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoCurrency.Application.Clients
{
    /// <summary>
    /// Contains the methods that implement the logic for markets
    /// </summary>
    public class MarketClient : IMarketClient
    {
        private readonly ICryptoCurrencyService _cryptoCurrencyService;

        public MarketClient(ICryptoCurrencyService cryptoCurrencyService)
        {
            _cryptoCurrencyService = cryptoCurrencyService;
        }

        /// <summary>
        /// Get markets for coin
        /// </summary>
        /// <param name="request">Coin Id</param>
        /// <returns>Markets</returns>
        public async Task<List<MarketResponse>> GetMarketForCoin(MarketForCoinRequest request)
        {
            return await _cryptoCurrencyService.GetMarketForCoin(request);
        }
    }
}

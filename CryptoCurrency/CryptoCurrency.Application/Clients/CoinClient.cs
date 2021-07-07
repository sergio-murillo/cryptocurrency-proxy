using CryptoCurrency.Application.DTOs.Coin;
using CryptoCurrency.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoCurrency.Application.Clients
{
    /// <summary>
    /// Contains the methods that implement the logic for coins
    /// </summary>
    public class CoinClient : ICoinClient
    {
        private readonly ICryptoCurrencyService _cryptoCurrencyService;

        public CoinClient(ICryptoCurrencyService cryptoCurrencyService)
        {
            _cryptoCurrencyService = cryptoCurrencyService;
        }

        /// <summary>
        /// Get information about crypto market
        /// </summary>
        /// <returns>Cryptocurrency overview</returns>
        public async Task<List<GlobalCryptoResponse>> GetGlobalCryptoData()
        {
            return await _cryptoCurrencyService.GetGlobalCryptoData();
        }

        /// <summary>
        /// Get all coins
        /// </summary>
        /// <param name="request">Pagination</param>
        /// <returns>Information about all coins</returns>
        public async Task<AllCoinsResponse> GetAllCoins(AllCoinsRequest request)
        {
            return await _cryptoCurrencyService.GetAllCoins(request);
        }
    }
}

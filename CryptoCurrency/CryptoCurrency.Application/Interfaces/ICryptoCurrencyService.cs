using CryptoCurrency.Application.DTOs.Coin;
using CryptoCurrency.Application.DTOs.Exchange;
using CryptoCurrency.Application.DTOs.Market;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoCurrency.Application.Interfaces
{
    /// <summary>
    /// Contract for CryptoCurrencyService implementation
    /// </summary>
    public interface ICryptoCurrencyService
    {
        Task<List<GlobalCryptoResponse>> GetGlobalCryptoData();

        Task<AllCoinsResponse> GetAllCoins(AllCoinsRequest request);

        Task<List<Ticker>> GetSpecificCoin(SpecificCoinRequest request);

        Task<List<MarketResponse>> GetMarketForCoin(MarketForCoinRequest request);

        Task<AllExchangeResponse> GetAllExchanges();

        Task<ExchangeResponse> GetSpecificExchange(SpecificExchangeRequest request);
    }
}
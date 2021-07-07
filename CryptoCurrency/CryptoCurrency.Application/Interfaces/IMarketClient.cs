using CryptoCurrency.Application.DTOs.Market;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoCurrency.Application.Interfaces
{
    /// <summary>
    /// Contract for MarketClient implementation
    /// </summary>
    public interface IMarketClient
    {
        Task<List<MarketResponse>> GetMarketForCoin(MarketForCoinRequest request);
    }
}

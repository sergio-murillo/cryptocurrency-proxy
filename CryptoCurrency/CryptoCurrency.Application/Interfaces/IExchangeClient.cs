using CryptoCurrency.Application.DTOs.Exchange;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoCurrency.Application.Interfaces
{
    /// <summary>
    /// Contract for ExchangeClient implementation
    /// </summary>
    public interface IExchangeClient
    {
        Task<ExchangeForCoinResponse> GetExchangeForCoin(ExchangeForCoinRequest request);
    }
}

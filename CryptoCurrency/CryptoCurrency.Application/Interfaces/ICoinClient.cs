using CryptoCurrency.Application.DTOs.Coin;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoCurrency.Application.Interfaces
{
    /// <summary>
    /// Contract for CoinClient implementation
    /// </summary>
    public interface ICoinClient
    {
        Task<List<GlobalCryptoResponse>> GetGlobalCryptoData();

        Task<AllCoinsResponse> GetAllCoins(AllCoinsRequest request);
    }
}

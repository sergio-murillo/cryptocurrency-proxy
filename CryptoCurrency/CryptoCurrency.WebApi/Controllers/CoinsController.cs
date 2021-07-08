using CryptoCurrency.Application.DTOs.Coin;
using CryptoCurrency.Application.DTOs.Exchange;
using CryptoCurrency.Application.DTOs.Market;
using CryptoCurrency.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoCurrency.WebApi.Controllers
{
    /// <summary>
    /// Controller class that contains all the methods about cryptocurrency to publish them to clients
    /// </summary>
    [ApiVersion("1.0")]
    public class CoinsController : BaseApiController
    {

        private readonly ICoinClient _coinClient;
        private readonly IMarketClient _marketClient;
        private readonly IExchangeClient _exchangeClient;

        public CoinsController(
            ICoinClient coinClient,
            IMarketClient marketClient,
            IExchangeClient exchangeClient)
        {
            _coinClient = coinClient;
            _marketClient = marketClient;
            _exchangeClient = exchangeClient;
        }

        /// <summary>
        /// GET: api/coins/global
        /// </summary>
        /// <returns>
        /// Cryptocurrency overview
        /// </returns>
        [HttpGet]
        [ActionName("global")]
        public async Task<List<GlobalCryptoResponse>> GetGlobalCrypto()
        {
            Console.WriteLine("GetGlobalCrypto");
            return await _coinClient.GetGlobalCryptoData();
        }

        /// <summary>
        /// GET: api/coins/all
        /// </summary>
        /// <param name="request">Pagination</param>
        /// <returns>Information about all coins</returns>
        [HttpGet]
        [ActionName("all")]
        public async Task<AllCoinsResponse> GetAllCoins([FromQuery] AllCoinsRequest request)
        {
            return await _coinClient.GetAllCoins(request);
        }
        
        /// <summary>
        /// GET: api/coins/coin
        /// </summary>
        /// <param name="request">Coin id</param>
        /// <returns>Information about specific coin</returns>
        [HttpGet]
        [ActionName("coin")]
        public async Task<List<Ticker>> GetSpecificCoin([FromQuery] SpecificCoinRequest request)
        {
            return await _coinClient.GetSpecificCoin(request);
        }

        /// <summary>
        /// GET: api/coins/market
        /// </summary>
        /// <param name="id">Coin Id</param>
        /// <returns>Markets for specific coin</returns>
        [HttpGet]
        [ActionName("market")]
        public async Task<List<MarketResponse>> GetMarketForCoin(int id)
        {
            return await _marketClient.GetMarketForCoin(new MarketForCoinRequest { Id = id });
        }

        /// <summary>
        /// GET: api/coin/exchanges
        /// </summary>
        /// <param name="request">Coin Id</param>
        /// <returns>Exchanges for specific coin</returns>
        [HttpGet]
        [ActionName("exchanges")]
        public async Task<ExchangeForCoinResponse> GetExchangeForCoin([FromQuery] ExchangeForCoinRequest request)
        {
            return await _exchangeClient.GetExchangeForCoin(request);
        }
    }
}
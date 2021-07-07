using CryptoCurrency.Application.DTOs.Exchange;
using CryptoCurrency.Application.DTOs.Market;
using CryptoCurrency.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoCurrency.Application.Clients
{
    /// <summary>
    /// Contains the methods that implement the logic for exchanges
    /// </summary>
    public class ExchangeClient : IExchangeClient
    {
        private readonly ICryptoCurrencyService _cryptoCurrencyService;

        public ExchangeClient(ICryptoCurrencyService cryptoCurrencyService)
        {
            _cryptoCurrencyService = cryptoCurrencyService;
        }

        /// <summary>
        /// Get exchanges for specific coin
        /// </summary>
        /// <param name="request">Coin id</param>
        /// <returns>Exchanges</returns>
        public async Task<ExchangeForCoinResponse> GetExchangeForCoin(ExchangeForCoinRequest request)
        {
            String[] quotes = new String[] { "USDT", "USD"};
            List<MarketResponse> markets = await _cryptoCurrencyService.GetMarketForCoin(new MarketForCoinRequest { Id = request.Id });
            List<MarketResponse> marketsResponse = markets.GroupBy(market => market.Name).Select(market => market.FirstOrDefault()).ToList();
            
            AllExchangeResponse exchanges = await _cryptoCurrencyService.GetAllExchanges();
            List<List<ExchangePair>> exchangesFiltered = new();

            foreach (MarketResponse name in marketsResponse)
            {
                var exchangeItem = exchanges.Values.FirstOrDefault(exchange => exchange.NameId.ToLower() == name.Name.ToLower());
                
                if (exchangeItem != null)
                {
                    int id = Int32.Parse(exchangeItem.Id);
                    ExchangeResponse specificExchange = await _cryptoCurrencyService.GetSpecificExchange(new SpecificExchangeRequest { Id = id });
                    List<ExchangePair> pairsExchangeFiltered = specificExchange.Pairs.Where(exchange => quotes.Contains(exchange.Quote)).ToList();
                    exchangesFiltered.Add(pairsExchangeFiltered);
                }
            }

            var exchangesFlatten = exchangesFiltered
                .SelectMany(exchangePair => exchangePair)
                .OrderBy(exchangePair => exchangePair.Base);

            return new ExchangeForCoinResponse
            {
                Data = exchangesFlatten
                    .Skip(request.Start)
                    .Take(request.Limit)
                    .ToList(),
                TotalCounts = exchangesFlatten.Count()
            };

        }
    }
}

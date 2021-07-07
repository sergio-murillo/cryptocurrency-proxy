using NUnit.Framework;
using Moq;
using CryptoCurrency.Application.Interfaces;
using CryptoCurrency.Application.Clients;
using System.Threading.Tasks;
using System.Collections.Generic;
using CryptoCurrency.Application.DTOs.Exchange;
using CryptoCurrency.Application.DTOs.Market;

namespace CryptoCurrency.Application.UnitTests.Clients
{
    public class ExchangeClientTests
    {
        private readonly Mock<ICryptoCurrencyService> _cryptoCurrencyService;
        private readonly List<MarketResponse> marketsForCoinMock = new()
        {
            new MarketResponse
            {
                Name = "Bitrue",
                Base = "XLM",
                Quote = "USDT",
                Price = 0.25979,
                PriceUsd = 0.25979,
                Volume = 109555555,
                VolumeUsd = 109555555,
                Time = 195555111
            },
            new MarketResponse
            {
                Name = "Binance",
                Base = "XLM",
                Quote = "USDT",
                Price = 0.25971,
                PriceUsd = 0.25971,
                Volume = 1578780000,
                VolumeUsd = 1578780000,
                Time = 195555111
            },
            new MarketResponse
            {
                Name = "OKEX",
                Base = "XLM",
                Quote = "USDT",
                Price = 0.454545,
                PriceUsd = 0.454545,
                Volume = 178454555,
                VolumeUsd = 178454555,
                Time = 195555111
            }
        };
        private readonly AllExchangeResponse allExchangeMock = new()
        {
            { "5", new  AllExchangeItem { Id = "5", Name = "Binance", NameId = "binance" , Url = "any", Country = "Japan" } },
            { "6", new  AllExchangeItem { Id = "6", Name = "Bitrue", NameId = "bitrue" , Url = "any", Country = "Japan" } },
            { "7", new  AllExchangeItem { Id = "7", Name = "OKEX", NameId = "okex" , Url = "any", Country = "Japan" } }
        };
        private readonly ExchangeResponse exchangeBinanceMock = new()
        {
            Info = new ExchangeInfo
            {
                Name = "Binance",
                DateLive = "2018-01-01",
                Url = "any"
            },
            Pairs = new List<ExchangePair>
            {
                new ExchangePair
                {
                    Base = "BTC",
                    Quote = "USDT",
                    Volume = 15454545,
                    Price = 5454545,
                    PriceUsd = 12454545,
                    Time = 45454554
                }
            }
        };

        public ExchangeClientTests()
        {
            _cryptoCurrencyService = new Mock<ICryptoCurrencyService>();

        }

        [Test]
        public async Task ShouldCallGetExchangeForCoin()
        {
            _cryptoCurrencyService.Setup(x => x.GetMarketForCoin(It.IsAny<MarketForCoinRequest>()))
                .Returns(Task.Run(() => marketsForCoinMock));
            _cryptoCurrencyService.Setup(x => x.GetAllExchanges())
                .Returns(Task.Run(() => allExchangeMock));
            _cryptoCurrencyService.Setup(x => x.GetSpecificExchange(It.IsAny<SpecificExchangeRequest>()))
                .Returns(Task.Run(() => exchangeBinanceMock));

            ExchangeClient client = new(_cryptoCurrencyService.Object);
            ExchangeForCoinResponse response = await client.GetExchangeForCoin(new ExchangeForCoinRequest { Id = 10, Start = 0, Limit = 100 });
            Assert.Greater(response.TotalCounts, 0);
        }
    }
}

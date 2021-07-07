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
    public class MarketClientTests
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
       
        public MarketClientTests()
        {
            _cryptoCurrencyService = new Mock<ICryptoCurrencyService>();

        }

        [Test]
        public async Task ShouldCallGetMarketForCoin()
        {

            _cryptoCurrencyService.Setup(x => x.GetMarketForCoin(It.IsAny<MarketForCoinRequest>()))
                .Returns(Task.Run(() => marketsForCoinMock));

            MarketClient client = new(_cryptoCurrencyService.Object);
            List<MarketResponse> response = await client.GetMarketForCoin(new MarketForCoinRequest { Id = 10 });
            Assert.AreEqual(marketsForCoinMock, response);
        }
    }
}

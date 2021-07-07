using NUnit.Framework;
using Moq;
using CryptoCurrency.Application.Interfaces;
using CryptoCurrency.Application.Clients;
using System.Threading.Tasks;
using CryptoCurrency.Application.DTOs.Coin;
using System.Collections.Generic;

namespace CryptoCurrency.Application.UnitTests.Clients
{
    public class CoinClientTests
    {
        private readonly Mock<ICryptoCurrencyService> _cryptoCurrencyService;
        private readonly List<GlobalCryptoResponse> globalCryptoMock = new()
            {
                new GlobalCryptoResponse
                {
                    CoinsCount = 10,
                    ActiveMarkets = 10,
                    TotalMCap = 15000,
                    TotalVolume = 15000,
                    BtcD = "1"
                }
          };
        public CoinClientTests()
        {
            _cryptoCurrencyService = new Mock<ICryptoCurrencyService>();

        }

        [Test]
        public async Task ShouldCallGetGlobalCryptoData()
        {
            _cryptoCurrencyService.Setup(x => x.GetGlobalCryptoData()).Returns(Task.Run(() => globalCryptoMock));
            CoinClient client = new(_cryptoCurrencyService.Object);
            List<GlobalCryptoResponse> response = await client.GetGlobalCryptoData();

            Assert.AreEqual(globalCryptoMock, response);
        }
    }
}
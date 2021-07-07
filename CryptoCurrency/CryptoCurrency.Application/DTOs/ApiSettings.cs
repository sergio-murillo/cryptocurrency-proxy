namespace CryptoCurrency.Application.DTOs
{
    /// <summary>
    /// Class in charge of mapping the routes of the appsettings.json
    /// </summary>
    public class ApiSettings
    {
        public string BaseUrl { get; set; }

        public string GlobalCrypto { get; set; }

        public string Coins { get; set; }

        public string MarketForCoin { get; set; }

        public string AllExchanges { get; set; }

        public string SpecificExchange { get; set; }
    }
}

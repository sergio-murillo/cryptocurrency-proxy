using System.Text.Json.Serialization;

namespace CryptoCurrency.Application.DTOs.Exchange
{
    /// <summary>
    /// DTO to get pairs of each exchange
    /// </summary>
    public class ExchangePair
    {
        [JsonPropertyName("base")]
        public string Base { get; set; }

        [JsonPropertyName("quote")]
        public string Quote { get; set; }

        [JsonPropertyName("volume")]
        public double Volume { get; set; }

        [JsonPropertyName("price")]
        public double Price { get; set; }

        [JsonPropertyName("price_usd")]
        public double PriceUsd { get; set; }

        [JsonPropertyName("time")]
        public double Time { get; set; }
    }
}

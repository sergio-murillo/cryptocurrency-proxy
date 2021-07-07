using System.Text.Json.Serialization;

namespace CryptoCurrency.Application.DTOs.Market
{
    /// <summary>
    /// DTO to get market
    /// </summary>
    public class MarketResponse
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("base")]
        public string Base { get; set; }

        [JsonPropertyName("quote")]
        public string Quote { get; set; }

        [JsonPropertyName("price")]
        public double Price { get; set; }

        [JsonPropertyName("price_usd")]
        public double PriceUsd { get; set; }

        [JsonPropertyName("volume")]
        public double Volume { get; set; }

        [JsonPropertyName("volume_usd")]
        public double VolumeUsd { get; set; }

        [JsonPropertyName("time")]
        public double Time { get; set; }
    }
}

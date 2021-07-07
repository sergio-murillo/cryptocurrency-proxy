using System.Text.Json.Serialization;

namespace CryptoCurrency.Application.DTOs.Exchange
{
    /// <summary>
    /// DTO to get exchanges's item
    /// </summary>
    public class AllExchangeItem
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("name_id")]
        public string NameId { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("date_live")]
        public string DateLive { get; set; }

        [JsonPropertyName("date_added")]
        public string DateAdded { get; set; }

        [JsonPropertyName("usdt")]
        public string Usdt { get; set; }

        [JsonPropertyName("fiat")]
        public string Fiat { get; set; }

        [JsonPropertyName("auto")]
        public string Auto { get; set; }

        [JsonPropertyName("volume_usd")]
        public double VolumeUsd { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace CryptoCurrency.Application.DTOs.Exchange
{
    /// <summary>
    /// DTO to get information about exchange
    /// </summary>
    public class ExchangeInfo
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("date_live")]
        public string DateLive { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}

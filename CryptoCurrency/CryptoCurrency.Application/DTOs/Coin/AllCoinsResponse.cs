using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CryptoCurrency.Application.DTOs.Coin
{
    /// <summary>
    /// DTO to get all coins
    /// </summary>
    public class AllCoinsResponse
    {
        [JsonPropertyName("data")]
        public List<Ticker> Data { get; set; }

        [JsonPropertyName("info")]
        public Info Info { get; set; }
    }
}

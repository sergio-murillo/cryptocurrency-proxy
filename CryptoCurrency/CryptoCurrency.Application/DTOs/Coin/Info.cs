using System.Text.Json.Serialization;

namespace CryptoCurrency.Application.DTOs.Coin
{
    /// <summary>
    /// DTO to get overview of coins
    /// </summary>
    public class Info
    {
        [JsonPropertyName("coins_num")]
        public int CoinsNum { get; set; }

        [JsonPropertyName("time")]
        public int Time { get; set; }
    }
}

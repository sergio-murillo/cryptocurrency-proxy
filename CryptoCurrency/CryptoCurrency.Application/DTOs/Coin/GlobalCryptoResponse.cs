
using System.Text.Json.Serialization;

namespace CryptoCurrency.Application.DTOs.Coin
{
    /// <summary>
    /// DTO to get global crypto market
    /// </summary>
    public class GlobalCryptoResponse
    {
        [JsonPropertyName("coins_count")]
        public int CoinsCount { get; set; }

        [JsonPropertyName("active_markets")]
        public int ActiveMarkets { get; set; }

        [JsonPropertyName("total_mcap")]
        public double TotalMCap { get; set; }

        [JsonPropertyName("total_volume")]
        public double TotalVolume { get; set; }

        [JsonPropertyName("btc_d")]
        public string BtcD { get; set; }

        [JsonPropertyName("eth_d")]
        public string EthD { get; set; }

        [JsonPropertyName("mcap_change")]
        public string MCapChange { get; set; }

        [JsonPropertyName("volume_change")]
        public string VolumeChange { get; set; }

        [JsonPropertyName("avg_change_percent")]
        public double AvgChangePercent { get; set; }

        [JsonPropertyName("volume_ath")]
        public double VolumeAth { get; set; }

        [JsonPropertyName("mcap_ath")]
        public double MCapAth { get; set; }
    }
}

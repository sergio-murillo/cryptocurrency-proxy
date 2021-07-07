using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CryptoCurrency.Application.DTOs.Exchange
{
    public class ExchangeForCoinResponse
    {
        [JsonPropertyName("data")]
        public List<ExchangePair> Data { get; set; }

        [JsonPropertyName("total_counts")]
        public int TotalCounts { get; set; }
    }
}

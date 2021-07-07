using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CryptoCurrency.Application.DTOs.Exchange
{
    /// <summary>
    /// DTO to get specific exchange
    /// </summary>
    public class ExchangeResponse
    {
        [JsonPropertyName("0")]
        public ExchangeInfo Info { get; set; }

        [JsonPropertyName("pairs")]
        public List<ExchangePair> Pairs { get; set; }
    }
}

using System.Collections.Generic;

namespace CryptoCurrency.Application.DTOs.Exchange
{
    /// <summary>
    /// DTO to get all exchanges
    /// </summary>
    public class AllExchangeResponse : Dictionary<string, AllExchangeItem>
    {
    }
}

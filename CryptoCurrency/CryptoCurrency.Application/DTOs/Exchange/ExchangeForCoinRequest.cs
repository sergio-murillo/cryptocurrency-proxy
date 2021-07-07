namespace CryptoCurrency.Application.DTOs.Exchange
{
    /// <summary>
    /// DTO to request exchange for coin
    /// </summary>
    public class ExchangeForCoinRequest
    {
        public int Id { get; set; }

        public int Start { get; set; }

        public int Limit { get; set; }
    }
}

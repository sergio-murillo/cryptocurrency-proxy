namespace CryptoCurrency.Application.DTOs.Coin
{
    /// <summary>
    /// DTO to request all coins
    /// </summary>
    public class AllCoinsRequest
    {
        public int Start { get; set; }

        public int Limit { get; set; }
    }
}

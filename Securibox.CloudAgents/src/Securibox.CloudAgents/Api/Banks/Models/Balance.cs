namespace Securibox.CloudAgents.Api.Banks.Models
{
    /// <summary>
    /// The balace of an account or a credit card.
    /// </summary>
    public class Balance
    {
        /// <summary>
        /// Available amount
        /// </summary>
        public float Available { get; set; }
        /// <summary>
        /// The current amount in the bank account
        /// </summary>
        public float Current { get; set; }
        /// <summary>
        /// The balance date
        /// </summary>
        public float BalanceDate { get; set; }
        /// <summary>
        /// The spent amount
        /// </summary>
        public float Spent { get; set; }
        /// <summary>
        /// The spent amount limit
        /// </summary>
        public float SpentLimit { get; set; }
    }
}

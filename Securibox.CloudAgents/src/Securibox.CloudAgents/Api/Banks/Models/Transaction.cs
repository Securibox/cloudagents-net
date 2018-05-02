using System;

namespace Securibox.CloudAgents.Api.Banks.Models
{
    /// <summary>
    /// Object representing a bank operation (credit or debit).
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// The amount of the transaction.
        /// </summary>
        public float Amount { get; set; }
        /// <summary>
        /// The ISO 4217 currency code for this transaction.
        /// </summary>
        public Currency Currency { get; set; }
        /// <summary>
        /// The label of the transaction.
        /// </summary>
        public string Label { get; set; }
        /// <summary>
        /// The transaction date.
        /// </summary>
        public DateTime TransactionDate { get; set; }
        /// <summary>
        /// The date on which transaction has been completed.
        /// </summary>
        public DateTime ValueDate { get; set; }
        /// <summary>
        /// The type of the transaction
        /// </summary>
        public TransactionType Type { get; set; }
    }
}

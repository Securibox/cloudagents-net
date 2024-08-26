using System;
using System.ComponentModel.DataAnnotations;

namespace Securibox.CloudAgents.Api.Banks.Models
{
    /// <summary>
    /// Object representing a bank card.
    /// </summary>
    [Obsolete("This class is deprecated.")]
    public class Card
    {
        /// <summary>
        /// The bank account name.
        /// </summary>
        [MaxLength(64)]
        public string Brand { get; set; }
        /// <summary>
        /// The bank account name.
        /// </summary>
        [MaxLength(16)]
        public string Number { get; set; }
        /// <summary>
        /// The card name.
        /// </summary>
        [MaxLength(256)]
        public string Name { get; set; }
        /// <summary>
        /// The ISO 4217 currency code.
        /// </summary>
        public Currency Currency { get; set; }
        /// <summary>
        /// The date specifying the date from which data has been downloaded.
        /// </summary>
        public DateTime TransactionsFrom { get; set; }
        /// <summary>
        /// The downloaded bank account transactions.
        /// </summary>
        public Transaction[] Transactions { get; set; }
        /// <summary>
        /// The bank account balance.
        /// </summary>
        public Balance[] Balances { get; set; }
        /// <summary>
        /// The status of the downloaded transactions associated to this card.
        /// </summary>
        public CardState State { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace Securibox.CloudAgents.Api.Banks.Models
{
    public class BankAccount
    {
        /// <summary>
        /// The bank account identifier
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// The customer account identifier
        /// </summary>
        [MaxLength(128)]
        public string CustomerAccountId { get; set; }
        /// <summary>
        /// The bank account IBAN
        /// </summary>
        [MaxLength(34)]
        public string Iban { get; set; }
        /// <summary>
        /// The bank account customized name.
        /// </summary>
        [MaxLength(256)]
        public string CustomName { get; set; }
        /// <summary>
        /// The bank account name.
        /// </summary>
        [MaxLength(256)]
        public string Name { get; set; }
        /// <summary>
        /// The bank account type.
        /// </summary>
        public BankAccountType Type { get; set; }
        /// <summary>
        /// The bank account balance.
        /// </summary>
        public Balance Balance { get; set; }
        /// <summary>
        /// The bank account number.
        /// </summary>
        public string Number { get; set; }
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
        /// The list of cards associated to this bank account.
        /// </summary>
        public Card[] Cards { get; set; }

    }
}

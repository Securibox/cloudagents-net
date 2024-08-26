using System;

namespace Securibox.CloudAgents.Api.Banks.Models
{
    /// <summary>
    /// The transaction types.
    /// </summary>
    [Obsolete("This class is deprecated.")]
    public enum TransactionType
    {
        /// <summary>
        /// Undefined transaction type.
        /// </summary>
        Undefined,
        /// <summary>
        /// Wire transfer transaction type.
        /// </summary>
        WireTransfer,
        /// <summary>
        /// Bank payment transaction type.
        /// </summary>
        BankPayment,
        /// <summary>
        /// Check transaction type.
        /// </summary>
        Check,
        /// <summary>
        /// Withdrawal transaction type.
        /// </summary>
        Withdrawal,
        /// <summary>
        /// Credit card payment transaction type.
        /// </summary>
        CreditCardPayment,
        /// <summary>
        /// Credit card detailed payment transaction type.
        /// </summary>
        CreditCardDetailedPayment
    }
}

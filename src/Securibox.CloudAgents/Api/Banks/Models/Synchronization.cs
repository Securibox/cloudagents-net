using System;

namespace Securibox.CloudAgents.Api.Banks.Models
{
    /// <summary>
    /// Object representing a bank account synchronization.
    /// </summary>
    [Obsolete("This class is deprecated.")]
    public class Synchronization
    {
        /// <summary>
        /// The list of downloaded bank accounts.
        /// </summary>
        public BankAccount[] BankAccounts { get; set; }
        /// <summary>
        /// The synchronization creation date.
        /// </summary>
        public DateTime CreationDate { get; set; }
        /// <summary>
        /// The synchronization delivery date.
        /// </summary>
        public DateTime DeliveryDate { get; set; }
        /// <summary>
        /// The customer account identifier.
        /// </summary>
        public string CustomerAccountId { get; set; }
        /// <summary>
        /// The customer user identifier.
        /// </summary>
        public string CustomerUserId { get; set; }
        /// <summary>
        /// The synchronization identifier.
        /// </summary>
        public string Identifier { get; set; }
        /// <summary>
        /// The synchronization state.
        /// </summary>
        public SynchronizationState State { get; set; }

    }
}

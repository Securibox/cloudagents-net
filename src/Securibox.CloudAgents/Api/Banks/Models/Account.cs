using System;
using System.Collections.Generic;

namespace Securibox.CloudAgents.Api.Banks.Models
{
    /// <summary>
    /// Object representing one agent account of the user.
    /// </summary>
    [Obsolete("This class is deprecated.")]
    public class Account
    {
        /// <summary>
        /// The working mode of this account.
        /// </summary>
        public AccountMode Mode { get; set; }
        /// <summary>
        /// The bank identifier to which this account belongs to.
        /// </summary>
        public string BankId { get; set; }
        /// <summary>
        /// Gets or set a list of credentials for this account.
        /// </summary>
        /// <value>
        /// The account credentials.
        /// </value>
        public List<Credential> Credentials { get; set; }
        /// <summary>
        /// Gets or sets an account ID (either provided at creation time or automatically generated).
        /// </summary>
        /// <value>
        /// The customer account identifier
        /// </value>
        public string CustomerAccountId { get; set; }
        /// <summary>
        /// User ID to which this account belongs to.
        /// </summary>
        /// <value>
        /// The customer user identifier
        /// </value>
        public string CustomerUserId { get; set; }
        /// <summary>
        /// The last synchronization date.
        /// </summary>
        public DateTime LastSynchDate { get; set; }
        /// <summary>
        /// The identifier of the last synchronization.
        /// </summary>
        public string LastSynchIdentifier { get; set; }
        /// <summary>
        /// The status of the last synchronization.
        /// </summary>
        public SynchronizationState LastSynchronizationState { get; set; }
        /// <summary>
        /// Gets or sets the account name.
        /// </summary>
        /// <value>
        /// The account name
        /// </value>
        public string Name { get; set; }
    }
}

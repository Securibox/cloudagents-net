using System.Collections.Generic;

namespace Securibox.CloudAgents.Api.Documents.Models
{
    /// <summary>
    /// Object representing one agent account of the user
    /// </summary>
    public class Account
    {
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
        /// Gets or sets the account name.
        /// </summary>
        /// <value>
        /// The account name
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the ID of the agent that the account belongs to.
        /// </summary>
        /// <value>
        /// The agent identifier.
        /// </value>
        public string AgentId { get; set; }
        /// <summary>
        /// Gets or set a list of credentials for this account.
        /// </summary>
        /// <value>
        /// The account credentials.
        /// </value>
        public List<Credential> Credentials { get; set; }
        /// <summary>
        /// Gets or set the account mode.
        /// </summary>
        public string Mode { get; set; }
    }
}

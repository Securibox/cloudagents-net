using System.Collections.Generic;

namespace Securibox.CloudAgents.SDK.Api.Documents.Models
{
    /// <summary>
    /// Account class
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Gets or sets the customer account identifier.
        /// </summary>
        /// <value>
        /// The customer account identifier.
        /// </value>
        public string CustomerAccountId { get; set; }
        /// <summary>
        /// Gets or sets the customer user identifier.
        /// </summary>
        /// <value>
        /// The customer user identifier.
        /// </value>
        public string CustomerUserId { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the agent identifier.
        /// </summary>
        /// <value>
        /// The agent identifier.
        /// </value>
        public string AgentId { get; set; }
        /// <summary>
        /// Gets or sets the credentials.
        /// </summary>
        /// <value>
        /// The credentials.
        /// </value>
        public List<Credential> Credentials { get; set; }

        public string Mode { get; set; }
    }
}

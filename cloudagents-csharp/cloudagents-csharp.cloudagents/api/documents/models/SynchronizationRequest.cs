using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cloudagents_csharp.cloudagents.api.documents.models
{
    /// <summary>
    /// SynchronizationRequest class
    /// </summary>
    public class SynchronizationRequest
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
        /// Gets or sets a value indicating whether this <see cref="SynchronizeRequest" /> is forced.
        /// </summary>
        /// <value>
        ///   <c>true</c> if forced; otherwise, <c>false</c>.
        /// </value>
        public bool IsForced { get; set; }

        public SynchronizationRequest(string customerAccountId, bool isForced, string customerUserId = null)
        {
            this.CustomerAccountId = customerAccountId;
            this.CustomerUserId = customerUserId;
            this.IsForced = isForced;
        }
    }
}

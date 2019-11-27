namespace Securibox.CloudAgents.Api.Documents.Models
{
    /// <summary>
    /// A class representing an synchronization launch request.
    /// </summary>
    public class SynchronizationRequest
    {
        /// <summary>
        /// The customer account identifier.
        /// </summary>
        public string CustomerAccountId { get; set; }
        /// <summary>
        /// The customer user identifier.
        /// </summary>
        public string CustomerUserId { get; set; }
        /// <summary>
        /// A value indicating whether this <see cref="SynchronizationRequest" /> is forced.
        /// </summary>
        public bool IsForced { get; set; }

        /// <summary>
        /// Initializes the SynchronizationRequest class.
        /// </summary>
        /// <param name="customerAccountId">The customer account identifier.</param>
        /// <param name="isForced">A value indicating whether this <see cref="SynchronizationRequest" /> is forced.</param>
        /// <param name="customerUserId"> The customer user identifier</param>
        public SynchronizationRequest(string customerAccountId, bool isForced, string customerUserId = null)
        {
            this.CustomerAccountId = customerAccountId;
            this.CustomerUserId = customerUserId;
            this.IsForced = isForced;
        }
    }
}

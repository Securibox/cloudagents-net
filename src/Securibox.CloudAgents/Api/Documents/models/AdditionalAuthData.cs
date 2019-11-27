using System;

namespace Securibox.CloudAgents.Api.Documents.Models
{
    /// <summary>
    /// Multifactor authentication details.
    /// </summary>
    public class AdditionalAuthData
    {
        /// <summary>
        /// Channel to communicate the secret code
        /// </summary>
        public string AdditionalAuthenticationType { get; set; }
        /// <summary>
        /// Code validity date
        /// </summary>
        public DateTime ExpirationDate { get; set; }
        /// <summary>
        /// Message sent by the agent
        /// </summary>
        public string Message { get; set; }
    }
}

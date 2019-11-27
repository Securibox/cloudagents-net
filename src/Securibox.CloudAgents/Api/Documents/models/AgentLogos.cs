namespace Securibox.CloudAgents.Api.Documents.Models
{
    /// <summary>
    /// Class representing an agent logo.
    /// </summary>
    public class AgentLogos
    {
        /// <summary>
        /// Gets or sets the small logo.
        /// </summary>
        /// <value>
        /// The small logo.
        /// </value>
        public AgentLogo Small { get; set; }
        /// <summary>
        /// Gets or sets the medium logo.
        /// </summary>
        /// <value>
        /// The medium logo.
        /// </value>
        public AgentLogo Medium { get; set; }

        /// <summary>
        /// Gets or sets the large logo.
        /// </summary>
        /// <value>
        /// The large logo.
        /// </value>
        public AgentLogo Large { get; set; }
    }
}

namespace Securibox.CloudAgents.Api.Documents.Models
{
    /// <summary>
    /// Class that will hold the agent logos.
    /// </summary>
    public class AgentLogo
    {
        /// <summary>
        /// Gets or sets the agent logo width.
        /// </summary>
        /// <value>
        /// The agent logo width.
        /// </value>
        public int Width { get; set; }
        /// <summary>
        /// Gets or sets the agent logo height.
        /// </summary>
        /// <value>
        /// The agent logo height.
        /// </value>
        public int Height { get; set; }
        /// <summary>
        /// Gets or sets the agent logo URL.
        /// </summary>
        /// <value>
        /// The agent logo URL.
        /// </value>
        public string Url { get; set; }
    }
}

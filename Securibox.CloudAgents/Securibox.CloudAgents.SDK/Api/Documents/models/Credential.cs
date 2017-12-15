namespace Securibox.CloudAgents.SDK.Api.Documents.Models
{
    /// <summary>
    /// Credential class
    /// </summary>
    public class Credential
    {
        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        public int Position { get; set; }
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the alg.
        /// </summary>
        /// <value>
        /// The alg.
        /// </value>
        public string Alg { get; set; }
    }
}

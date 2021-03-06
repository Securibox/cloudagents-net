﻿namespace Securibox.CloudAgents.Api.Documents.Models
{
    /// <summary>
    /// A class representing an agent account credential.
    /// </summary>
    public class Credential
    {
        /// <summary>
        /// Gets or sets the credential position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        public int Position { get; set; }
        /// <summary>
        /// Gets or sets the credential value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the credential encryption algorithm.
        /// </summary>
        /// <value>
        /// The alg.
        /// </value>
        public string Alg { get; set; }
    }
}

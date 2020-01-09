using System;
using System.Collections.Generic;

namespace Securibox.CloudAgents.Api.Documents.Models
{
    /// <summary>
    /// Object representing an agent.
    /// </summary>
    public class Agent
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The agent identifier.
        /// </value>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsEnabled { get; set; }
        /// <summary>
        /// Gets or sets the agent name. (maximum length of 256 chars)
        /// </summary>
        /// <value>
        /// The agent name
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// The agent display name. (maximum length of 64 chars)
        /// </summary>
        /// <value>
        /// The agent display name
        /// </value>
        public string DisplayName { get; set; }
        /// <summary>
        /// Gets or sets the agent description. (maximum length of 256 chars)
        /// </summary>
        /// <value>
        /// The agent description
        /// </value>
        public string Description { get; set; }
        /// <summary>
        /// The agent periodicity
        /// </summary>
        /// <value>
        /// The agent periodicity
        /// </value>
        public AgentPeriodicity AgentPeriodicity { get; set; }
        /// <summary>
        /// The agent current state
        /// </summary>
        /// <value>
        /// The agent current state
        /// </value>
        public AgentCurrentState AgentCurrentState { get; set; }
        /// <summary>
        /// Gets or sets the agent default category (that was initially specified by Securibox).
        /// </summary>
        /// <value>
        /// The agent default category
        /// </value>
        public string DefaultCategory { get; set; }
        /// <summary>
        /// Gets or sets the agent category identifier.
        /// </summary>
        /// <value>
        /// The category identifier.
        /// </value>
        public string CategoryId { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is tracked.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is tracked; otherwise, <c>false</c>.
        /// </value>
        public bool IsTracked { get; set; }
        /// <summary>
        /// Gets or sets the agent logos.
        /// </summary>
        /// <value>
        /// The agent logos
        /// </value>
        public AgentLogos Logos { get; set; }
        /// <summary>
        /// Gets or sets the agent base64 encoded logo.
        /// </summary>
        /// <value>
        /// The agent base64 encoded logo
        /// </value>
        public string Base64Logo { get; set; }
        /// <summary>
        /// Gets or sets the country codes.
        /// </summary>
        /// <value>
        /// The country codes
        /// </value>
        public AgentCountryCode[] CountryCodes { get; set; }
        /// <summary>
        /// Gets or sets the agent login URL.
        /// </summary>
        /// <value>
        /// The agent login URL
        /// </value>
        public string Url { get; set; }
        /// <summary>
        /// Gets or sets the document types returned by this agent.
        /// </summary>
        /// <value>
        /// The document types returned by this agent
        /// </value>
        public string DocumentTypes { get; set; }
        /// <summary>
        /// Gets or sets the fields that must be filled to perform the login.
        /// </summary>
        /// <value>
        /// The agent fields that must be filled to perform the login.
        /// </value>
        public List<Field> Fields { get; set; }
        /// <summary>
        /// Gets or sets the agent category name.
        /// </summary>
        /// <value>
        /// The agent category name
        /// </value>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>
        /// The creation date.
        /// </value>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this agent uses multifactor authentication.
        /// </summary>
        public bool IsMFA { get; set; }
    }
}

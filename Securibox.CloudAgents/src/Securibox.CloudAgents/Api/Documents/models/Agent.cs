using System;
using System.Collections.Generic;

namespace Securibox.CloudAgents.Api.Documents.Models
{
    /// <summary>
    /// Agent class.
    /// </summary>
    public class Agent
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
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
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        public string DisplayName { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
        /// <summary>
        /// The _periodicit private member
        /// </summary>
        /// <value>
        /// The agent periodicity.
        /// </value>
        public AgentPeriodicity AgentPeriodicity { get; set; }
        /// <summary>
        /// The _agentState private member
        /// </summary>
        /// <value>
        /// The state of the agent current.
        /// </value>
        public AgentCurrentState AgentCurrentState { get; set; }
        /// <summary>
        /// Gets or sets the default category.
        /// </summary>
        /// <value>
        /// The default category.
        /// </value>
        public string DefaultCategory { get; set; }
        /// <summary>
        /// Gets or sets the category identifier.
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
        /// Gets or sets the logos.
        /// </summary>
        /// <value>
        /// The logos.
        /// </value>
        public AgentLogos Logos { get; set; }
        /// <summary>
        /// Gets or sets the base64 logo.
        /// </summary>
        /// <value>
        /// The base64 logo.
        /// </value>
        public string Base64Logo { get; set; }
        /// <summary>
        /// Gets or sets the country code.
        /// </summary>
        /// <value>
        /// The country code.
        /// </value>
        public AgentCountryCode[] CountryCodes { get; set; }
        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        public string Url { get; set; }
        /// <summary>
        /// Gets or sets the document types.
        /// </summary>
        /// <value>
        /// The document types.
        /// </value>
        public string DocumentTypes { get; set; }
        /// <summary>
        /// Gets or sets the fields.
        /// </summary>
        /// <value>
        /// The fields.
        /// </value>
        public List<Field> Fields { get; set; }
        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>
        /// The creation date.
        /// </value>
        public DateTime CreationDate { get; set; }
    }
}

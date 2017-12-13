using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cloudagents_csharp.cloudagents.api.documents.models
{
    /// <summary>
    /// 
    /// </summary>
    public class AgentLogos
    {
        /// <summary>
        /// Gets or sets the small.
        /// </summary>
        /// <value>
        /// The small.
        /// </value>
        public AgentLogo Small { get; set; }
        /// <summary>
        /// Gets or sets the medium.
        /// </summary>
        /// <value>
        /// The medium.
        /// </value>
        public AgentLogo Medium { get; set; }

        /// <summary>
        /// Gets or sets the large.
        /// </summary>
        /// <value>
        /// The large.
        /// </value>
        public AgentLogo Large { get; set; }
    }
}

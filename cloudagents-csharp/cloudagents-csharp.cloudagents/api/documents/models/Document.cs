using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cloudagents_csharp.cloudagents.api.documents.models
{
    /// <summary>
    /// Document class.
    /// </summary>
    public class Document
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the synch creation date.
        /// </summary>
        /// <value>
        /// The synch creation date.
        /// </value>
        public DateTime SynchCreationDate { get; set; }
        /// <summary>
        /// Gets or sets the account identifier.
        /// </summary>
        /// <value>
        /// The account identifier.
        /// </value>
        public int AccountId { get; set; }
        /// <summary>
        /// Gets or sets the customer account identifier.
        /// </summary>
        /// <value>
        /// The customer account identifier.
        /// </value>
        public string CustomerAccountId { get; set; }
        /// <summary>
        /// Gets or sets the agent identifier.
        /// </summary>
        /// <value>
        /// The agent identifier.
        /// </value>
        public int AgentId { get; set; }
        /// <summary>
        /// Gets or sets the content hash.
        /// </summary>
        /// <value>
        /// The content hash.
        /// </value>
        public string ContentHash { get; set; }
        /// <summary>
        /// Gets or sets the hash algorithm.
        /// </summary>
        /// <value>
        /// The hash algorithm.
        /// </value>
        public string HashAlgorithm { get; set; }
        /// <summary>
        /// Gets or sets the type of the content.
        /// </summary>
        /// <value>
        /// The type of the content.
        /// </value>
        public string ContentType { get; set; }
        /// <summary>
        /// Gets or sets the metadatas.
        /// </summary>
        /// <value>
        /// The metadatas.
        /// </value>
        public Dictionary<string, string> Metadatas { get; set; }
        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        /// <value>
        /// The unique identifier.
        /// </value>
        public string UniqueIdentifier { get; set; }
        /// <summary>
        /// Gets or sets the unique identifier hash.
        /// </summary>
        /// <value>
        /// The unique identifier hash.
        /// </value>
        public string UniqueIdentifierHash { get; set; }
        /// <summary>
        /// The _state private member
        /// </summary>
        public DocumentProcessPhase DocumentProcessPhase { get; set; }
        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        public int Size { get; set; }
        /// <summary>
        /// Gets or sets the delivery date.
        /// </summary>
        /// <value>
        /// The delivery date.
        /// </value>
        public DateTime DeliveryDate { get; set; }
        /// <summary>
        /// Gets or sets the acknowledgement date.
        /// </summary>
        /// <value>
        /// The acknowledgement date.
        /// </value>
        public DateTime AcknowledgementDate { get; set; }
        /// <summary>
        /// Gets or sets the content of the base64.
        /// </summary>
        /// <value>
        /// The content of the base64.
        /// </value>
        public string Base64Content { get; set; }
    }
}

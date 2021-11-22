using System;
using System.Collections.Generic;

namespace Securibox.CloudAgents.Api.Documents.Models
{
    /// <summary>
    /// A class representing an downloaded document.
    /// </summary>
    public class Document
    {
        /// <summary>
        /// The document identifier
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The document name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The synchronization datetime on which the document was downloaded.
        /// </summary>
        public DateTime SynchCreationDate { get; set; }
        /// <summary>
        /// The account identifier that downloaded the document.
        /// </summary>
        public int AccountId { get; set; }
        /// <summary>
        /// The customer account identifier that downloaded the document.
        /// </summary>
        public string CustomerAccountId { get; set; }
        /// <summary>
        /// The agent identifier that downloaded the document.
        /// </summary>
        public int AgentId { get; set; }
        /// <summary>
        /// The agent identifier that downloaded the document.
        /// </summary>
        public string AgentIdentifier { get; set; }
        /// <summary>
        /// The digest of the document content
        /// </summary>
        public string ContentHash { get; set; }
        /// <summary>
        /// The hash algorithm that was used to calculate the digest.
        /// </summary>
        public string HashAlgorithm { get; set; }
        /// <summary>
        /// The document content mime type
        /// </summary>
        public string ContentType { get; set; }
        /// <summary>
        /// The metadatas extracted from the document.
        /// </summary>
        public Dictionary<string, string> Metadatas { get; set; }
        /// <summary>
        /// The document unique identifier that is used to know if the document has already been downloaded.
        /// </summary>
        public string UniqueIdentifier { get; set; }
        /// <summary>
        /// The hash of the document unique identifier that is used to know if the document has already been downloaded.
        /// </summary>
        public string UniqueIdentifierHash { get; set; }
        /// <summary>
        /// The document process phase.
        /// </summary>
        public DocumentProcessPhase DocumentProcessPhase { get; set; }
        /// <summary>
        /// The document size.
        /// </summary>
        public int Size { get; set; }
        /// <summary>
        /// The date on which the document has been delivered.
        /// </summary>
        public DateTime DeliveryDate { get; set; }
        /// <summary>
        /// The date on which the document has been acknowledged.
        /// </summary>
        public DateTime AcknowledgementDate { get; set; }
        /// <summary>
        /// The document content encoded in base 64.
        /// </summary>
        public string Base64Content { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Securibox.CloudAgents.Api.Documents.Models
{
    /// <summary>
    /// Synchronization class
    /// </summary>
    public class Synchronization
    {
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
        /// Gets or sets a value indicating whether this instance is forced.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is forced; otherwise, <c>false</c>.
        /// </value>
        public bool IsForced { get; set; }
        /// <summary>
        /// Gets or sets the downloaded docs.
        /// </summary>
        /// <value>
        /// The downloaded docs.
        /// </value>
        public int DownloadedDocs { get; set; }
        /// <summary>
        /// Gets or sets the detected docs.
        /// </summary>
        /// <value>
        /// The detected docs.
        /// </value>
        public int DetectedDocs { get; set; }
        /// <summary>
        /// Gets or sets the synchronization date.
        /// </summary>
        /// <value>
        /// The synchronization date.
        /// </value> 
        public DateTime CreationDate { get; set; }
        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Gets or sets the end date date.
        /// </summary>
        /// <value>
        /// The end date date.
        /// </value>
        public DateTime EndDate { get; set; }
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
        /// Gets or sets the state of the synchronization.
        /// </summary>
        /// <value>
        /// The state of the synchronization.
        /// </value>
        public SynchronizationState SynchronizationState { get; set; }
        /// <summary>
        /// The StateDetails private member
        /// </summary>
        public SynchronizationStateDetails SynchronizationStateDetails { get; set; }
        /// <summary>
        /// The _mode
        /// </summary>
        public SynchronizationMode SynchronizationMode { get; set; }
        /// <summary>
        /// Gets or sets the API version.
        /// </summary>
        /// <value>
        /// The API version.
        /// </value>
        public string ApiVersion { get; set; }
        /// <summary>
        /// Gets or sets the documents.
        /// </summary>
        /// <value>
        /// The documents.
        /// </value>
        public List<Document> Documents { get; set; }
    }
}

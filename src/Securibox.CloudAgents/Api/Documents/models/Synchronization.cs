using System;
using System.Collections.Generic;

namespace Securibox.CloudAgents.Api.Documents.Models
{
    /// <summary>
    /// A class representing a synchronization performed by an account to try to retreive documents.
    /// </summary>
    public class Synchronization
    {
        /// <summary>
        /// The account identifier.
        /// </summary>
        public int AccountId { get; set; }
        /// <summary>
        /// The customer user identifier.
        /// </summary>
        public string CustomerUserId { get; set; }
        /// <summary>
        /// The customer account identifier.
        /// </summary>
        public string CustomerAccountId { get; set; }
        /// <summary>
        /// A value indicating whether this synchronization is forced.
        /// </summary>
        public bool IsForced { get; set; }
        /// <summary>
        /// The number of downloaded documents.
        /// </summary>
        public int DownloadedDocs { get; set; }
        /// <summary>
        /// The number of detected documents.
        /// </summary>
        public int DetectedDocs { get; set; }
        /// <summary>
        /// The date on which the synchronization has been created.
        /// </summary>
        public DateTime CreationDate { get; set; }
        /// <summary>
        /// The date on which the synchronization has started.
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// The date on which the synchronization has ended.
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// The date on which the synchronization has been delivered.
        /// </summary>
        public DateTime DeliveryDate { get; set; }
        /// <summary>
        /// The date on which the synchronization has been acknowledged.
        /// </summary>
        public DateTime AcknowledgementDate { get; set; }
        /// <summary>
        /// The state of the overall synchronization.
        /// </summary>
        public SynchronizationState SynchronizationState { get; set; }
        /// <summary>
        /// The state of the agent related process.
        /// </summary>
        public SynchronizationStateDetails SynchronizationStateDetails { get; set; }
        /// <summary>
        /// The synchronization mode
        /// </summary>
        public SynchronizationMode SynchronizationMode { get; set; }
        /// <summary>
        /// The API version.
        /// </summary>
        public string ApiVersion { get; set; }
        /// <summary>
        /// A list of documents downloaded through this synchronization.
        /// </summary>
        public List<Document> Documents { get; set; }
    }
}

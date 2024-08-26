namespace Securibox.CloudAgents.Api.Documents.Models
{
    /// <summary>
    /// An enumeration detailling the overall state of a synchronization.
    /// </summary>
    public enum SynchronizationState
    {
        /// <summary>
        /// The synchronization has just been created after an account creation.
        /// </summary>
        NewAccount = 0,
        /// <summary>
        /// The synchronization has just been created.
        /// </summary>
        Created = 1,
        /// <summary>
        /// The synchronization is running.
        /// </summary>
        Running = 2,
        /// <summary>
        /// The synchronization is finished and the documents are ready to be delivered.
        /// </summary>
        ToDeliver = 3,
        /// <summary>
        /// The synchronization is finished and the documents are being delivered.
        /// </summary>
        Delivering = 4,
        /// <summary>
        /// The synchronization is finished, the documents have been delivered and SCA is expecting the client to acknowledge the documents reception.
        /// </summary>
        PendingAcknowledgement = 5,
        /// <summary>
        /// The synchronization is completed (documents have been delivered and acknwoledged by the client).
        /// </summary>
        Completed = 6,
        /// <summary>
        /// The synchronization is completed but the synchronization report has failed to be delivered.
        /// </summary>
        ReportFailed = 7,
        /// <summary>
        /// The synchronization is completed but the client has not acknowledged the reception of the documents passed the allowed amount of time.
        /// </summary>
        NotAck = 8,
    }
}

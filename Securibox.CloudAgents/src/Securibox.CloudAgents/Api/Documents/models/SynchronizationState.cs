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
        NewAccount,
        /// <summary>
        /// The synchronization has just been created.
        /// </summary>
        Created,
        /// <summary>
        /// The synchronization is running.
        /// </summary>
        Running,
        /// <summary>
        /// The synchronization has failed dued to an agent issue. Please check SynchronizationStateDetails for more information.
        /// </summary>
        AgentFailed,
        /// <summary>
        /// The synchronization is finished and the documents are being delivered.
        /// </summary>
        Delivering,
        /// <summary>
        /// The synchronization is finished, the documents have been delivered and SCA is expecting the client to acknowledge the documents reception.
        /// </summary>
        PendingAcknowledgement,
        /// <summary>
        /// The synchronization is completed (documents have been delivered and acknwoledged by the client).
        /// </summary>
        Completed,
        /// <summary>
        /// The synchronization is completed but the synchronization report has failed to be delivered.
        /// </summary>
        ReportFailed
    }
}

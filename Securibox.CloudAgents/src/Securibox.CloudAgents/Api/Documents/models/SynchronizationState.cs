namespace Securibox.CloudAgents.Api.Documents.Models
{
    /// <summary>
    /// SynchronizationState cenum
    /// </summary>
    public enum SynchronizationState
    {
        NewAccount,
        Created,
        Running,
        AgentFailed,
        Delivering,
        PendingAcknowledgement,
        Completed,
        ReportFailed
    }
}

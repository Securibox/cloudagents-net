namespace Securibox.CloudAgents.Api.Documents.Models
{
    /// <summary>
    /// Enumeration specifying the agent state.
    /// </summary>
    public enum AgentCurrentState
    {
        /// <summary>
        /// The agent is running without problems.
        /// </summary>
        IsRunning,
        /// <summary>
        /// The agent is in maintenance and will return to the IsRunning state shortly.
        /// </summary>
        InMaintenance,
        /// <summary>
        /// The agent is unavailable, an will no longer be maintained.
        /// </summary>
        Unavailable
    }
}

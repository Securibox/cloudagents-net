namespace Securibox.CloudAgents.Api.Banks.Models
{
    /// <summary>
    /// Bank status
    /// </summary>
    public enum BankStatus
    {
        /// <summary>
        /// The bank agent is running without problems.
        /// </summary>
        IsRunning,
        /// <summary>
        /// The bank agent is under maintenance.
        /// </summary>
        InMaintenance,
        /// <summary>
        /// The bank agent is no longer available
        /// </summary>
        Unavailable
    }
}

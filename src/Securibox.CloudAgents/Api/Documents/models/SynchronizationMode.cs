namespace Securibox.CloudAgents.Api.Documents.Models
{
    /// <summary>
    /// Enumeration specifying the synchronization mode.
    /// </summary>
    public enum SynchronizationMode
    {
        /// <summary>
        /// Synchronization launched after an account creation.
        /// </summary>
        NewAccount,
        /// <summary>
        /// Synchronization launched by an API call.
        /// </summary>
        Client,
        /// <summary>
        /// Synchronization launched automatically by the Cloud Agents platform.
        /// </summary>
        Automatic,
        /// <summary>
        /// Synchronization launched by an administrator.
        /// </summary>
        Admin
    }
}

namespace Securibox.CloudAgents.Api.Banks.Models
{
    /// <summary>
    /// Card statuses
    /// </summary>
    public enum CardState
    {
        /// <summary>
        /// Transactions have been correctly downloaded.
        /// </summary>
        Ok,
        /// <summary>
        /// There are no new transaction to be downloaded since the last synchronization.
        /// </summary>
        NothingNewToDownload,
        /// <summary>
        /// The hash of the last downloaded transaction could not be found. There might be some duplications on the downloaded transactions.
        /// </summary>
        HashVerificationFailed
    }
}

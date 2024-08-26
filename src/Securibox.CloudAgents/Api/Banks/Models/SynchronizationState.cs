using System;

namespace Securibox.CloudAgents.Api.Banks.Models
{
    /// <summary>
    /// An enumeration detailling the overall state of a synchronization.
    /// </summary>
    [Obsolete("This class is deprecated.")]
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
        /// The synchronization has been terminated as the login phase has failed
        /// </summary>
        LoginFailed,
        /// <summary>
        /// The synchronization is completed.
        /// </summary>
        Completed,
        /// <summary>
        /// The synchronization is completed but with some errors.
        /// </summary>
        CompletedWithErrors,
        /// <summary>
        /// The synchronization is not possible as the login has failed three times. The credentials need to be updated.
        /// </summary>
        CheckAccount,
        /// <summary>
        /// The bank agent is no longer available.
        /// </summary>
        ServiceUnavailable,
        /// <summary>
        /// The synchronization is in the login phase.
        /// </summary>
        LoggingIn,
        /// <summary>
        /// The synchronization has failed loging and is terminating.
        /// </summary>
        RunningButLoginFailed,
        /// <summary>
        /// The results of the synchronization could not be delivered.
        /// </summary>
        DeliveryFailed,
        /// <summary>
        /// The bank website is in maintenance therfore the synchronization could not retreive transactions.
        /// </summary>
        WebsiteInMaintenance,
        /// <summary>
        /// The bank website is warning that a password reset will be needed in the short term, the synchronization can still download transactions.
        /// </summary>
        ResetPasswordWarning,
        /// <summary>
        /// The bank website requires the user to reset his password. The synchronization could not download any transactions.
        /// </summary>
        ResetPasswordRequired,
        /// <summary>
        /// The bank website is displaying a form or a notification that requires the user to perform some action.
        /// </summary>
        UserActionNeeded
    }
}

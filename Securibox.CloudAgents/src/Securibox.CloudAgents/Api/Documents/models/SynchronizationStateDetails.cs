namespace Securibox.CloudAgents.Api.Documents.Models
{
    /// <summary>
    /// Enumeration defining the synchronization agent process (web scraping).
    /// </summary>
    public enum SynchronizationStateDetails
    {
        /// <summary>
        /// The synchronization has just been created after an account creation.
        /// </summary>
        NewAccount,
        //Green
        /// <summary>
        /// The scrapping has successfully finished. (green status)
        /// </summary>
        Completed,
        /// <summary>
        /// The scrapping has successfully finished but no documents to download have been found. (green status)
        /// </summary>
        CompletedNothingToDownload,
        /// <summary>
        /// The synchronization has successfully terminated but didn't find any documents to download. (green status)
        /// </summary>
        CompletedNothingNewToDownload,
        /// <summary>
        /// The synchronization has successfully terminated but some documents counldn't be downloaded. (green status)
        /// </summary>
        CompletedWithMissingDocs,
        /// <summary>
        /// The synchronization has successfully terminated but some errors occured. (orange status)
        /// </summary>
        CompletedWithErrors,
        //Red
        /// <summary>
        /// The synchronization has dued to incorrect credentials. (red status)
        /// </summary>
        WrongCredentials,
        /// <summary>
        /// Deprecated
        /// </summary>
        UnexpectedAccountData,
        /// <summary>
        /// The synchonization request has been registered and will occur.
        /// </summary>
        Scheduled,
        /// <summary>
        /// The synchronization is in the queue to be handled.
        /// </summary>
        Pending,
        /// <summary>
        /// The synchonization is in progress.
        /// </summary>
        InProgress,
        /// <summary>
        /// The user has not activated the electronic invoices. Therefore there is no document available on the website.
        /// </summary>
        DematerialisationNeeded,
        /// <summary>
        /// The account is blocked. No new synchronization will occur without the account information being updated.
        /// </summary>
        CheckAccount,
        /// <summary>
        /// The account has been blocked (too many login tries wiith a wrong password).
        /// </summary>
        AccountBlocked,
        /// <summary>
        /// The agent website is requiring the user to go through one more authentication step.
        /// </summary>
        AdditionalAuthenticationRequired,
        /// <summary>
        /// The login process has changed and the agent is not prepared to handle it.
        /// </summary>
        LoginPageChanged,
        /// <summary>
        /// The page just after the login phase has changed and the agent is not prepared to handle it.
        /// </summary>
        WelcomePageChanged,
        /// <summary>
        /// The agent website is in maintenance.
        /// </summary>
        WebsiteInMaintenance,
        /// <summary>
        /// The agent isn't prepared to handle the website. It seems to have changed.
        /// </summary>
        WebsiteChanged,
        /// <summary>
        /// The agent website is warning the user that he will have to reset his password in the near future (limited account connexions with same password).
        /// </summary>
        ResetPasswordWarning,
        /// <summary>
        /// The agent website requires the password to be reset.
        /// </summary>
        ResetPasswordRequired,
        /// <summary>
        /// The agent website is unavailable.
        /// </summary>
        ServerUnavailable,
        /// <summary>
        /// The website is requiring the account owner to validate a notification.
        /// </summary>
        PersonalNotification,
        /// <summary>
        /// There's a temporary error in the agent website
        /// </summary>
        TemporaryServerError,
        /// <summary>
        /// A captcha needs to be solved for the agent to perform login
        /// </summary>
        CaptchaFound,
        /// <summary>
        /// The credential necessary for multi-factor authentication is wrong
        /// </summary>
        WrongOptionalCredentials,
        /// <summary>
        /// The secret code for the multi-fact authentication is wrong
        /// </summary>
        WrongMFACode
    }
}

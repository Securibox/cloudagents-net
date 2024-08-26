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
        NewAccount = 0,
        //Green
        /// <summary>
        /// The scrapping has successfully finished. (green status)
        /// </summary>
        Completed = 1,
        /// <summary>
        /// The scrapping has successfully finished but no documents to download have been found. (green status)
        /// </summary>
        CompletedNothingToDownload = 2,
        /// <summary>
        /// The synchronization has successfully terminated but didn't find any documents to download. (green status)
        /// </summary>
        CompletedNothingNewToDownload = 3,
        /// <summary>
        /// The synchronization has successfully terminated but some documents counldn't be downloaded. (green status)
        /// </summary>
        CompletedWithMissingDocs = 4,
        /// <summary>
        /// The synchronization has successfully terminated but some errors occured. (orange status)
        /// </summary>
        CompletedWithErrors = 5,
        //Red
        /// <summary>
        /// The synchronization has dued to incorrect credentials. (red status)
        /// </summary>
        WrongCredentials = 6,
        /// <summary>
        /// Deprecated
        /// </summary>
        UnexpectedAccountData = 7,
        /// <summary>
        /// The synchonization request has been registered and will occur.
        /// </summary>
        Scheduled = 8,
        /// <summary>
        /// The synchronization is in the queue to be handled.
        /// </summary>
        Pending = 9,
        /// <summary>
        /// The synchonization is in progress.
        /// </summary>
        InProgress = 10,
        /// <summary>
        /// The user has not activated the electronic invoices. Therefore there is no document available on the website.
        /// </summary>
        DematerialisationNeeded = 11,
        /// <summary>
        /// The account is blocked. No new synchronization will occur without the account information being updated.
        /// </summary>
        CheckAccount = 12,
        /// <summary>
        /// The account has been blocked (too many login tries wiith a wrong password).
        /// </summary>
        AccountBlocked = 13,
        /// <summary>
        /// The agent website is requiring the user to go through one more authentication step.
        /// </summary>
        AdditionalAuthenticationRequired = 14,
        /// <summary>
        /// The login process has changed and the agent is not prepared to handle it.
        /// </summary>
        LoginPageChanged = 15,
        /// <summary>
        /// The page just after the login phase has changed and the agent is not prepared to handle it.
        /// </summary>
        WelcomePageChanged = 16,
        /// <summary>
        /// The agent website is in maintenance.
        /// </summary>
        WebsiteInMaintenance = 17,
        /// <summary>
        /// The agent isn't prepared to handle the website. It seems to have changed.
        /// </summary>
        WebsiteChanged = 18,
        /// <summary>
        /// The agent website is warning the user that he will have to reset his password in the near future (limited account connexions with same password).
        /// </summary>
        ResetPasswordWarning = 19,
        /// <summary>
        /// The agent website requires the password to be reset.
        /// </summary>
        ResetPasswordRequired = 20,
        /// <summary>
        /// The agent website is unavailable.
        /// </summary>
        ServerUnavailable = 21,
        /// <summary>
        /// The website is requiring the account owner to validate a notification.
        /// </summary>
        PersonalNotification = 22,
        /// <summary>
        /// There's a temporary error in the agent website
        /// </summary>
        TemporaryServerError = 23,
        /// <summary>
        /// A captcha needs to be solved for the agent to perform login
        /// </summary>
        CaptchaFound = 24,
        /// <summary>
        /// The credential necessary for multi-factor authentication is wrong
        /// </summary>
        WrongOptionalCredentials = 25,
        /// <summary>
        /// The secret code for the multi-fact authentication is wrong
        /// </summary>
        WrongMFACode = 26,
        /// <summary>
        /// The secret code for the multi-fact authentication has expired
        /// </summary>
        ExpiredMFACode = 27,
        /// <summary>
        /// The identity provider (such as France Connect) is not linked to the account
        /// </summary>
        IdentityProviderNotLinkedToAccount = 28,
        /// <summary>
        /// User validation request sent through an app or website for MFA
        /// </summary>
        PendingUserValidation = 29,
        /// <summary>
        /// The agent has been logged out during the download process
        /// </summary>
        LoggedOutDuringDownload = 30,
        /// <summary>
        /// Failed to connect to the proxy
        /// </summary>
        ProxyFailure = 31,
        /// <summary>
        /// The synchronization has been blocked by a website protection service
        /// </summary>
        BlockedByWebsiteProtectionService = 32,
        /// <summary>
        /// Additional authentication is required but not in tha case of a multi-factor authentication
        /// </summary>
        AdditionalAuthenticationRequiredNotMFA = 33,
    }
}

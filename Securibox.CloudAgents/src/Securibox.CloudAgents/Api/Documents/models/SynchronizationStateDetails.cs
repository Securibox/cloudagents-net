namespace Securibox.CloudAgents.Api.Documents.Models
{
    /// <summary>
    /// SynchronizationStateDetails enum
    /// </summary>
    public enum SynchronizationStateDetails
    {
        NewAccount,
        //Green
        Completed, // SyncronizationState.Delivering -- SyncronizationState.Completed
        CompletedNothingToDownload,  // SyncronizationState.Delivering -- SyncronizationState.Completed
        CompletedNothingNewToDownload,  // SyncronizationState.Delivering -- SyncronizationState.Completed
        CompletedWithMissingDocs,  // SyncronizationState.Delivering -- SyncronizationState.Completed
        CompletedWithErrors,  // SyncronizationState.Delivering -- SyncronizationState.Completed
        //Red
        WrongCredentials, // SynchronizationState.LoginFailed 
        UnexpectedAccountData, // Unexpected
        //Green
        Scheduled, // SynchronizationState.Created
        Pending, // SyncronizationState.Created
        InProgress, // SyncronizationState.Running
        //Orange
        DematerialisationNeeded, // Not implemented by current agents
        CheckAccount, // Used when invalid credentials are provided during account creation. No implementation.
        AccountBlocked,
        AdditionalAuthenticationRequired,
        LoginPageChanged,
        WelcomePageChanged,
        WebsiteInMaintenance,
        WebsiteChanged,
        ResetPasswordWarning,
        ResetPasswordRequired,
        ServerUnavailable,
        PersonalNotification
    }
}

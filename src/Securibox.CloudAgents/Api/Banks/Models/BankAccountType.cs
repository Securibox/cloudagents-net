namespace Securibox.CloudAgents.Api.Banks.Models
{
    /// <summary>
    /// Type of bank account
    /// </summary>
    public enum BankAccountType
    {
        /// <summary>
        /// Undefined account
        /// </summary>
        Undefined,
        /// <summary>
        /// Current or check account
        /// </summary>
        Current,
        /// <summary>
        /// Savings account
        /// </summary>
        Saving,
        /// <summary>
        /// Credit or mortgage account
        /// </summary>
        Credit
    }
}

using System.ComponentModel.DataAnnotations;

namespace Securibox.CloudAgents.Api.Banks.Models
{
    /// <summary>
    /// Object representing a bank agent.
    /// </summary>
    public class Bank
    {
        /// <summary>
        /// The bank identifier
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// The bank name
        /// </summary>
        [MaxLength(256)]
        public string Name { get; set; }
        /// <summary>
        /// The bank branch name
        /// </summary>
        [MaxLength(64)]
        public string BranchName { get; set; }
        /// <summary>
        /// The bank display name
        /// </summary>
        [MaxLength(64)]
        public string DisplayName { get; set; }
        /// <summary>
        /// The national bank code
        /// </summary>
        [MaxLength(64)]
        public string NationalBankCode { get; set; }
        /// <summary>
        /// The bank country codes
        /// </summary>
        public string[] CountryCodes { get; set; }
        /// <summary>
        /// The bank website login URL.
        /// </summary>
        public string LoginUrl { get; set; }
        /// <summary>
        /// The bank agent status
        /// </summary>
        public BankStatus Status { get; set; }
        /// <summary>
        /// The fields that must be filled to perform the login.
        /// </summary>
        public Field[] Fields { get; set; }
    }
}

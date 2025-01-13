using Securibox.CloudAgents.Core;
using Securibox.CloudAgents.Core.AuthConfigs;
using System;
using System.Diagnostics;

namespace Securibox.CloudAgents.Api.Banks
{
    /// <summary>
    /// [Obsolete("This class is deprecated.")]
    /// Class wrapping the SCA REST APIs for the bank accounts aggregation.
    /// </summary>
    [Obsolete("This class is deprecated.")]
    public class ApiClient : AuthClient
    {
        #region Private Properties
        private AccountsClient _accountsClient;
        private BanksClient _banksClient;
        private SynchronizationsClient _synchronizationsClient;
        private BankAccountsClient _bankAccountsClient;
        #endregion

        #region Public Properties
        /// <summary>
        /// Client exposing all the available methods for the Accounts.
        /// </summary>
        public AccountsClient AccountsClient
        {
            get
            {
                if (_accountsClient == null)
                {
                    _accountsClient = new AccountsClient(this);
                }
                return _accountsClient;
            }
        }
        /// <summary>
        /// Client exposing all the available methods for the Banks.
        /// </summary>
        public BanksClient BanksClient
        {
            get
            {
                if (_banksClient == null)
                {
                    _banksClient = new BanksClient(this);
                }
                return _banksClient;
            }
        }
        /// <summary>
        /// Client exposing all the available methods for the Banks.
        /// </summary>
        public BankAccountsClient BankAccountsClient
        {
            get
            {
                if (_bankAccountsClient == null)
                {
                    _bankAccountsClient = new BankAccountsClient(this);
                }
                return _bankAccountsClient;
            }
        }
        /// <summary>
        /// Client exposing all the available methods for the Synchronizations.
        /// </summary>
        public SynchronizationsClient SynchronizationsClient
        {
            get
            {
                if (_synchronizationsClient == null)
                {
                    _synchronizationsClient = new SynchronizationsClient(this);
                }
                return _synchronizationsClient;
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes the SCA Documents wrapper using a provided SCA base address and a authentication configuration.
        /// </summary>
        /// <param name="baseAddress">The SCA platform base address in string format</param>
        /// <param name="authConfig">An authentication configuration</param>
        public ApiClient(string baseAddress, AuthClientConfig authConfig) : base(baseAddress, authConfig){ }
        /// <summary>
        /// Initializes the SCA Documents wrapper using a provided SCA base address and a authentication configuration.
        /// </summary>
        /// <param name="baseUri">The SCA platform base address in uri format</param>
        /// <param name="authConfig">An authentication configuration</param>
        public ApiClient(Uri baseUri, AuthClientConfig authConfig) : base(baseUri, authConfig) { }
        /// <summary>
        /// Initializes the SCA Documents wrapper from the web.config configuration
        /// </summary>
        public ApiClient() : base() { }
        #endregion
    }
}

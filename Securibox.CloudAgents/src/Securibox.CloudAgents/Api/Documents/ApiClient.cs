using Securibox.CloudAgents.Core;
using Securibox.CloudAgents.Core.AuthConfigs;
using System;

namespace Securibox.CloudAgents.Api.Documents
{
    /// <summary>
    /// Class wrapping the SCA REST APIs for the document aggregation.
    /// </summary>
    public class ApiClient : AuthClient
    {
        private AccountsClient _accountsClient;
        /// <summary>
        /// Client exposing all the available methods for the Accounts.
        /// </summary>
        public AccountsClient AccountsClient
        {
            get
            {
                if(_accountsClient == null)
                {
                    _accountsClient = new AccountsClient(this);
                }
                return _accountsClient;
            }
        }

        private AgentsClient _agentsClient;
        /// <summary>
        /// Client exposing all the available methods for the Agents.
        /// </summary>
        public AgentsClient AgentsClient
        {
            get
            {
                if (_agentsClient == null)
                {
                    _agentsClient = new AgentsClient(this);
                }
                return _agentsClient;
            }
        }

        private CategoriesClient _categoriesClient;
        /// <summary>
        /// Client exposing all the available methods for the Catgories.
        /// </summary>
        public CategoriesClient CategoriesClient
        {
            get
            {
                if (_categoriesClient == null)
                {
                    _categoriesClient = new CategoriesClient(this);
                }
                return _categoriesClient;
            }
        }

        private DocumentsClient _documentsClient;
        /// <summary>
        /// Client exposing all the available methods for the Documents.
        /// </summary>
        public DocumentsClient DocumentsClient
        {
            get
            {
                if (_documentsClient == null)
                {
                    _documentsClient = new DocumentsClient(this);
                }
                return _documentsClient;
            }
        }

        private SynchronizationsClient _synchronizationsClient;
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

        /// <summary>
        /// Initializes the SCA Documents wrapper using a provided SCA base address and a authentication configuration.
        /// </summary>
        /// <param name="baseAddress">The SCA platform base address in string format</param>
        /// <param name="authConfig">An authentication configuration</param>
        public ApiClient(string baseAddress, AuthClientConfig authConfig):base(baseAddress, authConfig)
        {

        }
        /// <summary>
        /// Initializes the SCA Documents wrapper using a provided SCA base address and a authentication configuration.
        /// </summary>
        /// <param name="baseUri">The SCA platform base address in uri format</param>
        /// <param name="authConfig">An authentication configuration</param>
        public ApiClient(Uri baseUri, AuthClientConfig authConfig): base(baseUri, authConfig) { }
        /// <summary>
        /// Initializes the SCA Documents wrapper from the web.config configuration
        /// </summary>
        public ApiClient():base() { }
        
    }
}

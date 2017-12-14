using Securibox.CloudAgents.SDK.Api.Documents.Models;
using Securibox.CloudAgents.SDK.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Securibox.CloudAgents.SDK.Api.Documents
{
    public class AccountsClient
    {
        private readonly string _path = "accounts";
        private readonly string _apiVersion = "v1";

        private Client _client;
        protected Client Client
        {
            get
            {
                if (_client == null)
                    _client = ApiClient.GetClient();
                return _client;
            }
        }

        #region ACCOUNT Methods
        /// <summary>
        /// Gets the account.
        /// </summary>
        /// <param name="customerAccountId">The identifier.</param>
        /// <returns></returns>
        public Account GetAccount(string customerAccountId)
        {
            if (string.IsNullOrEmpty(customerAccountId))
                throw new ApiClientHttpException((int)System.Net.HttpStatusCode.BadRequest, "CustomerAccountId missing.");

            var requestUri = new Uri(Client.BaseUri, string.Format("api/{0}/{1}/{2}", _apiVersion, _path, customerAccountId));
            var response = Client.ApiGet(requestUri);
            return response.GetObjectFromResponse<Account>();
        }
        /// <summary>
        /// Lists the accounts.
        /// </summary>
        /// <param name="skip">The skip.</param>
        /// <param name="take">The take.</param>
        /// <returns></returns>
        public List<Account> ListAccounts(string agentId = null, string customerUserId = null, int skip = 0, int take = 0)
        {
            var requestUri = new Uri(Client.BaseUri, string.Format("api/{0}/{1}", _apiVersion, _path));
            requestUri = requestUri.AddQueryParameter("agentId", agentId);
            requestUri = requestUri.AddQueryParameter("customerUserId", customerUserId);
            requestUri = requestUri.AddQueryParameter("skip", skip);
            if (take != 0)
            {
                requestUri = requestUri.AddQueryParameter("take", take);
            }
            var response = Client.ApiGet(requestUri);
            return response.GetObjectFromResponse<List<Account>>();
        }
        /// <summary>
        /// Searches the accounts.
        /// </summary>
        /// <param name="customerAccountId">The customer account identifier.</param>
        /// <param name="customerUserId">The customer user identifier.</param>
        /// <returns></returns>
        public List<Account> SearchAccounts(string agentId = null, string customerUserId = null, int skip = 0, int take = 0)
        {
            var requestUri = new Uri(Client.BaseUri, string.Format("api/{0}/{1}/{2}/search", _apiVersion, _path, customerUserId));

            requestUri = requestUri.AddQueryParameter("agentId", agentId);
            requestUri = requestUri.AddQueryParameter("customerUserId", customerUserId);
            requestUri = requestUri.AddQueryParameter("skip", skip);
            if (take != 0)
            {
                requestUri = requestUri.AddQueryParameter("take", take);
            }
            var response = Client.ApiGet(requestUri);
            return response.GetObjectFromResponse<List<Account>>();
        }
        /// <summary>
        /// Creates the account.
        /// </summary>
        /// <param name="apiAccount">The API account.</param>
        /// <returns></returns>
        public Account CreateAccount(Account apiAccount, bool synchronize)
        {
            if (apiAccount == null)
                throw new ApiClientHttpException((int)System.Net.HttpStatusCode.BadRequest, "ApiAccount payload missing.");

            var requestUri = new Uri(Client.BaseUri, string.Format("api/{0}/{1}", _apiVersion, _path));
            var apiAccountRequest = new CreateAccountRequest(apiAccount, synchronize);

            var response = Client.ApiPost(requestUri, Newtonsoft.Json.JsonConvert.SerializeObject(apiAccountRequest));
            return response.GetObjectFromResponse<Account>();
        }
        /// <summary>
        /// Updates the account.
        /// </summary>
        /// <param name="customerAccountId">The identifier.</param>
        /// <param name="apiAccount">The API account.</param>
        /// <returns></returns>
        public Account UpdateAccount(string customerAccountId, Account apiAccount)
        {
            if (apiAccount == null)
                throw new ApiClientHttpException((int)System.Net.HttpStatusCode.BadRequest, "ApiAccount payload missing.");

            if (string.IsNullOrEmpty(customerAccountId))
                throw new ApiClientHttpException((int)System.Net.HttpStatusCode.BadRequest, "CustomerAccountId missing.");

            var requestUri = new Uri(Client.BaseUri, string.Format("api/{0}/{1}/{2}", _apiVersion, _path, customerAccountId));
            var response = Client.ApiPut(requestUri, Newtonsoft.Json.JsonConvert.SerializeObject(apiAccount));
            return response.GetObjectFromResponse<Account>();
        }
        /// Deletes the account.
        /// </summary>
        /// <param name="customerAccountId">The identifier.</param>
        public void DeleteAccount(string customerAccountId)
        {
            if (string.IsNullOrEmpty(customerAccountId))
                throw new ApiClientHttpException((int)System.Net.HttpStatusCode.BadRequest, "CustomerAccountId missing.");

            var requestUri = new Uri(Client.BaseUri, string.Format("api/{0}/{1}/{2}", _apiVersion, _path, customerAccountId));
            Client.ApiDelete(requestUri);
        }
        /// <summary>
        /// Lists the documents.
        /// </summary>
        /// <param name="customerAccountId">The identifier.</param>
        /// <param name="pendingOnly">if set to <c>true</c> [pending only].</param>
        /// <param name="includeContent">if set to <c>true</c> [include content].</param>
        /// <returns></returns>
        public List<Document> ListDocumentsByAccount(string customerAccountId, bool pendingOnly = false, bool includeContent = false)
        {
            if (string.IsNullOrEmpty(customerAccountId))
                throw new ApiClientHttpException((int)System.Net.HttpStatusCode.BadRequest, "CustomerAccountId missing.");

            var requestUri = new Uri(Client.BaseUri, string.Format("api/{0}/{1}/{2}/documents", _apiVersion, _path, customerAccountId));
            requestUri = requestUri.AddQueryParameter("pendingOnly", pendingOnly);
            requestUri = requestUri.AddQueryParameter("includeContent", includeContent);

            var response = Client.ApiGet(requestUri);
            return response.GetObjectFromResponse<List<Document>>();
        }
        /// <summary>
        /// Lists the synchronizations.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="startDateString">The start date.</param>
        /// <param name="endDateString">The end date.</param>
        /// <returns></returns>
        public List<Synchronization> ListSynchronizationsByAccount(string customerAccountId, DateTime? startDate = null, DateTime? endDate = null)
        {
            if (string.IsNullOrEmpty(customerAccountId))
                throw new ApiClientHttpException((int)System.Net.HttpStatusCode.BadRequest, "CustomerAccountId missing.");

            var requestUri = new Uri(Client.BaseUri, string.Format("api/{0}/{1}/{2}/synchronizations", _apiVersion, _path, customerAccountId));

            string startDateString = null;
            string endDateString = null;

            if (startDate != null)
            {
                startDateString = Uri.EscapeDataString(startDate.Value.ToUniversalTime().ToString("u"));
            }

            if (endDate != null)
            {
                endDateString = Uri.EscapeDataString(endDate.Value.ToUniversalTime().ToString("u"));
            }

            requestUri = requestUri.AddQueryParameter("startDate", startDateString);
            requestUri = requestUri.AddQueryParameter("endDate", endDateString);

            var response = Client.ApiGet(requestUri);
            return response.GetObjectFromResponse<List<Synchronization>>();
        }
        /// <summary>
        /// Gets the last synchronization of an account.
        /// </summary>
        /// <param name="customerAccountId"></param>
        /// <returns></returns>
        public Synchronization GetLastSynchronizationsOfAccount(string customerAccountId)
        {
            if (string.IsNullOrEmpty(customerAccountId))
                throw new ApiClientHttpException((int)System.Net.HttpStatusCode.BadRequest, "CustomerAccountId missing.");

            var requestUri = new Uri(Client.BaseUri, string.Format("api/{0}/{1}/{2}/synchronizations/last", _apiVersion, _path, customerAccountId));
            var response = Client.ApiGet(requestUri);
            return response.GetObjectFromResponse<Synchronization>();
        }

        /// <summary>
        /// Synchronizes the account.
        /// </summary>
        /// <param name="customerAccountId">The identifier.</param>
        /// <param name="isForced">if set to <c>true</c> [is forced].</param>
        /// <returns></returns>
        public Synchronization SynchronizeAccount(string customerAccountId, bool isForced)
        {
            if (string.IsNullOrEmpty(customerAccountId))
                throw new ApiClientHttpException((int)System.Net.HttpStatusCode.BadRequest, "CustomerAccountId missing.");

            var requestUri = new Uri(Client.BaseUri, string.Format("api/{0}/{1}/{2}/synchronizations", _apiVersion, _path, customerAccountId));
            var synchRequest = new SynchronizationRequest(customerAccountId, isForced);
            var response = Client.ApiPost(requestUri, Newtonsoft.Json.JsonConvert.SerializeObject(synchRequest));
            return response.GetObjectFromResponse<Synchronization>();
        }
        #endregion

        #region Private Api Classes
        /// <summary>
        /// CreateAccountRequest class
        /// </summary>
        private class CreateAccountRequest
        {
            /// <summary>
            /// Gets or sets a value indicating whether this <see cref="CreateAccountRequest"/> is to be immediately synchronized.
            /// </summary>
            /// <value>
            ///   <c>true</c> if synchronize; otherwise, <c>false</c>.
            /// </value>
            public bool Synchronize { get; set; }
            /// <summary>
            /// Gets or sets the account.
            /// </summary>
            /// <value>
            /// The account.
            /// </value>
            public Account Account { get; set; }

            public CreateAccountRequest(Account account, bool synchronize)
            {
                this.Account = account;
                this.Synchronize = synchronize;
            }
        }

        /// <summary>
        /// SynchronizationRequest class
        /// </summary>
        private class SynchronizationRequest
        {
            /// <summary>
            /// Gets or sets the customer account identifier.
            /// </summary>
            /// <value>
            /// The customer account identifier.
            /// </value>
            private string CustomerAccountId { get; set; }
            /// <summary>
            /// Gets or sets the customer user identifier.
            /// </summary>
            /// <value>
            /// The customer user identifier.
            /// </value>
            private string CustomerUserId { get; set; }
            /// <summary>
            /// Gets or sets a value indicating whether this <see cref="SynchronizeRequest" /> is forced.
            /// </summary>
            /// <value>
            ///   <c>true</c> if forced; otherwise, <c>false</c>.
            /// </value>
            private bool IsForced { get; set; }

            public SynchronizationRequest(string customerAccountId, bool isForced)
            {
                this.CustomerAccountId = customerAccountId;
                this.IsForced = isForced;
            }
        }
        #endregion
    }
}

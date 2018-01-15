using Securibox.CloudAgents.Api.Documents.Models;
using Securibox.CloudAgents.Core;
using System;
using System.Collections.Generic;

namespace Securibox.CloudAgents.Api.Documents
{
    /// <summary>
    /// Wrapper for the accounts related methods.
    /// </summary>
    public class AccountsClient : ApiObjectClient
    {
        private readonly string _path = "accounts";
        private readonly string _apiVersion = "v1";

        public AccountsClient(AuthClient authenticatedClient): base (authenticatedClient)
        {
        }



        #region ACCOUNT Methods
        /// <summary>
        /// Gets an account by customer account identifier.
        /// </summary>
        /// <param name="customerAccountId">The customer account identifier.</param>
        /// <returns>An account</returns>
        public Account GetAccount(string customerAccountId)
        {
            if (string.IsNullOrEmpty(customerAccountId))
                throw new ApiClientHttpException((int)System.Net.HttpStatusCode.BadRequest, "CustomerAccountId missing.");

            var requestUri = new Uri(_authenticatedClient.BaseUri, string.Format("api/{0}/{1}/{2}", _apiVersion, _path, customerAccountId));
            var response = _authenticatedClient.HttpClient.ApiGet(requestUri);
            return response.GetObjectFromResponse<Account>();
        }
        /// <summary>
        /// Lists all accounts.
        /// </summary>
        /// <param name="agentId">The identifier of the agents to be able to filter by agent.</param>
        /// <param name="customerUserId">The customer user identifier to be able to filter accounts by user</param>
        /// <param name="skip">The number of accounts to skip (used for pagination).</param>
        /// <param name="take">The maximum number of accounts to be returned (used for pagination).</param>
        /// <returns></returns>
        public List<Account> ListAccounts(string agentId = null, string customerUserId = null, int skip = 0, int take = 0)
        {
            var requestUri = new Uri(_authenticatedClient.BaseUri, string.Format("api/{0}/{1}", _apiVersion, _path));
            requestUri = requestUri.AddQueryParameter("agentId", agentId);
            requestUri = requestUri.AddQueryParameter("customerUserId", customerUserId);
            requestUri = requestUri.AddQueryParameter("skip", skip);
            if (take != 0)
            {
                requestUri = requestUri.AddQueryParameter("take", take);
            }
            var response = _authenticatedClient.HttpClient.ApiGet(requestUri);
            return response.GetObjectFromResponse<List<Account>>();
        }
        /// <summary>
        /// Searches accounts by agent identifier and/or by customer account identifier.
        /// </summary>
        /// <param name="agentId">The identifier of the agents to be able to filter by agent.</param>
        /// <param name="customerUserId">The identifier of the user to be able to filter by user.</param>
        /// <param name="skip">The number of accounts to skip (used for pagination).</param>
        /// <param name="take">The maximum number of accounts to be returned (used for pagination).</param>
        /// <returns></returns>
        public List<Account> SearchAccounts(string agentId = null, string customerUserId = null, int skip = 0, int take = 0)
        {
            var requestUri = new Uri(_authenticatedClient.BaseUri, string.Format("api/{0}/{1}/{2}/search", _apiVersion, _path, customerUserId));

            requestUri = requestUri.AddQueryParameter("agentId", agentId);
            requestUri = requestUri.AddQueryParameter("customerUserId", customerUserId);
            requestUri = requestUri.AddQueryParameter("skip", skip);
            if (take != 0)
            {
                requestUri = requestUri.AddQueryParameter("take", take);
            }
            var response = _authenticatedClient.HttpClient.ApiGet(requestUri);
            return response.GetObjectFromResponse<List<Account>>();
        }
        /// <summary>
        /// Creates and optionally synchronizes an account.
        /// </summary>
        /// <param name="apiAccount">The account object to be created.  </param>
        /// <returns>The created account.</returns>
        public Account CreateAccount(Account apiAccount, bool synchronize)
        {
            if (apiAccount == null)
                throw new ApiClientHttpException((int)System.Net.HttpStatusCode.BadRequest, "ApiAccount payload missing.");

            var requestUri = new Uri(_authenticatedClient.BaseUri, string.Format("api/{0}/{1}", _apiVersion, _path));
            var apiAccountRequest = new CreateAccountRequest(apiAccount, synchronize);

            var response = _authenticatedClient.HttpClient.ApiPost(requestUri, Newtonsoft.Json.JsonConvert.SerializeObject(apiAccountRequest));
            return response.GetObjectFromResponse<Account>();
        }
        /// <summary>
        /// Update an existing account information.
        /// </summary>
        /// <param name="customerAccountId">The customer account identifier for the account to be modified.   </param>
        /// <param name="apiAccount">The account object with the new values    </param>
        /// <returns>An account.</returns>
        public Account UpdateAccount(string customerAccountId, Account apiAccount)
        {
            if (apiAccount == null)
                throw new ApiClientHttpException((int)System.Net.HttpStatusCode.BadRequest, "ApiAccount payload missing.");

            if (string.IsNullOrEmpty(customerAccountId))
                throw new ApiClientHttpException((int)System.Net.HttpStatusCode.BadRequest, "CustomerAccountId missing.");

            var requestUri = new Uri(_authenticatedClient.BaseUri, string.Format("api/{0}/{1}/{2}", _apiVersion, _path, customerAccountId));
            var response = _authenticatedClient.HttpClient.ApiPut(requestUri, Newtonsoft.Json.JsonConvert.SerializeObject(apiAccount));
            return response.GetObjectFromResponse<Account>();
        }
        /// <summary>
        /// Deletes an account by customer account identifier.
        /// </summary>
        /// <param name="customerAccountId">The customer account identifier.</param>
        /// <returns>true if the account has been successfully deleted, false otherwise.</returns>
        public bool DeleteAccount(string customerAccountId)
        {
            if (string.IsNullOrEmpty(customerAccountId))
                throw new ApiClientHttpException((int)System.Net.HttpStatusCode.BadRequest, "CustomerAccountId missing.");

            var requestUri = new Uri(_authenticatedClient.BaseUri, string.Format("api/{0}/{1}/{2}", _apiVersion, _path, customerAccountId));
            var apiResponse = _authenticatedClient.HttpClient.ApiDelete(requestUri);
            if (apiResponse.GetStatusCode() == System.Net.HttpStatusCode.OK)
                return true;

            return false;
        }
        /// <summary>
        /// Gets all documents for an account
        /// </summary>
        /// <param name="customerAccountId">The customer account identifier.</param>
        /// <param name="pendingOnly">Lists only the documents not delivered.</param>
        /// <param name="includeContent">Specifies if the response should include the document content in base64 enconding.</param>
        /// <returns>An array of Document objects</returns>
        public List<Document> ListDocumentsByAccount(string customerAccountId, bool pendingOnly = false, bool includeContent = false)
        {
            if (string.IsNullOrEmpty(customerAccountId))
                throw new ApiClientHttpException((int)System.Net.HttpStatusCode.BadRequest, "CustomerAccountId missing.");

            var requestUri = new Uri(_authenticatedClient.BaseUri, string.Format("api/{0}/{1}/{2}/documents", _apiVersion, _path, customerAccountId));
            requestUri = requestUri.AddQueryParameter("pendingOnly", pendingOnly);
            requestUri = requestUri.AddQueryParameter("includeContent", includeContent);

            var response = _authenticatedClient.HttpClient.ApiGet(requestUri);
            return response.GetObjectFromResponse<List<Document>>();
        }
        /// <summary>
        /// List the synchronizations by account and optionnally filter by a date window.
        /// </summary>
        /// <param name="customerAccountId">The customer account identifier.</param>
        /// <param name="startDate"> The start date filter.</param>
        /// <param name="endDate">The end date filter.</param>
        /// <returns></returns>
        public List<Synchronization> ListSynchronizationsByAccount(string customerAccountId, DateTime? startDate = null, DateTime? endDate = null)
        {
            if (string.IsNullOrEmpty(customerAccountId))
                throw new ApiClientHttpException((int)System.Net.HttpStatusCode.BadRequest, "CustomerAccountId missing.");

            var requestUri = new Uri(_authenticatedClient.BaseUri, string.Format("api/{0}/{1}/{2}/synchronizations", _apiVersion, _path, customerAccountId));

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

            var response = _authenticatedClient.HttpClient.ApiGet(requestUri);
            return response.GetObjectFromResponse<List<Synchronization>>();
        }
        /// <summary>
        /// Gets the last synchronization of an account.
        /// </summary>
        /// <param name="customerAccountId"> The customer account identifier for which you want to have the last synchronization.</param>
        /// <returns>A Synchronization object.</returns>
        public Synchronization GetLastSynchronizationsOfAccount(string customerAccountId)
        {
            if (string.IsNullOrEmpty(customerAccountId))
                throw new ApiClientHttpException((int)System.Net.HttpStatusCode.BadRequest, "CustomerAccountId missing.");

            var requestUri = new Uri(_authenticatedClient.BaseUri, string.Format("api/{0}/{1}/{2}/synchronizations/last", _apiVersion, _path, customerAccountId));
            var response = _authenticatedClient.HttpClient.ApiGet(requestUri);
            return response.GetObjectFromResponse<Synchronization>();
        }

        /// <summary>
        /// Launches the synchronization for a specific account.
        /// </summary>
        /// <param name="customerAccountId">The customer account identifier.</param>
        /// <param name="isForced">if set to <c>true</c> [is forced].</param>
        /// <returns>A Synchronization object.</returns>
        public Synchronization SynchronizeAccount(string customerAccountId, bool isForced)
        {
            if (string.IsNullOrEmpty(customerAccountId))
                throw new ApiClientHttpException((int)System.Net.HttpStatusCode.BadRequest, "CustomerAccountId missing.");

            var requestUri = new Uri(_authenticatedClient.BaseUri, string.Format("api/{0}/{1}/{2}/synchronizations", _apiVersion, _path, customerAccountId));
            var synchRequest = new SynchronizationRequest(customerAccountId, isForced);
            var response = _authenticatedClient.HttpClient.ApiPost(requestUri, Newtonsoft.Json.JsonConvert.SerializeObject(synchRequest));
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

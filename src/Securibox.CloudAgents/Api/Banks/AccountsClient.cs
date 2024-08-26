using Securibox.CloudAgents.Api.Banks.Models;
using Securibox.CloudAgents.Core;
using System;
using System.Collections.Generic;

namespace Securibox.CloudAgents.Api.Banks
{
    /// <summary>
    /// Wrapper for the accounts related methods.
    /// </summary>
    [Obsolete("This class is deprecated.")]
    public class AccountsClient : ApiObjectClient
    {
        private readonly string _path = "accounts";
        private readonly string _apiVersion = "bankv1";
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountsClient"/> class.
        /// </summary>
        /// <param name="authenticatedClient">An authentication client</param>
        public AccountsClient(AuthClient authenticatedClient) : base(authenticatedClient)
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
        /// <param name="skip">The number of accounts to skip (used for pagination).</param>
        /// <param name="take">The maximum number of accounts to be returned (used for pagination).</param>
        /// <returns></returns>
        public List<Account> ListAccounts(int skip = 0, int take = 0)
        {
            var requestUri = new Uri(_authenticatedClient.BaseUri, string.Format("api/{0}/{1}", _apiVersion, _path));
            requestUri = requestUri.AddQueryParameter("skip", skip);
            if (take != 0)
            {
                requestUri = requestUri.AddQueryParameter("take", take);
            }
            var response = _authenticatedClient.HttpClient.ApiGet(requestUri);
            return response.GetObjectFromResponse<List<Account>>();
        }
        /// <summary>
        /// Lists accounts by bank.
        /// </summary>
        /// <param name="bankIdentifier">The bank identifier</param>
        /// <param name="skip">The number of accounts to skip (used for pagination).</param>
        /// <param name="take">The maximum number of accounts to be returned (used for pagination).</param>
        /// <returns></returns>
        public List<Account> ListAccountsByBank(string bankIdentifier, int skip = 0, int take = 0)
        {
            var requestUri = new Uri(_authenticatedClient.BaseUri, string.Format("api/{0}/banks/{1}/accounts", _apiVersion, bankIdentifier));
            requestUri = requestUri.AddQueryParameter("skip", skip);
            if (take != 0)
            {
                requestUri = requestUri.AddQueryParameter("take", take);
            }
            var response = _authenticatedClient.HttpClient.ApiGet(requestUri);
            return response.GetObjectFromResponse<List<Account>>();
        }


        /// <summary>
        /// Searches accounts by customer user identifier and/or by customer account identifier.
        /// </summary>
        /// <param name="customerAccountId">The identifier of the account to be able to filter by account.</param>
        /// <param name="customerUserId">The identifier of the user to be able to filter by user.</param>
        /// <returns></returns>
        public List<Account> SearchAccounts(string customerAccountId = null, string customerUserId = null)
        {
            var requestUri = new Uri(_authenticatedClient.BaseUri, string.Format("api/{0}/{1}/{2}/search", _apiVersion, _path, customerUserId));

            requestUri = requestUri.AddQueryParameter("customerAccountId", customerAccountId);
            requestUri = requestUri.AddQueryParameter("customerUserId", customerUserId);
            var response = _authenticatedClient.HttpClient.ApiGet(requestUri);
            return response.GetObjectFromResponse<List<Account>>();
        }
        /// <summary>
        /// Creates and optionally synchronizes an account.
        /// </summary>
        /// <param name="apiAccount">The account object to be created.  </param>
        /// <param name="synchronize">Specifies if the account is to be synchronized immediatly after the creation. </param>
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
            if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                return true;

            return false;
        }
        /// <summary>
        /// Gets all bank accounts for an account
        /// </summary>
        /// <param name="customerAccountId">The customer account identifier.</param>
        /// <param name="skip">The number of bank accounts to skip (used for pagination).</param>
        /// <param name="take">The maximum number of bank accounts to be returned (used for pagination).</param>
        /// <returns>An array of BankAccount objects</returns>
        public List<BankAccount> ListBankAccountsByAccount(string customerAccountId, int skip = 0, int take = 0)
        {
            if (string.IsNullOrEmpty(customerAccountId))
                throw new ApiClientHttpException((int)System.Net.HttpStatusCode.BadRequest, "CustomerAccountId missing.");

            var requestUri = new Uri(_authenticatedClient.BaseUri, string.Format("api/{0}/{1}/{2}/bankaccounts", _apiVersion, _path, customerAccountId));
            requestUri = requestUri.AddQueryParameter("skip", skip);
            if (take != 0)
            {
                requestUri = requestUri.AddQueryParameter("take", take);
            }

            var response = _authenticatedClient.HttpClient.ApiGet(requestUri);
            return response.GetObjectFromResponse<List<BankAccount>>();
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
            var response = _authenticatedClient.HttpClient.ApiPost(requestUri, isForced.ToString().ToLowerInvariant());
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
        #endregion
    }
}

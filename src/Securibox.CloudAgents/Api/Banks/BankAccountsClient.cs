using Securibox.CloudAgents.Api.Banks.Models;
using Securibox.CloudAgents.Core;
using System;

namespace Securibox.CloudAgents.Api.Banks
{
    /// <summary>
    /// [Obsolete("This class is deprecated.")]
    /// Wrapper for the bank accounts related methods.
    /// </summary>
    [Obsolete("This class is deprecated.")]
    public class BankAccountsClient : ApiObjectClient
    {
        private readonly string _path = "bankaccounts";
        private readonly string _apiVersion = "bankv1";
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountsClient"/> class.
        /// </summary>
        /// <param name="authenticatedClient">An authentication client</param>
        public BankAccountsClient(AuthClient authenticatedClient) : base(authenticatedClient)
        {
        }

        /// <summary>
        /// Get bank account by identifier.
        /// </summary>
        /// <param name="bankAccountIdentifier">The bank account identifier</param>
        /// <returns>A BankAccount</returns>
        public BankAccount GetBankAccount(string bankAccountIdentifier)
        {
            if (string.IsNullOrEmpty(bankAccountIdentifier))
                throw new ApiClientHttpException((int)System.Net.HttpStatusCode.BadRequest, "bankAccountIdentifier missing.");

            var requestUri = new Uri(_authenticatedClient.BaseUri, string.Format("api/{0}/{1}/{2}", _apiVersion, _path, bankAccountIdentifier));
            var response = _authenticatedClient.HttpClient.ApiGet(requestUri);
            return response.GetObjectFromResponse<BankAccount>();
        }
    }
}

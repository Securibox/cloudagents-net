using Securibox.CloudAgents.Api.Banks.Models;
using Securibox.CloudAgents.Core;
using System;
using System.Collections.Generic;

namespace Securibox.CloudAgents.Api.Banks
{
    /// <summary>
    /// Wrapper for the bank related methods.
    /// </summary>
    [Obsolete("This class is deprecated.")]
    public class BanksClient : ApiObjectClient
    {
        private readonly string _path = "banks";
        private readonly string _apiVersion = "bankv1";
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountsClient"/> class.
        /// </summary>
        /// <param name="authenticatedClient">An authentication client</param>
        public BanksClient(AuthClient authenticatedClient) : base(authenticatedClient)
        {
        }

        /// <summary>
        /// List all bank agents.
        /// </summary>
        /// <returns>A list of banks</returns>
        public List<Bank> GetBanks()
        {
            var requestUri = new Uri(_authenticatedClient.BaseUri, string.Format("api/{0}/{1}", _apiVersion, _path));
            var response = _authenticatedClient.HttpClient.ApiGet(requestUri);
            return response.GetObjectFromResponse<List<Bank>>();
        }
    }
}

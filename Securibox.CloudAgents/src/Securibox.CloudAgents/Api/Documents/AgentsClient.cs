using Securibox.CloudAgents.Api.Documents.Models;
using Securibox.CloudAgents.Core;
using System;
using System.Collections.Generic;

namespace Securibox.CloudAgents.Api.Documents
{
    /// <summary>
    /// Wrapper for the agents related methods.
    /// </summary>
    public class AgentsClient : ApiObjectClient
    {
        private readonly string _path = "agents";
        private readonly string _apiVersion = "v1";
        /// <summary>
        /// Initializes a new instance of the <see cref="AgentsClient"/> class.
        /// </summary>
        /// <param name="authenticatedClient">An authentication client</param>
        public AgentsClient(AuthClient authenticatedClient):base(authenticatedClient)
        {
        }

        #region AGENT Methods
        /// <summary>
        /// Lists all available agents.
        /// </summary>
        /// <param name="culture">he culture of the returned information.</param>
        /// <param name="includeLogo">Specifies if the response should include the agents logo in base64 enconding.</param>
        /// <returns></returns>
        public List<Agent> ListAgents(string culture = null, bool includeLogo = false)
        {
            var requestUri = new Uri(_authenticatedClient.BaseUri, string.Format("api/{0}/{1}", _apiVersion, _path));
            requestUri = requestUri.AddQueryParameter("culture", culture);
            requestUri = requestUri.AddQueryParameter("includeLogo", includeLogo);

            var response = _authenticatedClient.HttpClient.ApiGet(requestUri);
            return response.GetObjectFromResponse<List<Agent>>();
        }
        /// <summary>
        /// Lists all available agents.
        /// </summary>
        /// <param name="countryCode">The desired agents country.</param>
        /// <param name="culture">The culture of the returned information.</param>
        /// <param name="includeLogo">Specifies if the response should include the agents logo encoded in base 64.</param>
        /// <param name="q">The query string that will filter agents starting with the defined prefix</param>
        /// <returns>A list of agents.</returns>
        public List<Agent> SearchAgent(AgentCountryCode? countryCode = null, string culture = null, bool includeLogo = false, string q = null)
        {
            var requestUri = new Uri(_authenticatedClient.BaseUri, string.Format("api/{0}/{1}/search", _apiVersion, _path));
            if (countryCode != null)
            {
                requestUri = requestUri.AddQueryParameter("countryCode", countryCode.Value.ToString());
            }
            requestUri = requestUri.AddQueryParameter("culture", culture);
            requestUri = requestUri.AddQueryParameter("includeLogo", includeLogo);
            requestUri = requestUri.AddQueryParameter("culture", culture);
            requestUri = requestUri.AddQueryParameter("q", q);

            var response = _authenticatedClient.HttpClient.ApiGet(requestUri);
            return response.GetObjectFromResponse<List<Agent>>();
        }
        /// <summary>
        /// Lists accounts by agent.
        /// </summary>
        /// <param name="identifier">The identifier of the agents to be able to filter by agent.</param>
        /// <param name="skip">The number of accounts to skip (used for pagination).</param>
        /// <param name="take">The maximum number of accounts to be returned (used for pagination).</param>
        /// <returns>A list of accounts.</returns>
        public List<Account> ListAccountsByAgent(string identifier, int skip = 0, int take = 0)
        {
            if (string.IsNullOrEmpty(identifier))
                throw new ApiClientHttpException((int)System.Net.HttpStatusCode.BadRequest, "Agent Identifier missing.");

            var requestUri = new Uri(_authenticatedClient.BaseUri, string.Format("api/{0}/{1}/{2}/accounts", _apiVersion, _path, identifier));
            requestUri = requestUri.AddQueryParameter("skip", skip);
            if (take != 0)
            {
                requestUri = requestUri.AddQueryParameter("take", take);
            }
            var response = _authenticatedClient.HttpClient.ApiGet(requestUri);
            return response.GetObjectFromResponse<List<Account>>();
        }
        /// <summary>
        /// Get Agent By identifier
        /// </summary>
        /// <param name="identifier">The agent identifier</param>
        /// <returns>The agent</returns>
        public Agent GetAgentByIdentifier(string identifier)
        {
            if (string.IsNullOrEmpty(identifier))
                throw new ApiClientHttpException((int)System.Net.HttpStatusCode.BadRequest, "Agent Identifier missing.");

            var requestUri = new Uri(_authenticatedClient.BaseUri, string.Format("api/{0}/{1}/{2}", _apiVersion, _path, identifier));
            var response = _authenticatedClient.HttpClient.ApiGet(requestUri);
            return response.GetObjectFromResponse<Agent>();
        }
        #endregion
    }
}

using Securibox.CloudAgents.SDK.Api.Documents.Models;
using Securibox.CloudAgents.SDK.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Securibox.CloudAgents.SDK.Api.Documents
{
    public class AgentsClient : ApiClient
    {
        private readonly string _path = "agents";
        public AgentsClient()
            : base("v1")
        { }

        #region AGENT Methods
        /// <summary>
        /// Lists the agents.
        /// </summary>
        /// <returns></returns>
        public List<Agent> ListAgents(string culture = null, bool includeLogo = false)
        {
            var requestUri = new Uri(BaseUri, string.Format("api/{0}/{1}", ApiVersion, _path));
            requestUri = requestUri.AddQueryParameter("culture", culture);
            requestUri = requestUri.AddQueryParameter("includeLogo", includeLogo);

            var response = ApiGet(requestUri);
            return response.GetObjectFromResponse<List<Agent>>();
        }
        /// <summary>
        /// Searches the agent.
        /// </summary>
        /// <param name="country">The country.</param>
        /// <returns></returns>
        public List<Agent> SearchAgent(AgentCountryCode? countryCode = null, string culture = null, bool includeLogo = false, string q = null)
        {
            var requestUri = new Uri(BaseUri, string.Format("api/{0}/{1}/search", ApiVersion, _path));
            if (countryCode != null)
            {
                requestUri = requestUri.AddQueryParameter("countryCode", countryCode.Value.ToString());
            }
            requestUri = requestUri.AddQueryParameter("culture", culture);
            requestUri = requestUri.AddQueryParameter("includeLogo", includeLogo);
            requestUri = requestUri.AddQueryParameter("culture", culture);
            requestUri = requestUri.AddQueryParameter("q", q);

            var response = ApiGet(requestUri);
            return response.GetObjectFromResponse<List<Agent>>();
        }
        /// <summary>
        /// Lists the accounts by agent.
        /// </summary>
        /// <param name="identifier">The agent's identifier.</param>
        /// <param name="skip">The skip.</param>
        /// <param name="take">The take.</param>
        /// <returns></returns>
        public List<Account> ListAccountsByAgent(string identifier, int skip = 0, int take = 0)
        {
            if (string.IsNullOrEmpty(identifier))
                throw new ApiClientHttpException((int)System.Net.HttpStatusCode.BadRequest, "Agent Identifier missing.");

            var requestUri = new Uri(BaseUri, string.Format("api/{0}/{1}/{2}/accounts", ApiVersion, _path, identifier));
            requestUri = requestUri.AddQueryParameter("skip", skip);
            if (take != 0)
            {
                requestUri = requestUri.AddQueryParameter("take", take);
            }
            var response = ApiGet(requestUri);
            return response.GetObjectFromResponse<List<Account>>();
        }
        /// <summary>
        /// Get agent by agent identifier
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public Agent GetAgentByIdentifier(string identifier)
        {
            if (string.IsNullOrEmpty(identifier))
                throw new ApiClientHttpException((int)System.Net.HttpStatusCode.BadRequest, "Agent Identifier missing.");

            var requestUri = new Uri(BaseUri, string.Format("api/{0}/{1}/{2}", ApiVersion, _path, identifier));
            var response = ApiGet(requestUri);
            return response.GetObjectFromResponse<Agent>();
        }
        #endregion
    }
}

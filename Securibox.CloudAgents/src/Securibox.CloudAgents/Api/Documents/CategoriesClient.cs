using Securibox.CloudAgents.Api.Documents.Models;
using Securibox.CloudAgents.Core;
using System;
using System.Collections.Generic;

namespace Securibox.CloudAgents.Api.Documents
{
    public class CategoriesClient : ApiObjectClient
    {
        private readonly string _path = "categories";
        private readonly string _apiVersion = "v1";

        public CategoriesClient(AuthClient authenticatedClient):base(authenticatedClient)
        {
        }


        #region CATEGORIES Methods
        /// <summary>
        /// Lists the categories.
        /// </summary>
        /// <returns></returns>
        public List<Category> ListCategories(string culture = null)
        {
            var requestUri = new Uri(_authenticatedClient.BaseUri, string.Format("api/{0}/{1}", _apiVersion, _path));
            requestUri = requestUri.AddQueryParameter("culture", culture);

            var response = _authenticatedClient.HttpClient.ApiGet(requestUri);
            return response.GetObjectFromResponse<List<Category>>();
        }
        /// <summary>
        /// Lists the agents by category.
        /// </summary>
        /// <param name="categoryId">The identifier.</param>
        /// <returns></returns>
        public List<Agent> ListAgentsByCategory(string categoryId)
        {
            if (string.IsNullOrEmpty(categoryId))
                throw new ApiClientHttpException((int)System.Net.HttpStatusCode.BadRequest, "CategoryId missing.");

            var requestUri = new Uri(_authenticatedClient.BaseUri, string.Format("api/{0}/{1}/{2}/agents", _apiVersion, _path, categoryId));
            var response = _authenticatedClient.HttpClient.ApiGet(requestUri);
            return response.GetObjectFromResponse<List<Agent>>();
        }
        #endregion
    }
}

using Securibox.CloudAgents.SDK.Api.Documents.Models;
using Securibox.CloudAgents.SDK.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Securibox.CloudAgents.SDK.Api.Documents
{
    public class CategoriesClient : ApiClient
    {
        private readonly string _path = "categories";
        public CategoriesClient()
            : base("v1")
        { }

        #region CATEGORIES Methods
        /// <summary>
        /// Lists the categories.
        /// </summary>
        /// <returns></returns>
        public List<Category> ListCategories(string culture = null)
        {
            var requestUri = new Uri(BaseUri, string.Format("api/{0}/{1}", ApiVersion, _path));
            requestUri = requestUri.AddQueryParameter("culture", culture);

            var response = ApiGet(requestUri);
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

            var requestUri = new Uri(BaseUri, string.Format("api/{0}/{1}/{2}/agents", ApiVersion, _path, categoryId));
            var response = ApiGet(requestUri);
            return response.GetObjectFromResponse<List<Agent>>();
        }
        #endregion
    }
}

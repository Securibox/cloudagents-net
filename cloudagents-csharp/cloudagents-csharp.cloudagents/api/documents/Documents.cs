using cloudagents_csharp.cloudagents.api.documents.models;
using cloudagents_csharp.cloudagents.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cloudagents_csharp.cloudagents.api.documents
{
    public class Documents : ApiClient
    {
        private readonly string _path = "documents";
        public Documents()
            : base("v1")
        { }

        #region DOCUMENTS
        /// <summary>
        /// Searches the documents.
        /// </summary>
        /// <param name="customerAccountId">The customer account identifier.</param>
        /// <param name="customerUserId">The customer user identifier.</param>
        /// <param name="pendingOnly">if set to <c>true</c> [pending only].</param>
        /// <param name="includeContent">if set to <c>true</c> [include content].</param>
        /// <returns></returns>
        public List<Document> SearchDocuments(string customerAccountId = null, string customerUserId = null, bool pendingOnly = false, bool includeContent = false)
        {
            var requestUri = new Uri(BaseUri, string.Format("api/{0}/{1}/search", ApiVersion, _path));

            requestUri = requestUri.AddQueryParameter("customerAccountId", customerAccountId);
            requestUri = requestUri.AddQueryParameter("customerUserId", customerUserId);
            requestUri = requestUri.AddQueryParameter("pendingOnly", pendingOnly);
            requestUri = requestUri.AddQueryParameter("includeContent", includeContent);

            var response = ApiGet(requestUri);
            return response.GetObjectFromResponse<List<Document>>();
        }
        /// <summary>
        /// Gets the document.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Document GetDocument(int id, bool includeContent = true)
        {
            var requestUri = new Uri(BaseUri, string.Format("api/{0}/{1}/{2}", ApiVersion, _path, id));
            requestUri = requestUri.AddQueryParameter("includeContent", includeContent);

            var response = ApiGet(requestUri);
            return response.GetObjectFromResponse<Document>();

        }
        /// <summary>
        /// Acknowledges the document delivery.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public bool AcknowledgeDocumentDelivery(int id)
        {
            var requestUri = new Uri(BaseUri, string.Format("api/{0}/{1}/{2}/ack", ApiVersion, _path, id));
            var response = ApiPut(requestUri, Newtonsoft.Json.JsonConvert.SerializeObject(id));
            return response.GetObjectFromResponse<bool>();
        }
        #endregion
    }
}

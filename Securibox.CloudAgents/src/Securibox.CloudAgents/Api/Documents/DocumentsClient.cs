using Securibox.CloudAgents.Api.Documents.Models;
using Securibox.CloudAgents.Core;
using System;
using System.Collections.Generic;

namespace Securibox.CloudAgents.Api.Documents
{
    public class DocumentsClient : ApiObjectClient
    {
        private readonly string _path = "documents";
        private readonly string _apiVersion = "v1";

        public DocumentsClient(AuthClient authenticatedClient):base(authenticatedClient)
        {
        }


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
            var requestUri = new Uri(_authenticatedClient.BaseUri, string.Format("api/{0}/{1}/search", _apiVersion, _path));

            requestUri = requestUri.AddQueryParameter("customerAccountId", customerAccountId);
            requestUri = requestUri.AddQueryParameter("customerUserId", customerUserId);
            requestUri = requestUri.AddQueryParameter("pendingOnly", pendingOnly);
            requestUri = requestUri.AddQueryParameter("includeContent", includeContent);

            var response = _authenticatedClient.HttpClient.ApiGet(requestUri);
            return response.GetObjectFromResponse<List<Document>>();
        }
        /// <summary>
        /// Gets the document.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Document GetDocument(int id, bool includeContent = true)
        {
            var requestUri = new Uri(_authenticatedClient.BaseUri, string.Format("api/{0}/{1}/{2}", _apiVersion, _path, id));
            requestUri = requestUri.AddQueryParameter("includeContent", includeContent);

            var response = _authenticatedClient.HttpClient.ApiGet(requestUri);
            return response.GetObjectFromResponse<Document>();

        }
        /// <summary>
        /// Acknowledges the document delivery.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public bool AcknowledgeDocumentDelivery(int id)
        {
            var requestUri = new Uri(_authenticatedClient.BaseUri, string.Format("api/{0}/{1}/{2}/ack", _apiVersion, _path, id));
            var response = _authenticatedClient.HttpClient.ApiPut(requestUri, Newtonsoft.Json.JsonConvert.SerializeObject(id));
            return response.GetObjectFromResponse<bool>();
        }
        #endregion
    }
}

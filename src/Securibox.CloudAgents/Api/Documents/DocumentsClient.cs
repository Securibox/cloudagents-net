using Securibox.CloudAgents.Api.Documents.Models;
using Securibox.CloudAgents.Core;
using System;
using System.Collections.Generic;

namespace Securibox.CloudAgents.Api.Documents
{
    /// <summary>
    /// Wrapper for the Documents related methods.
    /// </summary>
    public class DocumentsClient : ApiObjectClient
    {
        private readonly string _path = "documents";
        private readonly string _apiVersion = "v1";
        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentsClient"/> class.
        /// </summary>
        /// <param name="authenticatedClient">An authentication client</param>
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
        /// Gets a specific document.
        /// </summary>
        /// <param name="id">The document identifier.</param>
        /// <param name="includeContent">Specifies if the response should include the document content encoded as base 64.</param>
        /// <returns>A Document object</returns>
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
        /// <param name="id">The document identifier.</param>
        /// <param name="refused">Specifies if the document delivery is refused.</param>
        /// <param name="failed">Specifies if the document delivery has failed.</param>
        /// <returns>true if the acknowledgment is successfull, false otherwise.</returns>
        public bool AcknowledgeDocumentDelivery(int id, bool refused = false, bool failed = false)
        {
            if (refused && failed)
                throw new ArgumentException("You cannot refuse and fail a document delivery at the same time.");
            
            var requestUri = new Uri(_authenticatedClient.BaseUri, string.Format("api/{0}/{1}/{2}/ack", _apiVersion, _path, id));
            requestUri = requestUri.AddQueryParameter("refused", refused);
            requestUri = requestUri.AddQueryParameter("failed", failed);
            var response = _authenticatedClient.HttpClient.ApiPut(requestUri, Newtonsoft.Json.JsonConvert.SerializeObject(id));
            return response.GetObjectFromResponse<bool>();
        }
        #endregion
    }
}

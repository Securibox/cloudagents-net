using Securibox.CloudAgents.SDK.Api.Documents;
using Securibox.CloudAgents.SDK.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Securibox.CloudAgents.SDK.Core
{
    public class Client : AuthClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClient"/> class.
        /// </summary>
        public Client() : base() { }

        #region Protected Methods

        internal ApiResponse ApiGet(string requestUri)
        {
            if (string.IsNullOrEmpty(requestUri))
                return null;

            using (HttpResponseMessage response = HttpClient.GetAsync(requestUri).Result)
            {
                return new ApiResponse(response);
            }
        }

        internal ApiResponse ApiGet(Uri requestUri)
        {
            if (requestUri == null)
                return null;

            using (HttpResponseMessage response = HttpClient.GetAsync(requestUri).Result)
            {
                if (response.IsSuccessStatusCode)
                    return new ApiResponse(response);
                throw new ApiClientHttpException((int)response.StatusCode, response.Content.ReadAsStringAsync().Result);
            }
        }

        internal ApiResponse ApiPost(string requestUri, string contentJson)
        {
            if (string.IsNullOrEmpty(requestUri) || string.IsNullOrEmpty(contentJson))
                return null;

            using (var content = new StringContent(contentJson, Encoding.UTF8, "application/json"))
            {
                using (HttpResponseMessage response = HttpClient.PostAsync(requestUri, content).Result)
                {
                    if (response.IsSuccessStatusCode)
                        return new ApiResponse(response);
                    throw new ApiClientHttpException((int)response.StatusCode, response.Content.ReadAsStringAsync().Result);
                }
            }
        }

        internal ApiResponse ApiPost(Uri requestUri, string contentJson)
        {
            if (requestUri == null || string.IsNullOrEmpty(contentJson))
                return null;

            using (var content = new StringContent(contentJson, Encoding.UTF8, "application/json"))
            {
                using (HttpResponseMessage response = HttpClient.PostAsync(requestUri, content).Result)
                {
                    if (response.IsSuccessStatusCode)
                        return new ApiResponse(response);
                    throw new ApiClientHttpException((int)response.StatusCode, response.Content.ReadAsStringAsync().Result);
                }
            }
        }

        internal ApiResponse ApiPut(string requestUri, string contentJson)
        {
            if (string.IsNullOrEmpty(requestUri) || string.IsNullOrEmpty(contentJson))
                return null;

            using (var content = new StringContent(contentJson, Encoding.UTF8, "application/json"))
            {
                using (HttpResponseMessage response = HttpClient.PutAsync(requestUri, content).Result)
                {
                    if (response.IsSuccessStatusCode)
                        return new ApiResponse(response);
                    throw new ApiClientHttpException((int)response.StatusCode, response.Content.ReadAsStringAsync().Result);
                }
            }
        }

        internal ApiResponse ApiPut(Uri requestUri, string contentJson)
        {
            if (requestUri == null || string.IsNullOrEmpty(contentJson))
                return null;

            using (var content = new StringContent(contentJson, Encoding.UTF8, "application/json"))
            {
                using (HttpResponseMessage response = HttpClient.PutAsync(requestUri, content).Result)
                {
                    if (response.IsSuccessStatusCode)
                        return new ApiResponse(response);
                    throw new ApiClientHttpException((int)response.StatusCode, response.Content.ReadAsStringAsync().Result);
                }
            }
        }

        internal ApiResponse ApiDelete(string requestUri)
        {
            if (string.IsNullOrEmpty(requestUri))
                return null;

            using (HttpResponseMessage response = HttpClient.DeleteAsync(requestUri).Result)
            {
                if (response.IsSuccessStatusCode)
                    return new ApiResponse(response);
                throw new ApiClientHttpException((int)response.StatusCode, response.Content.ReadAsStringAsync().Result);
            }
        }

        internal ApiResponse ApiDelete(Uri requestUri)
        {
            if (requestUri == null)
                return null;

            using (HttpResponseMessage response = HttpClient.DeleteAsync(requestUri).Result)
            {
                if (response.IsSuccessStatusCode)
                    return new ApiResponse(response);
                throw new ApiClientHttpException((int)response.StatusCode, response.Content.ReadAsStringAsync().Result);
            }
        }
        #endregion

        #region Public Methods
        public AccountsClient GetAccountsClient()
        {
            return new AccountsClient();
        }

        public AgentsClient GetAgentsClient()
        {
            return new AgentsClient();
        }

        public CategoriesClient GetCategoriesClient()
        {
            return new CategoriesClient();
        }

        public DocumentsClient GetDocumentsClient()
        {
            return new DocumentsClient();
        }

        public SynchronizationsClient GetSynchronizationsClient()
        {
            return new SynchronizationsClient();
        }
        #endregion
    }
}

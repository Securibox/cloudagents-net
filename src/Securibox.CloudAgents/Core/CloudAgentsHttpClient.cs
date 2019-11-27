using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Securibox.CloudAgents.Core
{
    /// <summary>
    /// Class representing an improved HTTP client to communicate with the APIs.
    /// </summary>
    public class CloudAgentsHttpClient : System.Net.Http.HttpClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CloudAgentsHttpClient"/> class.
        /// </summary>
        public CloudAgentsHttpClient() : base() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CloudAgentsHttpClient"/> class.
        /// </summary>
        /// <param name="handler">An HTTP message handler to intercept the requests.</param>
        public CloudAgentsHttpClient(HttpMessageHandler handler) : base(handler) { }
        /// <summary>
        /// Performs an HTTP GET request to specified Uri
        /// </summary>
        /// <param name="requestUri">The Uri in string format to request</param>
        /// <returns>An API response</returns>
        internal ApiResponse ApiGet(string requestUri)
        {
            if (string.IsNullOrEmpty(requestUri))
                return null;

            using (HttpResponseMessage response = this.GetAsync(requestUri).Result)
            {
                if (response.IsSuccessStatusCode)
                    return new ApiResponse(response);
                if ((int)response.StatusCode == 404)
                    return new Core.ApiResponse();
                throw new ApiClientHttpException((int)response.StatusCode, response.Content.ReadAsStringAsync().Result);
            }
        }
        /// <summary>
        /// Performs an HTTP GET request to specified Uri
        /// </summary>
        /// <param name="requestUri">The Uri to request</param>
        /// <returns>An API response</returns>
        internal ApiResponse ApiGet(Uri requestUri)
        {
            if (requestUri == null)
                return null;

            using (HttpResponseMessage response = this.GetAsync(requestUri).Result)
            {
                if (response.IsSuccessStatusCode)
                    return new ApiResponse(response);
                if ((int)response.StatusCode == 404)
                    return new Core.ApiResponse();
                throw new ApiClientHttpException((int)response.StatusCode, response.Content.ReadAsStringAsync().Result);
            }
        }
        /// <summary>
        /// Performs an HTTP POST request to specified Uri
        /// </summary>
        /// <param name="requestUri">The Uri in string format to request</param>
        /// <param name="contentJson">The POST body in JSON format</param>
        /// <returns>An API response</returns>
        internal ApiResponse ApiPost(string requestUri, string contentJson)
        {
            if (string.IsNullOrEmpty(requestUri) || string.IsNullOrEmpty(contentJson))
                return null;

            using (var content = new StringContent(contentJson, Encoding.UTF8, "application/json"))
            {
                using (HttpResponseMessage response = this.PostAsync(requestUri, content).Result)
                {
                    if (response.IsSuccessStatusCode)
                        return new ApiResponse(response);
                    throw new ApiClientHttpException((int)response.StatusCode, response.Content.ReadAsStringAsync().Result);
                }
            }
        }
        /// <summary>
        /// Performs an HTTP POST request to specified Uri
        /// </summary>
        /// <param name="requestUri">The Uri to request</param>
        /// <param name="contentJson">The POST body in JSON format</param>
        /// <returns>An API response</returns>
        internal ApiResponse ApiPost(Uri requestUri, string contentJson)
        {
            if (requestUri == null || string.IsNullOrEmpty(contentJson))
                return null;

            using (var content = new StringContent(contentJson, Encoding.UTF8, "application/json"))
            {
                using (HttpResponseMessage response = this.PostAsync(requestUri, content).Result)
                {
                    if (response.IsSuccessStatusCode)
                        return new ApiResponse(response);
                    throw new ApiClientHttpException((int)response.StatusCode, response.Content.ReadAsStringAsync().Result);
                }
            }
        }
        /// <summary>
        /// Performs an HTTP PUT request to specified Uri
        /// </summary>
        /// <param name="requestUri">The Uri in string format to request</param>
        /// <param name="contentJson">The PUT body in JSON format</param>
        /// <returns>An API response</returns>
        internal ApiResponse ApiPut(string requestUri, string contentJson)
        {
            if (string.IsNullOrEmpty(requestUri) || string.IsNullOrEmpty(contentJson))
                return null;

            using (var content = new StringContent(contentJson, Encoding.UTF8, "application/json"))
            {
                using (HttpResponseMessage response = this.PutAsync(requestUri, content).Result)
                {
                    if (response.IsSuccessStatusCode)
                        return new ApiResponse(response);
                    throw new ApiClientHttpException((int)response.StatusCode, response.Content.ReadAsStringAsync().Result);
                }
            }
        }
        /// <summary>
        /// Performs an HTTP PUT request to specified Uri
        /// </summary>
        /// <param name="requestUri">The Uri</param>
        /// <param name="contentJson">The PUT body in JSON format</param>
        /// <returns>An API response</returns>
        internal ApiResponse ApiPut(Uri requestUri, string contentJson)
        {
            if (requestUri == null || string.IsNullOrEmpty(contentJson))
                return null;

            using (var content = new StringContent(contentJson, Encoding.UTF8, "application/json"))
            {
                using (HttpResponseMessage response = this.PutAsync(requestUri, content).Result)
                {
                    if (response.IsSuccessStatusCode)
                        return new ApiResponse(response);
                    throw new ApiClientHttpException((int)response.StatusCode, response.Content.ReadAsStringAsync().Result);
                }
            }
        }
        /// <summary>
        /// Performs an HTTP DELETE request to specified Uri
        /// </summary>
        /// <param name="requestUri">The Uri in string format to request</param>
        /// <returns>An API response</returns>
        internal ApiResponse ApiDelete(string requestUri)
        {
            if (string.IsNullOrEmpty(requestUri))
                return null;

            using (HttpResponseMessage response = this.DeleteAsync(requestUri).Result)
            {
                if (response.IsSuccessStatusCode)
                    return new ApiResponse(response);
                throw new ApiClientHttpException((int)response.StatusCode, response.Content.ReadAsStringAsync().Result);
            }
        }
        /// <summary>
        /// Performs an HTTP DELETE request to specified Uri
        /// </summary>
        /// <param name="requestUri">The Uri to request</param>
        /// <returns>An API response</returns>
        internal ApiResponse ApiDelete(Uri requestUri)
        {
            if (requestUri == null)
                return null;

            using (HttpResponseMessage response = this.DeleteAsync(requestUri).Result)
            {
                if (response.IsSuccessStatusCode)
                    return new ApiResponse(response);
                throw new ApiClientHttpException((int)response.StatusCode, response.Content.ReadAsStringAsync().Result);
            }
        }
    }
}

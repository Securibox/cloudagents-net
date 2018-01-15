using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Securibox.CloudAgents.Core
{
    public class CloudAgentsHttpClient : System.Net.Http.HttpClient
    {
        public CloudAgentsHttpClient() : base() { }
        public CloudAgentsHttpClient(HttpMessageHandler handler) : base(handler) { }
        internal ApiResponse ApiGet(string requestUri)
        {
            if (string.IsNullOrEmpty(requestUri))
                return null;

            using (HttpResponseMessage response = this.GetAsync(requestUri).Result)
            {
                if (response.IsSuccessStatusCode)
                    return new ApiResponse(response);
                throw new ApiClientHttpException((int)response.StatusCode, response.Content.ReadAsStringAsync().Result);
            }
        }

        internal ApiResponse ApiGet(Uri requestUri)
        {
            if (requestUri == null)
                return null;

            using (HttpResponseMessage response = this.GetAsync(requestUri).Result)
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
                using (HttpResponseMessage response = this.PostAsync(requestUri, content).Result)
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
                using (HttpResponseMessage response = this.PostAsync(requestUri, content).Result)
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
                using (HttpResponseMessage response = this.PutAsync(requestUri, content).Result)
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
                using (HttpResponseMessage response = this.PutAsync(requestUri, content).Result)
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

            using (HttpResponseMessage response = this.DeleteAsync(requestUri).Result)
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

            using (HttpResponseMessage response = this.DeleteAsync(requestUri).Result)
            {
                if (response.IsSuccessStatusCode)
                    return new ApiResponse(response);
                throw new ApiClientHttpException((int)response.StatusCode, response.Content.ReadAsStringAsync().Result);
            }
        }
    }
}

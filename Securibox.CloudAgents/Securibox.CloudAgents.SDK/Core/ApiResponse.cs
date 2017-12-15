using System;
using System.Net;
using System.Net.Http;

namespace Securibox.CloudAgents.SDK.Core
{
    public class ApiResponse : IApiResponse
    {
        #region Private fields
        private string _bodyContent;

        private HttpStatusCode _statusCode;

        private string _responseMessage;
        #endregion

        #region Constructor
        public ApiResponse(HttpResponseMessage response)
        {
            if (response == null)
                throw new ArgumentNullException("response", "Response is missing.");
            
            this._bodyContent = response.Content.ReadAsStringAsync().Result;
            this._responseMessage = response.ReasonPhrase;
            this._statusCode = response.StatusCode;
        }
        #endregion

        public string GetBodyContent()
        {
            return this._bodyContent;
        }

        public string GetResponseMessage()
        {
            return this._responseMessage;
        }

        public HttpStatusCode GetStatusCode()
        {
            return this._statusCode;
        }

        public RType GetObjectFromResponse<RType>()
        {
            if (string.IsNullOrEmpty(this._bodyContent))
                return default(RType);

            return Newtonsoft.Json.JsonConvert.DeserializeObject<RType>(this._bodyContent);
        }
    }
}

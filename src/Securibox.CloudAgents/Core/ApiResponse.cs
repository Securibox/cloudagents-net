using System;
using System.Collections;
using System.Net;
using System.Net.Http;

namespace Securibox.CloudAgents.Core
{
    /// <summary>
    /// Class representing an API response
    /// </summary>
    public class ApiResponse
    {
        #region Private fields
        private string _bodyContent;

        private HttpStatusCode _statusCode;

        private string _responseMessage;
        #endregion

        #region Public field
        /// <summary>
        /// The body's content of the HTTP response.
        /// </summary>
        public string BodyContent
        {
            get
            {
                return _bodyContent;
            }
        }
        /// <summary>
        /// The message parsed from the HTTP response.
        /// </summary>
        public string ResponseMessage
        {
            get
            {
                return this._responseMessage;
            }
        }
        /// <summary>
        /// The <see cref="HttpStatusCode"/> returned by the HTTP response.
        /// </summary>
        public HttpStatusCode StatusCode
        {
            get
            {
                return this._statusCode;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiResponse"/> class.
        /// </summary>
        public ApiResponse() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiResponse"/> class.
        /// </summary>
        /// <param name="response">The HTTP response returned by the API.</param>
        public ApiResponse(HttpResponseMessage response)
        {
            this._bodyContent = response.Content.ReadAsStringAsync().Result;
            this._responseMessage = response.ReasonPhrase;
            this._statusCode = response.StatusCode;
        }
        #endregion

        /// <summary>
        /// Deserializes the response to the correct type.
        /// </summary>
        /// <typeparam name="RType">The expected type</typeparam>
        /// <returns>The deserialized content</returns>
        public RType GetObjectFromResponse<RType>()
        {
            if (string.IsNullOrEmpty(this._bodyContent))
            {
                if (typeof(RType).IsGenericType && typeof(RType).GetGenericTypeDefinition() == typeof(System.Collections.Generic.List<>))
                {
                    return (RType)Activator.CreateInstance(typeof(RType));
                }
                else
                {
                    return default(RType);
                }
            }
            return Newtonsoft.Json.JsonConvert.DeserializeObject<RType>(this._bodyContent);
        }
    }
}

using System;
using System.Web;

namespace Securibox.CloudAgents.Core
{
    /// <summary>
    /// Class representing an API exception
    /// </summary>
    public class ApiClientHttpException : HttpException
    {
        /// <summary>
        /// The error response
        /// </summary>
        public ErrorResponse ErrorResponse { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClientHttpException" /> class.
        /// </summary>
        /// <param name="httpCode">The HTTP code returned by the API</param>
        /// <param name="message">The message returned by the API</param>
        public ApiClientHttpException(int httpCode, string message) : base(httpCode, message)
        {
            try
            {
                this.ErrorResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorResponse>(message);
            }
            catch (Exception)
            {
                this.ErrorResponse = null;
            }
        }
    }
}

using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.Serialization;

namespace Securibox.CloudAgents.Core
{
    /// <summary>
    /// Class representing an API exception
    /// </summary>
    public class ApiClientHttpException : SystemException
    {
        private int _httpCode;
        /// <summary>
        /// The error response
        /// </summary>
        public ErrorResponse ErrorResponse { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClientHttpException" /> class.
        /// </summary>
        /// <param name="httpCode">The HTTP code returned by the API</param>
        /// <param name="message">The message returned by the API</param>
        public ApiClientHttpException(int httpCode, string message) : base(message)
        {
            try
            {
                _httpCode = httpCode;
                this.ErrorResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorResponse>(message);
            }
            catch (Exception)
            {
                this.ErrorResponse = null;
            }
        }

        /// <devdoc>
        ///    <para>Serialize the object.</para>
        /// </devdoc>
        //[SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter=true)] 
        [SuppressMessage("Microsoft.Security", "CA2110:SecureGetObjectDataOverrides", Justification = "Base class has demand")]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("_httpCode", _httpCode);
        }

        /*
 * If we have an Http code (non-zero), return it.  Otherwise, return 
 * the inner exception's code.  If there isn't one, return 500.
 */

        /// <devdoc>
        ///    <para>HTTP return code to send back to client. If there is a 
        ///       non-zero Http code, it is returned. Otherwise, the System.HttpException.innerException
        ///       code is returned. If
        ///       there isn't an inner exception, error code 500 is returned.</para>
        /// </devdoc> 
        public int GetHttpCode()
        {
            return GetHttpCodeForException(this);
        }

        internal static int GetHttpCodeForException(Exception e)
        {

            if (e is ApiClientHttpException)
            {
                ApiClientHttpException he = (ApiClientHttpException)e;

                // If the HttpException specifies an HTTP code, use it 
                if (he._httpCode > 0)
                    return he._httpCode;
            }
            /* 
            404 conversion is done in HttpAplpication.MapHttpHandler

                        else if (e is FileNotFoundException || e is DirectoryNotFoundException) 
                        {
                            code = 404; 
                        }
            */
            else if (e is UnauthorizedAccessException)
            {
                return 401;
            }
            else if (e is PathTooLongException)
            {
                return 414;
            }

            // If there is an inner exception, try to get the code from it
            if (e.InnerException != null)
                return GetHttpCodeForException(e.InnerException);

            // If all else fails, use 500
            return 500;
        }
    }
}

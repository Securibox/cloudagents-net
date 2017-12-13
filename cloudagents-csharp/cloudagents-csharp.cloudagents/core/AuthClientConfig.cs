using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace cloudagents_csharp.cloudagents.core
{
    /// <summary>
    /// AuthConfig class.
    /// </summary>
    public abstract class AuthClientConfig : IDisposable
    {
        /// <summary>
        /// Gets or sets the client.
        /// </summary>
        /// <value>
        /// The client.
        /// </value>
        protected HttpClient _client { get; set; }
        /// <summary>
        /// Gets the HTTP client.
        /// </summary>
        /// <returns></returns>
        internal virtual HttpClient GetHttpClient()
        {
            return _client;
        }
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public abstract void Dispose();
    }
}

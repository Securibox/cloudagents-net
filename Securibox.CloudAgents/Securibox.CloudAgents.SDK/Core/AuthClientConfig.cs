using System;
using System.Net.Http;

namespace Securibox.CloudAgents.SDK.Core
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

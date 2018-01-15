using System;
using System.Net.Http;

namespace Securibox.CloudAgents.Core.AuthConfigs
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
        protected CloudAgentsHttpClient _client { get; set; }
        /// <summary>
        /// Gets the HTTP client.
        /// </summary>
        /// <returns></returns>
        internal virtual CloudAgentsHttpClient GetHttpClient()
        {
            return _client;
        }
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public abstract void Dispose();
    }
}

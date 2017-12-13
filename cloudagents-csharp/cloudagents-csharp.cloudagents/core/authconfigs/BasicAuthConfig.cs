using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace cloudagents_csharp.cloudagents.core.authconfigs
{
    /// <summary>
    /// BasicAuthConfig class.
    /// </summary>
    public sealed class BasicAuthConfig : AuthClientConfig
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BasicAuthConfig"/> class.
        /// </summary>
        /// <param name="baseAddress">The base address.</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        public BasicAuthConfig(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                throw new ArgumentNullException("Invalid credentials");

            var authenticationHeaderBytes = Encoding.ASCII.GetBytes(string.Format("{0}:{1}", username, password));
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authenticationHeaderBytes));
        }
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public override void Dispose()
        {
            _client.Dispose();
        }
    }
}

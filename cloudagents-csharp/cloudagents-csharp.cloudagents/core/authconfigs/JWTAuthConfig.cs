using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Securibox.CloudAgents.SDK.Core.AuthConfigs
{
    public sealed class JWTAuthConfig : AuthClientConfig
    {
        private X509Certificate2 _x509Certificate2 = null;
        private DateTime _tokenExpiration;
        /// <summary>
        /// Initializes a new instance of the <see cref="JWTAuthConfig" /> class.
        /// </summary>
        /// <param name="jwtSecurityToken">The JWT security token.</param>
        /// <exception cref="System.Exception">No certificates were found for the specified subject</exception>
        public JWTAuthConfig(JwtSecurityToken jwtSecurityToken)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            _client = new HttpClient();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", handler.WriteToken(jwtSecurityToken));
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="JWTAuthConfig"/> class.
        /// </summary>
        /// <param name="encodedTokenString">The encoded token string.</param>
        public JWTAuthConfig(string encodedTokenString)
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", encodedTokenString);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="JWTAuthConfig"/> class.
        /// </summary>
        /// <param name="certificate">The certificate.</param>
        public JWTAuthConfig(X509Certificate2 certificate)
        {
            _x509Certificate2 = certificate;  // This property is initialized only here. Otherwise it's null.
            RefreshClient();
        }
        /// <summary>
        /// Refreshes the client. This method runs when the configuration is created from a certificate. If so, 
        /// the client header must be refreshed anytime the token expires.
        /// </summary>
        private void RefreshClient()
        {
            var token = Utils.BuildDefaultToken(_x509Certificate2);
            _tokenExpiration = token.ValidTo;

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            _client = new HttpClient();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", handler.WriteToken(token));

        }
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public override void Dispose()
        {
            _client.Dispose();
        }
        internal override HttpClient GetHttpClient()
        {
            // If a certificate exists and the token is almost expired
            if (_x509Certificate2 != null && _tokenExpiration < DateTime.UtcNow.AddMinutes(1))
                RefreshClient(); // Refresh the client (build a new token).
            return base.GetHttpClient();
        }
    }
}

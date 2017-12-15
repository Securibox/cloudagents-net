using System;
using System.Linq;
using System.Net.Http;
using Securibox.CloudAgents.SDK.Core.AuthConfigs;

namespace Securibox.CloudAgents.SDK.Core
{
    public abstract class AuthClient : IDisposable
    {
        /// <summary>
        /// Gets the HTTP client.
        /// </summary>
        /// <value>
        /// The HTTP client.
        /// </value>
        protected HttpClient HttpClient
        {
            get
            {
                return _authConfig.GetHttpClient();

            }
        }
        /// <summary>
        /// The _auth configuration
        /// </summary>
        private AuthClientConfig _authConfig;
        /// <summary>
        /// The _base URI
        /// </summary>
        private Uri _baseUri;
        public Uri BaseUri
        {
            get
            {
                return _baseUri;
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthClient"/> class.
        /// </summary>
        /// <param name="baseAddress">The base address.</param>
        /// <param name="authConfig">The authentication configuration.</param>
        public AuthClient(string baseAddress, AuthClientConfig authConfig)
        {
            if (string.IsNullOrEmpty(baseAddress))
                throw new ArgumentNullException("Invalid base address.");
            if (authConfig == null)
                throw new ArgumentNullException("Invalid AuthClientConfig.");
            _authConfig = authConfig;
            _baseUri = new Uri(baseAddress.EndsWith("/") ? baseAddress : baseAddress + "/");
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthClient"/> class.
        /// </summary>
        /// <param name="baseUri">The base URI.</param>
        /// <param name="authConfig">The authentication configuration.</param>
        public AuthClient(Uri baseUri, AuthClientConfig authConfig)
        {
            if (baseUri == null)
                throw new ArgumentNullException("Invalid base uri.");
            if (authConfig == null)
                throw new ArgumentNullException("Invalid AuthClientConfig.");

            _authConfig = authConfig;
            _baseUri = baseUri;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthClient"/> class.
        /// authParameters[0] - basic or cert or jwt or ...
        /// authParameters[1] - baseAddress
        /// authParameters[2] - username or certThumbprint or encodedTokenString or ...
        /// authParameters[3] - password or ...
        /// ...
        /// </summary>
        /// <param name="authParameters">The authentication parameters.</param>
        /// <exception cref="System.Exception">Invalid configurations: basic or cert or jwt auth only are accepted.</exception>
        public AuthClient(params string[] authParameters)
        {
            if (authParameters != null && authParameters.Length > 0)
            {
                if (authParameters.Any(s => string.IsNullOrEmpty(s)))
                    throw new Exception("Invalid configurations: all the arguments must be not null and not empty");
                if (authParameters.Length < 3)
                    throw new Exception("Invalid configurations: all configurations needs at least 3 arguments");

                _baseUri = new Uri(authParameters[1].EndsWith("/") ? authParameters[1] : authParameters[1] + "/");

                switch (authParameters[0])
                {
                    case "basic":
                        if (authParameters.Length < 4)
                            throw new Exception("Invalid configurations: basic configuration needs at least 3 arguments");

                        _authConfig = new BasicAuthConfig(authParameters[2], authParameters[3]);
                        break;
                    case "cert":
                        _authConfig = new CertAuthConfig(authParameters[2]);
                        break;
                    case "jwt":
                        _authConfig = new JWTAuthConfig(authParameters[2]);
                        break;
                    default:
                        throw new Exception("Invalid configurations: basic or cert or jwt auth only are accepted.");
                }
            }
            else
            {
                var baseAddress = AuthClientConfiguration.Current.BaseAddress;
                if (string.IsNullOrEmpty(baseAddress))
                    throw new NullReferenceException("BaseAddress is null or empty.");
                _baseUri = new Uri(baseAddress.EndsWith("/") ? baseAddress : baseAddress + "/");

                if (AuthClientConfiguration.Current.AuthMode == "basic")
                {
                    _authConfig = new BasicAuthConfig(AuthClientConfiguration.Current.Username, AuthClientConfiguration.Current.Password);
                }
                else if (AuthClientConfiguration.Current.AuthMode == "cert")
                {
                    _authConfig = new CertAuthConfig(AuthClientConfiguration.Current.CertThumbprint);
                }
                else if (AuthClientConfiguration.Current.AuthMode == "jwt")
                {
                    var tokenString = AuthClientConfiguration.Current.EncodedTokenString;
                    if (!string.IsNullOrEmpty(tokenString))
                    {
                        _authConfig = new JWTAuthConfig(tokenString);
                    }
                    else
                    {
                        var certThumbprint = AuthClientConfiguration.Current.CertThumbprint;
                        if (string.IsNullOrEmpty(certThumbprint))
                            throw new Exception("Invalid configurations: either certThumbprint or encodedTokenString must be provided for jwt authentication.");
                        var cert = Utils.GetCertificate(certThumbprint);
                        _authConfig = new JWTAuthConfig(cert);
                    }
                }
                else
                    throw new Exception("Invalid configurations: basic, cert or jwt auth only are accepted.");
            }
        }
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _authConfig.Dispose();
        }
    }
}

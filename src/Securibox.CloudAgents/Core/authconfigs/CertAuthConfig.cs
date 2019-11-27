using System;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;

namespace Securibox.CloudAgents.Core.AuthConfigs
{
    /// <summary>
    /// Class representing the client certificate authentication client.
    /// </summary>
    public sealed class CertAuthConfig : AuthClientConfig
    {
        /// <summary>
        /// The _handler
        /// </summary>
#if NET452
        
        private WebRequestHandler _handler;
#else

        private HttpClientHandler _handler;
#endif


        private CertAuthConfig(X509Certificate2 certificate)
        {
            if (certificate == null)
                throw new ArgumentException("invalid certificate", "certificate");
#if NET452
        
            _handler = new WebRequestHandler();
#else

            _handler = new HttpClientHandler();
#endif


            _handler.ClientCertificates.Add(certificate);
            _client = new CloudAgentsHttpClient(_handler);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CertAuthConfig"/> class.
        /// </summary>
        /// <param name="certificateThumbprint">The certificate thumbprint.</param>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">No certificates were found for the specified thumbprint</exception>
        public CertAuthConfig(string certificateThumbprint) : this(Utils.GetCertificate(certificateThumbprint))
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="CertAuthConfig"/> class.
        /// </summary>
        /// <param name="certificateContent">The certificate byte array.</param>
        public CertAuthConfig(byte[] certificateContent) : this(new X509Certificate2(certificateContent))
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="CertAuthConfig" /> class.
        /// </summary>
        /// <param name="certificateContent">The certificate byte array.</param>
        /// <param name="password">The private key password.</param>
        public CertAuthConfig(byte[] certificateContent, string password) : this(new X509Certificate2(certificateContent, password))
        {
        }
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public override void Dispose()
        {
            _handler.Dispose();
            _client.Dispose();
        }
    }
}

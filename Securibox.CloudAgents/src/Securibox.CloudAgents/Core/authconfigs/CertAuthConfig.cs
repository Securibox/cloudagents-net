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
        private WebRequestHandler _handler;
        /// <summary>
        /// Initializes a new instance of the <see cref="CertAuthConfig"/> class.
        /// </summary>
        /// <param name="certificateThumbprint">The certificate thumbprint.</param>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">No certificates were found for the specified thumbprint</exception>
        public CertAuthConfig(string certificateThumbprint)
        {
            X509Certificate2 certificate = Utils.GetCertificate(certificateThumbprint);
            _handler = new WebRequestHandler();
            _handler.ClientCertificates.Add(certificate);
            _client = new CloudAgentsHttpClient(_handler);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="CertAuthConfig"/> class.
        /// </summary>
        /// <param name="certificateContent">The certificate byte array.</param>
        public CertAuthConfig(byte[] certificateContent)
        {
            var certificate = new X509Certificate2(certificateContent);
            _handler = new WebRequestHandler();
            _handler.ClientCertificates.Add(certificate);
            _client = new CloudAgentsHttpClient(_handler);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="CertAuthConfig" /> class.
        /// </summary>
        /// <param name="certificateContent">The certificate byte array.</param>
        /// <param name="password">The private key password.</param>
        public CertAuthConfig(byte[] certificateContent, string password)
        {
            var certificate = new X509Certificate2(certificateContent, password);
            _handler = new WebRequestHandler();
            _handler.ClientCertificates.Add(certificate);
            _client = new CloudAgentsHttpClient(_handler);
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

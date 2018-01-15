using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Web;
using Microsoft.IdentityModel.Tokens;

namespace Securibox.CloudAgents.Core
{
    public static class Utils
    {
        public static X509Certificate2 GetCertificate(string certThumbprint)
        {
            X509Store store = new X509Store("My", StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);

            X509Certificate2Collection x509Certificates = store.Certificates.Find(X509FindType.FindByThumbprint, certThumbprint, false);
            if (x509Certificates.Count == 0)
            {
                // If nothing can be found as current user, use the LocalMachine certificate store.
                store = new X509Store("My", StoreLocation.LocalMachine);
                store.Open(OpenFlags.ReadOnly);
                x509Certificates = store.Certificates.Find(X509FindType.FindByThumbprint, certThumbprint, false);
            }
            if (x509Certificates.Count == 0)
                throw new Exception(string.Format("Certificate with thumbprint {0} was not found in the current user or local machine personal stores.", certThumbprint));

            return x509Certificates[0];
        }

        public static JwtSecurityToken BuildDefaultToken(X509Certificate2 x509Certificate2)
        {
            var iss = x509Certificate2.Issuer;
            var nbf = DateTime.UtcNow.AddMinutes(-1);
            //var exp = DateTime.UtcNow.AddSeconds(20);
            var exp = DateTime.UtcNow.AddMinutes(5);
            var aud = "Default Securibox JWT Server";

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("sub", x509Certificate2.Subject));
            claims.Add(new Claim("jti", Guid.NewGuid().ToString("D")));

            //X509SigningCredentials credentials = new X509SigningCredentials(x509Certificate2, SecurityAlgorithms.RsaSha256Signature, SecurityAlgorithms.Sha256Digest);
            Microsoft.IdentityModel.Tokens.SigningCredentials credentials =
                new Microsoft.IdentityModel.Tokens.SigningCredentials(new Microsoft.IdentityModel.Tokens.X509SecurityKey(x509Certificate2), SecurityAlgorithms.RsaSha256Signature);
            var header = new JwtHeader(credentials);
            var payload = new JwtPayload(issuer: iss, audience: aud, claims: claims, notBefore: nbf, expires: exp);
            return new JwtSecurityToken(header, payload);
        }

        public static Uri AddQueryParameter(this Uri url, string paramName, object paramValue)
        {
            if (paramValue != null)
            {
                var uriBuilder = new UriBuilder(url);
                var query = HttpUtility.ParseQueryString(uriBuilder.Query);
                query[paramName] = paramValue is string ? paramValue as string : paramValue.ToString();
                uriBuilder.Query = query.ToString();
                return new Uri(uriBuilder.ToString());
            }
            return url;

        }
    }
}

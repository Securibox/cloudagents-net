using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Securibox.CloudAgents.SDK.Core
{
    /// <summary>
    /// AuthClientConfiguration class.
    /// </summary>
    public class AuthClientConfiguration : ConfigurationSection
    {
        /// <summary>
        /// The section name
        /// </summary>
        public static string SectionName
        {
            get
            {
                return typeof(AuthClientConfiguration).Name;
            }
        }
        /// <summary>
        /// The _current
        /// </summary>
        private static AuthClientConfiguration _current;
        /// <summary>
        /// Gets the current.
        /// </summary>
        /// <value>
        /// The current.
        /// </value>
        /// <exception cref="System.Exception">Missing ' + SectionName + ' section in  + AppDomain.CurrentDomain.SetupInformation.ConfigurationFile</exception>
        public static AuthClientConfiguration Current
        {
            get
            {
                if (_current == null)
                {
                    _current = ConfigurationManager.GetSection(SectionName) as AuthClientConfiguration;
                    if (_current == null)
                        throw new Exception("Missing '" + SectionName + "' section in " + AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
                }
                return _current;
            }
        }
        /// <summary>
        /// Gets or sets the authentication mode.
        /// </summary>
        /// <value>
        /// The authentication mode.
        /// </value>
        [ConfigurationProperty("authMode", DefaultValue = null, IsRequired = true)]
        public string AuthMode
        {
            get
            {
                return ((string)this["authMode"]).ToLower();
            }
            set
            {
                this["authMode"] = value;
            }
        }
        /// <summary>
        /// Gets or sets the base address.
        /// </summary>
        /// <value>
        /// The base address.
        /// </value>
        [ConfigurationProperty("baseAddress", DefaultValue = null, IsRequired = true)]
        public string BaseAddress
        {
            get
            {
                return ((string)this["baseAddress"]).ToLower();
            }
            set
            {
                this["baseAddress"] = value;
            }
        }
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        [ConfigurationProperty("username", DefaultValue = null, IsRequired = false)]
        public string Username
        {
            get
            {
                return (string)this["username"];

            }
            set
            {
                this["username"] = value;
            }
        }
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [ConfigurationProperty("password", DefaultValue = null, IsRequired = false)]
        public string Password
        {
            get
            {
                return (string)this["password"];
            }
            set
            {
                this["password"] = value;
            }
        }
        /// <summary>
        /// Gets or sets the name of the cert.
        /// </summary>
        /// <value>
        /// The name of the cert.
        /// </value>
        [ConfigurationProperty("certThumbprint", DefaultValue = null, IsRequired = false)]
        public string CertThumbprint
        {
            get
            {
                return (string)this["certThumbprint"];
            }
            set
            {
                this["certThumbprint"] = value;
            }
        }
        /// <summary>
        /// Gets or sets the encoded token string.
        /// </summary>
        /// <value>
        /// The encoded token string.
        /// </value>
        [ConfigurationProperty("encodedTokenString", DefaultValue = null, IsRequired = false)]
        public string EncodedTokenString
        {
            get
            {
                return (string)this["encodedTokenString"];
            }
            set
            {
                this["encodedTokenString"] = value;
            }
        }
    }
}

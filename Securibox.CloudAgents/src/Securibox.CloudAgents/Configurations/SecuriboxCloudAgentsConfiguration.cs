using System;
using System.Configuration;

namespace Securibox.CloudAgents.Configurations
{
    /// <summary>
    /// Class representing the Cloud Agents configuration in the configuration file.
    /// </summary>
    public class SecuriboxCloudAgentsConfiguration : ConfigurationSection
    {
        /// <summary>
        /// The configuration section name
        /// </summary>
        public static string SectionName
        {
            get
            {
                return typeof(SecuriboxCloudAgentsConfiguration).Name;
            }
        }
        /// <summary>
        /// The _current
        /// </summary>
        private static SecuriboxCloudAgentsConfiguration _current;
        /// <summary>
        /// Gets the current.
        /// </summary>
        /// <value>
        /// The current.
        /// </value>
        /// <exception cref="System.Exception">Missing ' + SectionName + ' section in  + AppDomain.CurrentDomain.SetupInformation.ConfigurationFile</exception>
        public static SecuriboxCloudAgentsConfiguration Current
        {
            get
            {
                if (_current == null)
                {
                    _current = ConfigurationManager.GetSection(SectionName) as SecuriboxCloudAgentsConfiguration;
                    if (_current == null)
                        throw new Exception("Missing '" + SectionName + "' section in " + AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
                }
                return _current;
            }
        }
        /// <summary>
        /// Gets or sets the authentication mode (basic, cert or jwt).
        /// </summary>
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
        /// Gets or sets the base address of the Cloud Agents platform.
        /// </summary>
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
        /// Gets or sets the basic username.
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
        /// Gets or sets the basic password.
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
        /// Gets or sets the certificate thumbprint
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

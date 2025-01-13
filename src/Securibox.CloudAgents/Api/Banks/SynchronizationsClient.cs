using Securibox.CloudAgents.Api.Banks.Models;
using Securibox.CloudAgents.Core;
using System;

namespace Securibox.CloudAgents.Api.Banks
{
    /// <summary>
    /// Wrapper for the Synchronizations related methods.
    /// </summary>
    [Obsolete("This class is deprecated.")]
    public class SynchronizationsClient : ApiObjectClient
    {
        private readonly string _path = "synchronizations";
        private readonly string _apiVersion = "v1";
        /// <summary>
        /// Initializes a new instance of the <see cref="SynchronizationsClient"/> class.
        /// </summary>
        /// <param name="authenticatedClient">An authentication client</param>
        public SynchronizationsClient(AuthClient authenticatedClient) : base(authenticatedClient)
        {
        }

        #region SYNCHRONIZATIONS Methods
        /// <summary>
        /// Launches a new synchronizations to download documents.
        /// </summary>
        /// <param name="customerAccountId">The customer account identifier</param>
        /// <param name="customerUserId">The customer user identifier</param>
        /// <param name="isForced">If true, sets the synchronization as forced, thus overriding the document unicity check.</param>
        /// <returns></returns>
        public Synchronization CreateSynchronizations(string customerAccountId, string customerUserId, bool isForced)
        {
            var requestUri = new Uri(_authenticatedClient.BaseUri, string.Format("api/{0}/{1}", _apiVersion, _path));

            var synchRequest = new SynchronizationRequest(customerAccountId, isForced, customerUserId);
            var response = _authenticatedClient.HttpClient.ApiPost(requestUri, Newtonsoft.Json.JsonConvert.SerializeObject(synchRequest));

            return response.GetObjectFromResponse<Synchronization>();
        }
        #endregion

        /// <summary>
        /// SynchronizationRequest class
        /// </summary>
        private class SynchronizationRequest
        {
            /// <summary>
            /// Gets or sets the customer account identifier.
            /// </summary>
            /// <value>
            /// The customer account identifier.
            /// </value>
            private string CustomerAccountId { get; set; }
            /// <summary>
            /// Gets or sets the customer user identifier.
            /// </summary>
            /// <value>
            /// The customer user identifier.
            /// </value>
            private string CustomerUserId { get; set; }
            /// <summary>
            /// Gets or sets a value indicating whether this <see cref="SynchronizationRequest" /> is forced.
            /// </summary>
            /// <value>
            ///   <c>true</c> if forced; otherwise, <c>false</c>.
            /// </value>
            private bool IsForced { get; set; }

            public SynchronizationRequest(string customerAccountId, bool isForced, string customerUserId)
            {
                this.CustomerUserId = customerUserId;
                this.CustomerAccountId = customerAccountId;
                this.IsForced = isForced;
            }
        }
    }
}

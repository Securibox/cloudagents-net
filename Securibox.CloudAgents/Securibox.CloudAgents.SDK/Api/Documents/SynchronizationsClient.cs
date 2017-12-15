using Securibox.CloudAgents.SDK.Api.Documents.Models;
using Securibox.CloudAgents.SDK.Core;
using System;
using System.Collections.Generic;

namespace Securibox.CloudAgents.SDK.Api.Documents
{
    public class SynchronizationsClient
    {
        private readonly string _path = "synchronizations";
        private readonly string _apiVersion = "v1";

        private Client _client;
        protected Client Client
        {
            get
            {
                if (_client == null)
                    _client = ApiClient.GetClient();
                return _client;
            }
        }

        #region SYNCHRONIZATIONS Methods
        /// <summary>
        /// Creates the synchronizations.
        /// </summary>
        /// <param name="synchronizeRequest">The synchronize.</param>
        /// <returns></returns>
        public List<Synchronization> CreateSynchronizations(string customerAccountId, string customerUserId, bool isForced)
        {
            var requestUri = new Uri(Client.BaseUri, string.Format("api/{0}/{1}", _apiVersion, _path));

            var synchRequest = new SynchronizationRequest(customerAccountId, isForced, customerUserId);
            var response = Client.ApiPost(requestUri, Newtonsoft.Json.JsonConvert.SerializeObject(synchRequest));

            return response.GetObjectFromResponse<List<Synchronization>>();
        }

        /// <summary>
        /// Searches the synchronizations.
        /// </summary>
        /// <param name="customerAccountId">The customer account identifier.</param>
        /// <param name="customerUserId">The customer user identifier.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns></returns>
        public List<Synchronization> SearchSynchronizations(string customerAccountId = null, string customerUserId = null, DateTime? startDate = null, DateTime? endDate = null)
        {
            var requestUri = new Uri(Client.BaseUri, string.Format("api/{0}/{1}/search", _apiVersion, _path));

            string startDateString = null;
            string endDateString = null;

            if (startDate != null)
                startDateString = Uri.EscapeDataString(startDate.Value.ToUniversalTime().ToString("u"));

            if (endDate != null)
                endDateString = Uri.EscapeDataString(endDate.Value.ToUniversalTime().ToString("u"));

            requestUri = requestUri.AddQueryParameter("startDate", startDateString);
            requestUri = requestUri.AddQueryParameter("endDate", endDateString);
            requestUri = requestUri.AddQueryParameter("customerAccountId", customerAccountId);
            requestUri = requestUri.AddQueryParameter("customerUserId", customerUserId);

            var response = Client.ApiGet(requestUri);
            return response.GetObjectFromResponse<List<Synchronization>>();
        }
        /// <summary>
        /// Acknowledges the synchronization delivery.
        /// </summary>
        /// <param name="customerAccountId">The customer account identifier.</param>
        /// <param name="documentIds">The ids of all the documents retrieved during the synchronization, as listed in the synchronization report.</param>
        /// <param name="missingDocumentIds">The ids of the documents not received.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">No customerAccountId was specified.
        /// or
        /// No deliveredDocumentIds was specified.
        /// or
        /// No missingDocumentIds was specified.</exception>
        public bool AcknowledgeSynchronizationDelivery(string customerAccountId, int[] documentIds, int[] missingDocumentIds)
        {
            if (string.IsNullOrEmpty(customerAccountId))
                throw new ApiClientHttpException((int)System.Net.HttpStatusCode.BadRequest, "No customerAccountId was specified.");

            if (documentIds == null)
                throw new ApiClientHttpException((int)System.Net.HttpStatusCode.BadRequest, "No document Ids were specified.");

            if (missingDocumentIds == null)
                throw new ApiClientHttpException((int)System.Net.HttpStatusCode.BadRequest, "No missing document Ids were specified.");

            var synchronizationAcknowledment = new SynchronizationAcknowledgement(customerAccountId, documentIds, missingDocumentIds);

            var requestUri = new Uri(Client.BaseUri, string.Format("api/{0}/{1}/{2}/ack", _apiVersion, _path, customerAccountId));

            var response = Client.ApiPut(requestUri, Newtonsoft.Json.JsonConvert.SerializeObject(synchronizationAcknowledment));
            return response.GetObjectFromResponse<bool>();
        }
        #endregion

        #region Private Api Classes
        /// <summary>
        /// SynchronizationAcknowledment class
        /// </summary>
        private class SynchronizationAcknowledgement
        {
            /// <summary>
            /// Gets or sets the customer account identifier.
            /// </summary>
            /// <value>
            /// The customer account identifier.
            /// </value>
            private string CustomerAccountId { get; set; }
            /// <summary>
            /// Gets or sets the delivered document ids.
            /// </summary>
            /// <value>
            /// The delivered document ids.
            /// </value>
            private int[] DocumentIds { get; set; }
            /// <summary>
            /// Gets or sets the missing document ids.
            /// </summary>
            /// <value>
            /// The missing document ids.
            /// </value>
            private int[] MissingDocumentIds { get; set; }

            public SynchronizationAcknowledgement(string customerAccountId, int[] documentIds, int[] missingDocumentIds)
            {
                this.CustomerAccountId = customerAccountId;
                this.DocumentIds = documentIds;
                this.MissingDocumentIds = missingDocumentIds;
            }
        }
        #endregion
    }
}


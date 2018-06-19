using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Securibox.CloudAgents.Api.Documents.Models
{
    public class AdditionalAuthRequest
    {
        /// <summary>
        /// Customer account identifier
        /// </summary>
        public string CustomerAccountId { get; set; }
        /// <summary>
        /// The secret code for multi factor authentication
        /// </summary>
        public string SbxSecretCode { get; set; }
        /// <summary>
        /// Initializes the AdditionalAuthRequest class.
        /// </summary>
        /// <param name="customerAccountId"></param>
        /// <param name="sbxSecretCode"></param>
        public AdditionalAuthRequest(string customerAccountId, string sbxSecretCode)
        {
            this.CustomerAccountId = customerAccountId;
            this.SbxSecretCode = sbxSecretCode;
        }
    }
}

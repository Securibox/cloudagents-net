using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Securibox.CloudAgents.Api.Documents.Models
{
    public class AdditionalAuthData
    {
        public string AdditionalAuthenticationType { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Message { get; set; }
    }
}

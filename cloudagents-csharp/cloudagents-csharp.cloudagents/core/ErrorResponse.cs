using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Securibox.CloudAgents.SDK.Core
{
    public class ErrorResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }
    }
}

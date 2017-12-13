using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cloudagents_csharp.cloudAgents.core
{
    public interface IApiResponse
    {
        string GetBodyContent();
        System.Net.HttpStatusCode GetStatusCode();
        string GetResponseMessage();
    }
}

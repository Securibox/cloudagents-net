using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Securibox.CloudAgents.SDK.Core
{
    public interface IApiResponse
    {
        string GetBodyContent();
        System.Net.HttpStatusCode GetStatusCode();
        string GetResponseMessage();
    }
}

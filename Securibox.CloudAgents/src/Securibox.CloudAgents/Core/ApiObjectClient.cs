using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Securibox.CloudAgents.Core
{
    public abstract class ApiObjectClient
    {
        protected AuthClient _authenticatedClient;

        public ApiObjectClient(AuthClient authenticatedClient)
        {
            _authenticatedClient = authenticatedClient;
        }
    }
}

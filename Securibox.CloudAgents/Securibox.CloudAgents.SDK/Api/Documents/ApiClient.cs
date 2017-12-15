using Securibox.CloudAgents.SDK.Core;

namespace Securibox.CloudAgents.SDK.Api.Documents
{
    public static class ApiClient
    {
        private static Client _client;

        public static Client GetClient()
        {
            if (_client == null)
                _client = new Client();
            return _client;
        }

        public static AccountsClient GetAccountsClient()
        {
            return new AccountsClient();
        }
        public static AgentsClient GetAgentsClient()
        {
            return new AgentsClient();
        }
        public static DocumentsClient GetDocumentsClient()
        {
            return new DocumentsClient();
        }
        public static CategoriesClient GetCategoriesClient()
        {
            return new CategoriesClient();
        }
        public static SynchronizationsClient GetSynchronizationsClient()
        {
            return new SynchronizationsClient();
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Securibox.CloudAgents.Api.Documents;
using System.Collections.Generic;
using Securibox.CloudAgents.Api.Documents.Models;
using Securibox.CloudAgents.Core;
using Securibox.CloudAgents.Core.AuthConfigs;
using Securibox.CloudAgents.Test;
using System;

namespace Securibox.CloudAgents.Test.Documents
{
    [TestClass]
    public class BasicAuthenticationTests
    {
        private ApiClient _apiClient;

        public BasicAuthenticationTests()
        {
            BasicAuthConfig basicAuthConfig = new BasicAuthConfig("[BasicUsername]", "[BasicPassword]");
            _apiClient = new ApiClient();
        }

        [TestMethod]
        public void GetAgentsListTest()
        {
            var agents = _apiClient.AgentsClient.ListAgents();
            Assert.IsTrue(agents != null && agents.Count > 0);
        }

        [TestMethod]
        public void SearchAgentsTest()
        {
            var agents = _apiClient.AgentsClient.SearchAgent(AgentCountryCode.FR);
            Assert.IsTrue(agents != null && agents.Count > 0);
            agents = _apiClient.AgentsClient.SearchAgent(null, "fr-FR");
            Assert.IsTrue(agents != null && agents.Count > 0);
            agents = _apiClient.AgentsClient.SearchAgent(null, null, false, "Amazon");
            Assert.IsTrue(agents != null && agents.Count > 0);
            agents = _apiClient.AgentsClient.SearchAgent(null, null, false, "Non-existant agent name");
            Assert.IsTrue(agents == null || agents.Count == 0);
        }

        [TestMethod]
        public void GetCategoriesListTest()
        {
            var categories = _apiClient.CategoriesClient.ListCategories();
            Assert.IsTrue(categories != null && categories.Count > 0);
        }

        [TestMethod]
        public void GetCategoriesAndListAgentsByCategoryTest()
        {
            var categories = _apiClient.CategoriesClient.ListCategories();
            Assert.IsTrue(categories != null && categories.Count > 0);
            foreach (var category in categories)
            {
                var agents = _apiClient.CategoriesClient.ListAgentsByCategory(category.Id);
                Assert.IsNotNull(agents); // Maybe there's a category with no agents so we just test if the result is null or not
            }
        }

        [TestMethod]
        public void CreateAccountAndSynchronizeTest()
        {
            var credentials = new List<Credential>
                {
                    new Credential {Position = 0, Value = Constants.AgentUsername, Alg = null },
                    new Credential { Position = 1, Value = Constants.AgentPassword, Alg = null }
                };

            var apiAccount = new Account
            {
                AgentId = Constants.AgentId,
                CustomerAccountId = Constants.CustomerAccountId,
                CustomerUserId = Constants.CustomerUserId,
                Mode = "Enabled",
                Name = "Account 1 - User defined name",
                Credentials = credentials
            };

            var account = _apiClient.AccountsClient.CreateAccount(apiAccount, false);
            var synchronization = _apiClient.AccountsClient.SynchronizeAccount(account.CustomerAccountId, true);
            while (synchronization.SynchronizationStateDetails == SynchronizationStateDetails.NewAccount ||
                    synchronization.SynchronizationStateDetails == SynchronizationStateDetails.Scheduled ||
                   synchronization.SynchronizationStateDetails == SynchronizationStateDetails.Pending ||
                   synchronization.SynchronizationStateDetails == SynchronizationStateDetails.InProgress)
            {
                System.Threading.Thread.Sleep(5000);
                synchronization = _apiClient.AccountsClient.GetLastSynchronizationsOfAccount(account.CustomerAccountId);
            }

            Assert.IsTrue(synchronization.SynchronizationStateDetails == SynchronizationStateDetails.Completed ||
                            synchronization.SynchronizationStateDetails == SynchronizationStateDetails.CompletedNothingNewToDownload);
        }
        [TestMethod]
        public void DownloadDocument()
        {
            var documents = _apiClient.DocumentsClient.SearchDocuments(Constants.CustomerAccountId);
            foreach(var document in documents)
            {
                byte[] documentContent = Convert.FromBase64String(document.Base64Content);
                System.IO.File.WriteAllBytes(@"C:\Temp\" + document.Name, documentContent);
                _apiClient.DocumentsClient.AcknowledgeDocumentDelivery(document.Id);
            }
            
        }

        [TestMethod]
        public void DeleteAccountTest()
        {
            _apiClient.AccountsClient.DeleteAccount(Constants.CustomerAccountId);

        }

    }
}

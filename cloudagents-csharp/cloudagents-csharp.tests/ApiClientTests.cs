using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Securibox.CloudAgents.SDK.Api.Documents;
using System.Collections.Generic;
using Securibox.CloudAgents.SDK.Api.Documents.Models;

namespace cloudagents_csharp.tests
{
    [TestClass]
    public class ApiClientTests
    {
        [TestMethod]
        public void GetAgentsListTest()
        {
            using (var agentsClient = new AgentsClient())
            {
                var agents = agentsClient.ListAgents();
                Assert.IsTrue(agents != null && agents.Count > 0);
            }
        }

        [TestMethod]
        public void SearchAgentsTest()
        {
            using (var agentsClient = new AgentsClient())
            {
                var agents = agentsClient.SearchAgent(AgentCountryCode.FR);
                Assert.IsTrue(agents != null && agents.Count > 0);
                agents = agentsClient.SearchAgent(null, "fr-FR");
                Assert.IsTrue(agents != null && agents.Count > 0);
                agents = agentsClient.SearchAgent(null, null, false, "Amazon");
                Assert.IsTrue(agents != null && agents.Count > 0);
                agents = agentsClient.SearchAgent(null, null, false, "Non-existant agent name");
                Assert.IsTrue(agents == null || agents.Count == 0);
            }
        }

        [TestMethod]
        public void GetCategoriesListTest()
        {
            using (var categoriesClient = new CategoriesClient())
            {
                var categories = categoriesClient.ListCategories();
                Assert.IsTrue(categories != null && categories.Count > 0);
            }
        }

        [TestMethod]
        public void GetCategoriesAndListAgentsByCategoryTest()
        {
            using (var categoriesClient = new CategoriesClient())
            {
                var categories = categoriesClient.ListCategories();
                Assert.IsTrue(categories != null && categories.Count > 0);
                foreach (var category in categories)
                {
                    var agents = categoriesClient.ListAgentsByCategory(category.Id);
                    Assert.IsNotNull(agents); // Maybe there's a category with no agents so we just test if the result is null or not
                }
            }
        }

        [TestMethod]
        public void CreateAccountAndSynchronizeTest()
        {
            using (var accountsClient = new AccountsClient())
            {
                var credentials = new List<Credential>
                {
                    new Credential {Position = 0, Value = "sgavdsilva@gmail.com", Alg = null },
                    new Credential { Position = 1, Value = "Password12$", Alg = null }
                };

                var apiAccount = new Account
                {
                    AgentId = "B4464D56-8126-4196-A1BB-E2BCB8274C27",
                    CustomerAccountId = "CloudAgent_CSharp_EvianChezVous",
                    CustomerUserId = "TEST_CloudAgent_CSharp",
                    Mode = "Enabled",
                    Name = "TEST_Account_EvianChezVous",
                    Credentials = credentials
                };

                var account = accountsClient.CreateAccount(apiAccount, false);
                var synchronization = accountsClient.SynchronizeAccount(account.CustomerAccountId, true);
            }
        }

        [TestMethod]
        public void DeleteAccountTest()
        {
            var accountsClient = new AccountsClient();
            accountsClient.DeleteAccount("CloudAgent_CSharp_EvianChezVous");

        }
    }
}

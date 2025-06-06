using NUnit.Framework;
using Securibox.CloudAgents.Api.Documents;
using Securibox.CloudAgents.Api.Documents.Models;
using Securibox.CloudAgents.Core.AuthConfigs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Securibox.CloudAgents.Tests.Net47.Documents
{
    public class CertificateClientTests
    {
        private ApiClient _apiClient;

        public CertificateClientTests()
        {
            CertAuthConfig authConfig = new CertAuthConfig("[CertificateThumbprint]");
            _apiClient = new ApiClient("http://localhost:8080", authConfig);
        }

        [Test, Order(0001), NonParallelizable]
        public void Test_0001_GetNonExistingAgentByIdTest()
        {
            var agent = _apiClient.AgentsClient.GetAgentByIdentifier("11c1076a4554403786058c5a07a4a973");
            Assert.That(agent == null);
        }

        [Test, Order(0010), NonParallelizable]
        public void Test_0010_GetAgentsListTest()
        {
            var agents = _apiClient.AgentsClient.ListAgents();
            Assert.That(agents != null && agents.Count > 0);
        }

        [Test, Order(0020), NonParallelizable]
        public void Test_0020_SearchAgentsTest()
        {
            var agents = _apiClient.AgentsClient.SearchAgent(AgentCountryCode.FR);
            Assert.That(agents != null && agents.Count > 0);
            agents = _apiClient.AgentsClient.SearchAgent(null, "fr-FR");
            Assert.That(agents != null && agents.Count > 0);
            agents = _apiClient.AgentsClient.SearchAgent(null, null, false, "Amazon");
            Assert.That(agents != null && agents.Count > 0);
            agents = _apiClient.AgentsClient.SearchAgent(null, null, false, "Non-existant agent name");
            Assert.That(agents == null || agents.Count == 0);
            agents = _apiClient.AgentsClient.SearchAgent(AgentCountryCode.AD);
            Assert.That(agents != null && agents.Count == 0);
        }

        [Test, Order(0030), NonParallelizable]
        public void Test_0030_GetCategoriesListTest()
        {
            var categories = _apiClient.CategoriesClient.ListCategories();
            Assert.That(categories != null && categories.Count > 0);
        }

        [Test, Order(0040), NonParallelizable]
        public void Test_0040_GetCategoriesAndListAgentsByCategoryTest()
        {
            var categories = _apiClient.CategoriesClient.ListCategories();
            Assert.That(categories != null && categories.Count > 0);
            foreach (var category in categories)
            {
                var agents = _apiClient.CategoriesClient.ListAgentsByCategory(category.Id);
                Assert.That(agents != null); // Maybe there's a category with no agents so we just test if the result is null or not
            }
        }

        [Test, Order(0050), NonParallelizable]
        public void Test_0050_CreateAccountAndSynchronizeTest()
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
            while (synchronization.SynchronizationState != SynchronizationState.NotAck &&
                    synchronization.SynchronizationState != SynchronizationState.PendingAcknowledgement &&
                    synchronization.SynchronizationState != SynchronizationState.ReportFailed &&
                    synchronization.SynchronizationState != SynchronizationState.Completed)
            {
                System.Threading.Thread.Sleep(5000);
                synchronization = _apiClient.AccountsClient.GetLastSynchronizationsOfAccount(account.CustomerAccountId);
            }

            Assert.That(synchronization.SynchronizationStateDetails == SynchronizationStateDetails.Completed ||
                            synchronization.SynchronizationStateDetails == SynchronizationStateDetails.CompletedNothingNewToDownload);
        }

        [Test, Order(0060), NonParallelizable]
        public void Test_0060_DownloadDocument()
        {
            var documents = _apiClient.DocumentsClient.SearchDocuments(Constants.CustomerAccountId, includeContent: true);
            foreach (var document in documents)
            {
                if (string.IsNullOrEmpty(document.Base64Content) || document.Base64Content == "Content not found")
                {
                    continue; // Skip documents without content
                }

                byte[] documentContent = Convert.FromBase64String(document.Base64Content);
                System.IO.File.WriteAllBytes(@"C:\Temp\" + document.Name, documentContent);

                if (document.Id == documents.FirstOrDefault().Id)
                {
                    _apiClient.DocumentsClient.AcknowledgeDocumentDelivery(document.Id, failed: true);

                }
                else if (document.Id == documents.LastOrDefault().Id)
                {
                    _apiClient.DocumentsClient.AcknowledgeDocumentDelivery(document.Id, refused: true);
                }
                else
                {

                    _apiClient.DocumentsClient.AcknowledgeDocumentDelivery(document.Id);
                }
            }
        }

        [Test, Order(0070), NonParallelizable]
        public void Test_0070_AcknowledgeSynchTest()
        {
            var synchAcknowledgement = _apiClient.SynchronizationsClient.AcknowledgeSynchronizationDelivery(Constants.CustomerAccountId, new int[] { }, new int[] { });
            Assert.That(synchAcknowledgement);
        }

        [Test, Order(0080), NonParallelizable]
        public void Test_0080_DeleteAccountTest()
        {
            _apiClient.AccountsClient.DeleteAccount(Constants.CustomerAccountId);
            var deletedAccount = _apiClient.AccountsClient.GetAccount(Constants.CustomerAccountId);
            Assert.That(deletedAccount == null);
        }

        //[Test, Order(0090), NonParallelizable]
        public void Test_0090_MFAFullWorkflowTest()
        {
            #region CreateAccount
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
                Mode = "NoAutomaticSynch", // MFA accounts should have NoAutomaticSynch mode
                Name = "Account 1 - User defined name",
                Credentials = credentials
            };

            var account = _apiClient.AccountsClient.CreateAccount(apiAccount, false);
            #endregion

            #region FirstSynchronization
            var synchronization = _apiClient.AccountsClient.SynchronizeAccount(account.CustomerAccountId, true);
            while (synchronization.SynchronizationStateDetails == SynchronizationStateDetails.NewAccount ||
                    synchronization.SynchronizationStateDetails == SynchronizationStateDetails.Scheduled ||
                   synchronization.SynchronizationStateDetails == SynchronizationStateDetails.Pending ||
                   synchronization.SynchronizationStateDetails == SynchronizationStateDetails.InProgress)
            {
                System.Threading.Thread.Sleep(5000);
                synchronization = _apiClient.AccountsClient.GetLastSynchronizationsOfAccount(account.CustomerAccountId);
            }

            Assert.That(synchronization.SynchronizationStateDetails == SynchronizationStateDetails.AdditionalAuthenticationRequired);
            #endregion

            // Get the account with the additional authentication data
            apiAccount = _apiClient.AccountsClient.GetAccount(Constants.CustomerAccountId);

            // and confirm that it hasn't expired
            Assert.That(apiAccount.AdditionalAuthenticationData.ExpirationDate > DateTime.UtcNow);

            #region SaveSecretCode
            string sbxSecretCode = "[SecretCode]"; //Insert secret code that you receive

            // Save the secret code, it will also check if the mfa data hasn't expired, and it will synchronize
            bool isSaved = _apiClient.AccountsClient.AddMultiFactorAuthenticationSecretCode(apiAccount.CustomerAccountId, sbxSecretCode);
            Assert.That(isSaved);
            #endregion

            #region Second Synchronization
            // Keep checking the last synchronization of the account to make sure that it reaches a final state
            synchronization = _apiClient.AccountsClient.GetLastSynchronizationsOfAccount(apiAccount.CustomerAccountId);
            while (synchronization.SynchronizationStateDetails == SynchronizationStateDetails.NewAccount ||
                    synchronization.SynchronizationStateDetails == SynchronizationStateDetails.Scheduled ||
                   synchronization.SynchronizationStateDetails == SynchronizationStateDetails.Pending ||
                   synchronization.SynchronizationStateDetails == SynchronizationStateDetails.InProgress)
            {
                System.Threading.Thread.Sleep(5000);
                synchronization = _apiClient.AccountsClient.GetLastSynchronizationsOfAccount(apiAccount.CustomerAccountId);
            }

            // If the code is correct, the synchronization will be completed
            Assert.That(synchronization.SynchronizationStateDetails != SynchronizationStateDetails.WrongMFACode);
            #endregion
        }

        //[Test, Order(0100), NonParallelizable]
        public void Test_0100_SaveWrongMFASecretCodeAndSynchronizeTest()
        {
            // Get the account
            var apiAccount = _apiClient.AccountsClient.GetAccount(Constants.CustomerAccountId);

            // and confirm that the it hasn't expired
            Assert.That(apiAccount.AdditionalAuthenticationData.ExpirationDate > DateTime.UtcNow);

            string sbxSecretCode = "wrongcode";
            // Save the secret code, it will also check if the mfa data hasn't expired, and it will synchronize
            bool isSaved = _apiClient.AccountsClient.AddMultiFactorAuthenticationSecretCode(apiAccount.CustomerAccountId, sbxSecretCode);
            Assert.That(isSaved);

            #region Synchronize
            // Keep checking the last synchronization of the account to make sure that it reaches a final state
            var synchronization = _apiClient.AccountsClient.GetLastSynchronizationsOfAccount(apiAccount.CustomerAccountId);
            while (synchronization.SynchronizationStateDetails == SynchronizationStateDetails.NewAccount ||
                    synchronization.SynchronizationStateDetails == SynchronizationStateDetails.Scheduled ||
                   synchronization.SynchronizationStateDetails == SynchronizationStateDetails.Pending ||
                   synchronization.SynchronizationStateDetails == SynchronizationStateDetails.InProgress)
            {
                System.Threading.Thread.Sleep(5000);
                synchronization = _apiClient.AccountsClient.GetLastSynchronizationsOfAccount(apiAccount.CustomerAccountId);
            }

            // If the code is correct, the synchronization will be completed
            Assert.That(synchronization.SynchronizationStateDetails == SynchronizationStateDetails.WrongMFACode);
            #endregion
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Securibox.CloudAgents.Api.Banks;
using Securibox.CloudAgents.Api.Banks.Models;
using Securibox.CloudAgents.Core.AuthConfigs;

namespace Securibox.CloudAgents.Test.Banks
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
        public void GetBanksListTest()
        {
            var agents = _apiClient.BanksClient.GetBanks();
            Assert.IsTrue(agents != null && agents.Count > 0);
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
                BankId = Constants.AgentId,
                CustomerAccountId = Constants.CustomerAccountId,
                CustomerUserId = Constants.CustomerUserId,
                Mode = AccountMode.Enabled,
                Name = "Account 1 - User defined name",
                Credentials = credentials
            };

            var account = _apiClient.AccountsClient.CreateAccount(apiAccount, true);
            while (account.LastSynchronizationState == SynchronizationState.NewAccount ||
                   account.LastSynchronizationState == SynchronizationState.Created ||
                   account.LastSynchronizationState == SynchronizationState.LoggingIn ||
                   account.LastSynchronizationState == SynchronizationState.Running)
            {
                System.Threading.Thread.Sleep(5000);
                account = _apiClient.AccountsClient.GetAccount(account.CustomerAccountId);
            }

            Assert.IsTrue(account.LastSynchronizationState == SynchronizationState.Completed ||
                          account.LastSynchronizationState == SynchronizationState.CompletedWithErrors);
        }

        [TestMethod]
        public void SynchronizeAccount()
        {
            var synchronization = _apiClient.AccountsClient.SynchronizeAccount(Constants.CustomerAccountId, false);
            var status = synchronization.State;
            while (status == SynchronizationState.NewAccount ||
                   status == SynchronizationState.Created ||
                   status == SynchronizationState.LoggingIn ||
                   status == SynchronizationState.Running)
            {
                System.Threading.Thread.Sleep(5000);
                var account = _apiClient.AccountsClient.GetAccount(Constants.CustomerAccountId);
                status = account.LastSynchronizationState;
            }

            Assert.IsTrue(status == SynchronizationState.Completed ||
                          status == SynchronizationState.CompletedWithErrors);
        }


        [TestMethod]
        public void UpdateAccount()
        {
            var account = _apiClient.AccountsClient.GetAccount(Constants.CustomerAccountId);
            account.Name = "NameTest 23";
            account.Credentials = new List<Credential>();


            var retreivedAccount = _apiClient.AccountsClient.UpdateAccount(Constants.CustomerAccountId, account);
            Assert.IsTrue(account.Name == retreivedAccount.Name);

        }

        [TestMethod]
        public void ListAllAccounts()
        {
            var accounts = _apiClient.AccountsClient.ListAccounts();
            Assert.IsTrue(accounts != null && accounts.Count > 0);
        }

        [TestMethod]
        public void ListAccountsByBank()
        {
            var accounts = _apiClient.AccountsClient.ListAccountsByBank(Constants.AgentId);
            Assert.IsTrue(accounts != null && accounts.Count > 0);
        }

        [TestMethod]
        public void GetBankAccounts()
        {
            var bankAccounts = _apiClient.AccountsClient.ListBankAccountsByAccount(Constants.CustomerAccountId);
            Assert.IsTrue(bankAccounts != null && bankAccounts.Count > 0);
        }

        [TestMethod]
        public void DeleteAccount()
        {
            var isDeleted = _apiClient.AccountsClient.DeleteAccount(Constants.CustomerAccountId);
            Assert.IsTrue(isDeleted);
        }

    }
}

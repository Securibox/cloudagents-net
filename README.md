# cloudagents-net
A .NET library for the [Securibox Cloud Agents API](https://sca.securibox.eu).

## NuGet

    Install-Package Securibox.CloudAgents
	
*The Securibox.CloudAgents SDK for .NET binaries are only distributed via nuget. For those using older versions of Visual Studio that
does not support NuGet Package Manager, please download the [command line version of NuGet.exe](http://nuget.codeplex.com/releases/view/58939) and run the following
command.*

	nuget install Securibox.CloudAgents
	
## Authentication
In order to secure the Securibox Cloud Agents API, three mechanisms have been implemented. Here is a brief overview of the three mechanisms as well as code snippets to help you integrate the correct mechanism in order to call the APIs.

### Basic API Authentication w/ TLS
Basic API authentication is the easiest of the three to implement offering the lowest security options of the common protocols.
This mechanism is usually advised for testing purposes in order to test the APIs and only requires Securibox to provide a username and password.
```csharp
BasicAuthConfig basicAuthConfig = new BasicAuthConfig("[BasicUsername]", "[BasicPassword]");
ApiClient apiClient = new ApiClient("https://sca-multitenant.securibox.eu", basicAuthConfig);
```
Or configuring in the app.config file:
```xml
<configuration>
  <configSections>
    <section name="SecuriboxCloudAgentsConfiguration" type="Securibox.CloudAgents.Configurations.SecuriboxCloudAgentsConfiguration, Securibox.CloudAgents"/>
  </configSections>
  <SecuriboxCloudAgentsConfiguration authMode="basic" baseAddress="https://sca-multitenant.securibox.eu/" username="username" password="password"/>
</configuration>
```
### SSL Client Certificate Authentication 
The SSL client certification is a mechanism allowing your application to authenticate itself with the Securibox Cloud Agents (SCA) servers. In this case, your application will send its SSL certificate after verifing the SCA server identity. Then, the client and server use both certificates to generate a unique key used to sign requests sent between them.

This kind of authentication is implemented when the customer call your servers that will then call the Securibox Cloud Agents API.

In order to use this type of authentication, Securibox will provide a PFX certificate file containing a passphrase protected private key and a public key that can be installed in the certificate store.
The SDK can access the certificate store to perform client authentication:
```csharp
CertAuthConfig authConfig = new CertAuthConfig("[CertificateThumbprint]");
ApiClient apiClient = new ApiClient("https://sca-multitenant.securibox.eu", authConfig);
```
Or configuring in the app.config file:
```xml
<configuration>
  <configSections>
    <section name="SecuriboxCloudAgentsConfiguration" type="Securibox.CloudAgents.Configurations.SecuriboxCloudAgentsConfiguration, Securibox.CloudAgents"/>
  </configSections>
  <SecuriboxCloudAgentsConfiguration authMode="cert" baseAddress="https://sca-multitenant.securibox.eu/" certThumbprint="[CertificateThumbprint]" />
</configuration>
```

## Getting started
The following is the minimum needed code to list all agent details and fields:
```csharp
BasicAuthConfig basicAuthConfig = new BasicAuthConfig("[BasicUsername]", "[BasicPassword]");
ApiClient apiClient = new ApiClient("https://sca-multitenant.securibox.eu", basicAuthConfig);
var agents = apiClient.AgentsClient.ListAgents();
foreach(var agent in agents){
    Console.WriteLine("\n\n\n------ Agent Details ------\n");
    Console.WriteLine("ID: " + agent.id + "\n");
    Console.WriteLine("Name: " + agent.Name + "\n");
    Console.WriteLine("Periodicity: " + agent.AgentPeriodicity + "\n");
    Console.WriteLine("Current Status: " + agent.AgentCurrentState + "\n");
    Console.WriteLine("Category: " + agent.CategoryId + "\n");
}
```


The following code is the minimum code needed to configure an agents and launch a synchronization:
```csharp
//Configure credentials
var credentials = new List<Credential>
{
    new Credential {Position = 0, Value = "username", Alg = null },
    new Credential { Position = 1, Value = "password", Alg = null }
};

//Configure account properties    
var apiAccount = new Account
{
    AgentId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXX",
    CustomerAccountId = "customer_account_id",
    CustomerUserId = "customer_user_id",
    Mode = "Enabled",
    Name = "Account 1 - User defined name",
    Credentials = credentials
};

//Setup API authentication (basic) and client
BasicAuthConfig basicAuthConfig = new BasicAuthConfig("[BasicUsername]", "[BasicPassword]");
ApiClient apiClient = new ApiClient("https://sca-multitenant.securibox.eu", basicAuthConfig);

//Create the account which automatically launches a synchronization
var account = apiClient.AccountsClient.CreateAccount(apiAccount, true);

//Let's wait until the synchronization has reached a final status
var synchronization = apiClient.AccountsClient.GetLastSynchronizationsOfAccount(account.CustomerAccountId);
while (synchronization.SynchronizationStateDetails == SynchronizationStateDetails.NewAccount ||
        synchronization.SynchronizationStateDetails == SynchronizationStateDetails.Scheduled ||
       synchronization.SynchronizationStateDetails == SynchronizationStateDetails.Pending ||
       synchronization.SynchronizationStateDetails == SynchronizationStateDetails.InProgress)
{
    System.Threading.Thread.Sleep(5000);
    synchronization = apiClient.AccountsClient.GetLastSynchronizationsOfAccount(account.CustomerAccountId);
}

//Let's get the newly downloaded documents and save them locally
var documents = apiClient.DocumentsClient.SearchDocuments(apiAccount.CustomerAccountId);
foreach(var document in documents)
{
    byte[] documentContent = Convert.FromBase64String(document.Base64Content);
    System.IO.File.WriteAllBytes(@"C:\Temp\" + document.Name, documentContent);
    
    //Let's acknowlege the document
    _apiClient.DocumentsClient.AcknowledgeDocumentDelivery(document.Id);
}
```
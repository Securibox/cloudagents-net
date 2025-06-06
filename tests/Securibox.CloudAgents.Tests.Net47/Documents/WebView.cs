using NUnit.Framework;
using System.Security.Cryptography.X509Certificates;

namespace Securibox.CloudAgents.Tests.Net47.Documents
{
    public class WebView
    {
        [Test, Order(0001), NonParallelizable]
        public void Test_0001_GetWebViewLink()
        {
            X509Certificate2 cert = new X509Certificate2(@"C:\Path\To\PfxFile", "[Pfx Password]");

            var token = Securibox.CloudAgents.Core.Utils.BuildWebViewDefaultToken(cert, "customer1234");
            string webViewUrl = $"https://sca-webview.azurewebsites.net?token={token}&callback=https://www.myapp.com&state=customerData";
        }
    }
}

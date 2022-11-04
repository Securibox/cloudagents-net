using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Securibox.CloudAgents.Tests.NetCore.Documents
{
    [TestClass]
    public class WebView
    {
        [TestMethod]
        public void GetWebViewLink()
        {
            X509Certificate2 cert = new X509Certificate2(@"C:\Path\To\PfxFile", "[Pfx Password]");

            var token = Securibox.CloudAgents.Core.Utils.BuildWebViewDefaultToken(cert, "customer1234");
            string webViewUrl = $"https://sca-webview.azurewebsites.net?token={token}&callback=https://www.myapp.com&state=customerData";
            string webViewUrl2 = $"https://sca-webview-staging.azureedge.net/index.html?token={token}";
        }
    }
}

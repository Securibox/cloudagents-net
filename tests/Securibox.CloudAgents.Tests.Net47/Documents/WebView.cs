using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Securibox.CloudAgents.Tests.Net47.Documents
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
        }
    }
}

using HtmlAgilityPack;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Web_Crawler;

namespace UnitTestWebCrawler
{
    [TestClass]
    public class HtmlDocumentsTest
    {
        [TestMethod]
        public async Task GetHtmlDocument_StringBody_ReturnHtmlDocument()
        {
            HtmlDocument htmlDocument = await HtmlDocuments.GetHtmlDocument();
            Assert.IsNotNull(htmlDocument);
        }
        [TestMethod]
        public async Task GetPageString_Url_ReturnStringBody()
        {
            string htmlDocument = await HtmlDocuments.GetPageString();
            Assert.IsNotNull(htmlDocument);
        }
    }
}

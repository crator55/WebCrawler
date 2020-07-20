using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web_Crawler;

namespace UnitTestWebCrawler
{
    [TestClass]
    public class AssemblyHtmlTest
    {
        [TestMethod]
        public async Task GetHtmlTags_HtmlTags_ReturnSpecificNode()
        {
            List<Entry> entries =  await AssemblyHtml.GetHtmlTags();
            Assert.IsNotNull(entries);
        }
    }
}

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
            await AssemblyHtml.GetHtmlTags();
            Assert.IsNotNull(AssemblyHtml.tds);
            Assert.IsNotNull(AssemblyHtml.trs);
        }
        [TestMethod]
        public async Task ParseHtmlEntry_Node_ReturnEntry()
        {
            await AssemblyHtml.GetHtmlTags();
            List<Entry> entries =  AssemblyHtml.ParseHtmlEntry(AssemblyHtml.trs, AssemblyHtml.tds,Const.HtmlElement,Const.Selector,Const.NameClass);
            Assert.IsNotNull(entries);
        }
    }
}

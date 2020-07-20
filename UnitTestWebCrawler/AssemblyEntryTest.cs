using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web_Crawler;

namespace UnitTestWebCrawler
{
    [TestClass]
    public  class AssemblyEntryTest
    {
        [TestMethod]
        public async Task GetEntries_ycombinatorPage_ReturnsEntries()
        {
          List<Entry>entries= await  AssemblyEntry.GetEntries();
          Assert.IsNotNull(entries);
        }
    }
}

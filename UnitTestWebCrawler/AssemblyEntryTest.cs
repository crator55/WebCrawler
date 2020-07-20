using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Web_Crawler;

namespace UnitTestWebCrawler
{
    [TestClass]
    public  class AssemblyEntryTest
    {
        [TestMethod]
        public void GetEntries()
        {
          Assert.IsNotNull(AssemblyEntry.GetEntries());
        }
    }
}

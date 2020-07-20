using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Web_Crawler;

namespace UnitTestWebCrawler
{
    [TestClass]
    public class AssemblyStringTest
    {
        [TestMethod]
        public void GetNumbersString_StringWithNumbers_ReturnsIntegers()
        {
            List<Entry> result = AssemblyString.GetNumbersString(Data.FakeData());
            int number;
            foreach (var item in result)
            {
                Assert.IsTrue(Int32.TryParse(item.Comments, out number));
                Assert.IsTrue(Int32.TryParse(item.Order, out number));
                Assert.IsTrue(Int32.TryParse(item.Points, out number));
            }
        }
        [TestMethod]
        public void Filter_Optiona_ReturnsListFiltered()
        {
            List<Entry> result = AssemblyString.Filter(Data.FakeDataWithOutNumbers(), Const.case1);
            bool less5 = false;
            foreach (var item in result)
            {
                if (item.Title.Split(' ', '-').Count() < 5)
                {
                    less5 = true;
                }
            }
            Assert.IsFalse(less5);
        }
        [TestMethod]
        public void Filter_Optionb_ReturnsListFiltered()
        {
            List<Entry> result = AssemblyString.Filter(Data.FakeDataWithOutNumbers(), Const.case2);
            bool more5 = false;
            foreach (var item in result)
            {
                if (item.Title.Split(' ', '-').Count() >= 5)
                {
                    more5 = true;
                }
            }
            Assert.IsFalse(more5);
        }
    }
}

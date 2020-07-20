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
        public List<Entry> GetNumbersString_StringWithNumbers_ReturnsIntegers()
        {
            List<Entry> result = AssemblyString.GetNumbersString(Data.FakeData());
            int number;
            foreach (var item in result)
            {
                Assert.IsTrue(Int32.TryParse(item.Comments, out number));
                Assert.IsTrue(Int32.TryParse(item.Order, out number));
                Assert.IsTrue(Int32.TryParse(item.Points, out number));
            }
            return result;
        }
        [TestMethod]
        public void Filter_Optiona_ReturnsListFiltered()
        {
            List<Entry> result = AssemblyString.Filter(GetNumbersString_StringWithNumbers_ReturnsIntegers(), Const.case1);
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
            List<Entry> result = AssemblyString.Filter(GetNumbersString_StringWithNumbers_ReturnsIntegers(), Const.case2);
            bool less5 = false;
            foreach (var item in result)
            {

                if (item.Title.Split(' ', '-').Count() >= 5)
                {
                    less5 = true;
                }
            }
            Assert.IsFalse(less5);
        }
    }
}

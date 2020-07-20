using System.Collections.Generic;
using Web_Crawler;

namespace UnitTestWebCrawler
{
   public class Data
    {
        public static List<Entry> FakeData()
        {
            List<Entry> listEntries = new List<Entry>()
            {
               new Entry (){Comments="as123f",Order="asd23f",Points="asd33f",Title="Fixing Mass Effect black blobs on modern AMD CPUs" },
               new Entry (){Comments="2w",Order="2rt",Points="1",Title="The Passport Payment (2000)" },
               new Entry (){Comments="",Order="2rt",Points="1",Title="Sirum (YC W15 Nonprofit) hiring fullstack engineers to make medicine affordable" },

            };
            return listEntries;
        }
    }
}

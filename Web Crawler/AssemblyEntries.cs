using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web_Crawler
{
   public class AssemblyEntries
    {
        public static async Task<List<Entries>> GetEntries(char Case)
        {
            Task<List<Entries>> listEntries = StartCrawlerAsync();
            List<Entries> entries = await listEntries;
            List<Entries> listFiltered = AssemblyStrings.Filter(entries, Case);
            return listFiltered;

        }

        private static async Task<List<Entries>> StartCrawlerAsync()
        {
            return AssemblyStrings.GetNumbersString(await AssemblyHtmls.GetHtmlTags());
        }
    }
}

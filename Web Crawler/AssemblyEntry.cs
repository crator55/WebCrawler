﻿using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Web_Crawler
{
   public class AssemblyEntry
    {
        public static async Task<List<Entry>> GetEntries()
        {
            Task<List<Entry>> listEntries = StartCrawlerAsync();
            List<Entry> entries = await listEntries;
            return entries;
        } 
        private static async  Task<List<Entry>> StartCrawlerAsync()
        {
            return AssemblyString.GetNumbersString(await AssemblyHtml.GetHtmlTags());
        }
    }
}
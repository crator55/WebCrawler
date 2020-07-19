using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Web_Crawler
{
   public class HtmlDocuments
    {
        private static async Task<string> GetConnection()
        {
            string url = "https://news.ycombinator.com/";
            HttpClient httpClient = new HttpClient();
            return await httpClient.GetStringAsync(url);
        }
        public static async Task<HtmlDocument> GetHtmlDocument()
        {
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(await GetConnection());
            return htmlDocument;
        }
        public static string GetSpecificNode(HtmlNode htmlNode, string firstChild, string selector, string nameClass)
        {

            return htmlNode.Descendants($"{firstChild}").Where(node => node.GetAttributeValue($"{selector}", "")
                     .Equals($"{nameClass}")).FirstOrDefault().InnerText;


        }
        public static List<HtmlNode> GetInformationNode(HtmlDocument htmlDocument, string firstChild, string selector, string nameClass)
        {
            return htmlDocument.DocumentNode.Descendants($"{firstChild}")
                    .Where(node => node.GetAttributeValue($"{selector}", "").Equals($"{nameClass}")).ToList();
        }
    }
}

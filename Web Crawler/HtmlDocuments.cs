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
        public static string GetSpecificNode(HtmlNode htmlNode, string FirstChild, string Selector, string NameClass)
        {

            return htmlNode.Descendants($"{FirstChild}").Where(node => node.GetAttributeValue($"{Selector}", "")
                     .Equals($"{NameClass}")).FirstOrDefault().InnerText;


        }
        public static List<HtmlNode> GetInformationNode(HtmlDocument HtmlDocument, string FirstChild, string Selector, string NameClass)
        {
            return HtmlDocument.DocumentNode.Descendants($"{FirstChild}")
                    .Where(node => node.GetAttributeValue($"{Selector}", "").Equals($"{NameClass}")).ToList();
        }
    }
}

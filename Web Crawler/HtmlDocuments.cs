using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Web_Crawler
{
    public class HtmlDocuments
    {
        public static async Task<string> GetPageString()
        {
            HttpClient httpClient = new HttpClient();
            return await httpClient.GetStringAsync(Const.Url);
        }
        public static async Task<HtmlDocument> GetHtmlDocument()
        {
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(await GetPageString());
            return htmlDocument;
        } 
    }
}

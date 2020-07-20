using HtmlAgilityPack;
using System.Net.Http;
using System.Threading.Tasks;

namespace Web_Crawler
{
    public class HtmlDocuments
    {
        public static async Task<string> GetPageString()
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                return await httpClient.GetStringAsync(Const.Url);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
           
        }
        public static async Task<HtmlDocument> GetHtmlDocument()
        {
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(await GetPageString());
            return htmlDocument;
        } 
    }
}

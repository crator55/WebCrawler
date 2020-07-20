using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace Web_Crawler
{
    public class AssemblyHtml
    {      
        public async static Task<List<Entry>> GetHtmlTags()
        {
            var trs = GetBodyNode(await HtmlDocuments.GetHtmlDocument(), "tr", Const.Selector, "athing");
            var tds = GetBodyNode(await HtmlDocuments.GetHtmlDocument(), Const.HtmlElement, Const.Selector, "subtext");
            return ParseHtmlEntry(trs, tds,Const.HtmlElement,Const.Selector,Const.NameClass);
        }
        public static List<Entry> ParseHtmlEntry(List<HtmlNode> trs, List<HtmlNode> tds, string htmlElement, string selector, string nameClass)
        {
            List<Entry> list_entries = new List<Entry>();
            for (int i = 0; i < tds.Count(); i++)
            {
                for (int j = 0; j < trs.Count(); j++)
                {
                    if (i == j)
                    {
                        Entry entry = new Entry
                        {
                            Title = trs[j].Descendants(htmlElement).Where(node => node.GetAttributeValue(selector, "").Equals(nameClass)).Last().InnerText,
                            Order = GetSpecificNode(trs[j], htmlElement, selector, nameClass),
                            Points = GetSpecificNode(tds[j], htmlElement = "span", selector, nameClass = "score"),
                            Comments = tds[j].Descendants(htmlElement = "a").Last().InnerText
                        };
                        htmlElement = "td";
                        nameClass = "title";
                        list_entries.Add(entry);
                    }
                }
            }
            return list_entries;
        }
        private static string GetSpecificNode(HtmlNode htmlNode, string firstChild, string selector, string nameClass)
        {
            return htmlNode.Descendants($"{firstChild}").Where(node => node.GetAttributeValue($"{selector}", "")
                     .Equals($"{nameClass}")).FirstOrDefault().InnerText;
        }
        private static List<HtmlNode> GetBodyNode(HtmlDocument htmlDocument, string firstChild, string selector, string nameClass)
        {
            return htmlDocument.DocumentNode.Descendants($"{firstChild}")
                    .Where(node => node.GetAttributeValue($"{selector}", "").Equals($"{nameClass}")).Take(30).ToList();
        }
    }
}

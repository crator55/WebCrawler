using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Crawler
{
   public class AssemblyHtmls
    {
        public async static Task<List<Entries>> GetHtmlTags()
        {

            string htmlElement = "td";
            string Selector = "class";
            string nameClass = "title";

            var trs = HtmlDocuments.GetInformationNode(await HtmlDocuments.GetHtmlDocument(), "tr", Selector, "athing");
            var tds = HtmlDocuments.GetInformationNode(await HtmlDocuments.GetHtmlDocument(), htmlElement, Selector, "subtext");

            return ParseHtmlEntry(trs, tds, htmlElement, Selector, nameClass);
        }
        private static List<Entries> ParseHtmlEntry(List<HtmlNode> trs, List<HtmlNode> tds, string htmlElement, string Selector, string nameClass)
        {
            List<Entries> list_entries = new List<Entries>();
            for (int i = 0; i < tds.Count(); i++)
            {
                for (int j = 0; j < trs.Count(); j++)
                {
                    if (i == j)
                    {
                        Entries entry = new Entries
                        {
                            Title = trs[j].Descendants(htmlElement).Where(node => node.GetAttributeValue(Selector, "").Equals(nameClass)).Last().InnerText,
                            Order = HtmlDocuments.GetSpecificNode(trs[j], htmlElement, Selector, nameClass),
                            Points = HtmlDocuments.GetSpecificNode(tds[j], htmlElement = "span", Selector, nameClass = "score"),
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
    }
}

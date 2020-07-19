using System;
using HtmlAgilityPack;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace Web_Crawler
{
    class Program
    {
        static async Task Main(string[] args)
        {

            while (true)
            {
                ShowOptions();
                string Case = Console.ReadLine().ToString();
                switch (Case)
                {
                    case "a":

                        ShowEntriesList(await GetEntries('a'));
                        break;
                    case "b":
                        ShowEntriesList(await GetEntries('b'));
                        break;
                    case "c":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine($"An unexpected value ({Case})");
                        break;
                }

            }

        }
        private static async Task<List<Entries>> GetEntries(char Case)
        {
            Task<List<Entries>> list_entries = StartCrawlerAsync();
            List<Entries> entries = await list_entries;
            List<Entries> listFiltered = Filter(entries, Case);
            return listFiltered;

        }
        private static void ShowOptions()
        {
            Console.WriteLine("Choose an option from the following list:");
            Console.WriteLine("\ta - Filtering with more than five words in the title.");
            Console.WriteLine("\tb - Filtering less than or equal to five words in the title.");
            Console.WriteLine("\tc - Exit Aplication.");
            Console.Write("Your option? ");

        }
        private static string AsignCeroEmpty(string item)
        {
            item = item == "" ? "0" : item;
            return item;
        }
        private static List<Entries> Filter(List<Entries> list_entries, char Option) {
            List<Entries> listMore5 = new List<Entries>();
            List<Entries> listless5 = new List<Entries>();
            foreach (var item in list_entries)
            {
                item.Comments = AsignCeroEmpty(item.Comments);
                item.Points = AsignCeroEmpty(item.Points);
                if (item.Title.Split(' ','-').Count() > 5)
                {
                    listMore5.Add(item);
                }
                else
                {
                    listless5.Add(item);
                }

            }
           
            return OrderEntry(Option,listMore5, listless5);
        }
        private static List<Entries> OrderEntry(char Option, List<Entries> listMore5, List<Entries> listless5)
        {
             List <Entries> ascendingOrder = Option == 'a' ?
                     listMore5.OrderBy(i => Int16.Parse(i.Comments)).ToList() :
                     listless5.OrderBy(i => Int16.Parse(i.Points)).ToList();
            return ascendingOrder;
        }
    private static async Task<string> GetConnection()
        {
            string url = "https://news.ycombinator.com/";
            HttpClient httpClient = new HttpClient();
            return await httpClient.GetStringAsync(url);
        }
        private static async Task<HtmlDocument> GetHtmlDocument()
        {
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(await GetConnection());
            return htmlDocument;
        }
        private async static Task<List<Entries>> GetHtmlTags()
        {

            string htmlElement = "td";
            string Selector = "class";
            string nameClass = "title";

            var trs = GetInformationNode(await GetHtmlDocument(), "tr", Selector, "athing");
            var tds = GetInformationNode(await GetHtmlDocument(), htmlElement, Selector, "subtext");

            return ParseHtmlEntry(trs, tds, htmlElement, Selector, nameClass);
        }
        private static async Task<List<Entries>> StartCrawlerAsync()
        {
            return GetNumbersString(await GetHtmlTags());
        }
        private static void ShowEntriesList(List<Entries> list_entries) {

            Console.Clear();
            foreach (var item in list_entries)
            {
                Console.WriteLine("Title:"+ $"{item.Title}");
                Console.WriteLine("Points:" + $"{item.Points}");
                Console.WriteLine("Order:" + $"{item.Order}");
                Console.WriteLine("Comments:" + $"{item.Comments}"+"\n");
            }
            
        }
        private static List<Entries> GetNumbersString(List<Entries> list_entries)
        {
            foreach (var item in list_entries)
            {
                item.Order = GetOnlyNumbers(item.Order);
                item.Points = GetOnlyNumbers(item.Points);
                item.Comments = GetOnlyNumbers(item.Comments);
            }
            return list_entries;
        }
        private static string GetOnlyNumbers(string attribute) {

            return String.Join("", attribute.Where(char.IsDigit));
        }

        private static List<Entries> ParseHtmlEntry(List<HtmlNode> trs, List<HtmlNode>tds,string htmlElement,string Selector,string nameClass)
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
                            Order = GetSpecificNode(trs[j], htmlElement, Selector, nameClass),
                            Points = GetSpecificNode(tds[j], htmlElement = "span", Selector, nameClass = "score"),
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
        private static string GetSpecificNode(HtmlNode htmlNode, string FirstChild, string Selector, string NameClass) {

          return  htmlNode.Descendants($"{FirstChild}").Where(node => node.GetAttributeValue($"{Selector}", "")
                    .Equals($"{NameClass}")).FirstOrDefault().InnerText;


        }
        private static List<HtmlNode> GetInformationNode(HtmlDocument HtmlDocument,string FirstChild, string Selector, string NameClass)
        {
            return HtmlDocument.DocumentNode.Descendants($"{FirstChild}")
                    .Where(node => node.GetAttributeValue($"{Selector}", "").Equals($"{NameClass}")).ToList();
        }
    }
}

 using System;
using System.Collections.Generic;
using System.Linq;


namespace Web_Crawler
{
    public class AssemblyString
    {
        private static string AsignCeroEmpty(string item)
        {
            item = item == "" ? "0" : item;
            return item;
        }
        public static List<Entry> Filter(List<Entry> listEntries, string option)
        {
            List<Entry> listMore5 = new List<Entry>();
            List<Entry> listless5 = new List<Entry>();
            foreach (var item in listEntries)
            {
                if (item.Title.Split(' ', '-').Count() > 5)
                {
                    listMore5.Add(item);
                }
                else
                {
                    listless5.Add(item);
                }
            }

            return OrderEntry(option, listMore5, listless5);
        }
        private static List<Entry> OrderEntry(string option, List<Entry> listMore5, List<Entry> listless5)
        {
            List<Entry> ascendingOrder = option == "a" ?
                    listMore5.OrderBy(i => Int16.Parse(i.Comments)).ToList() :
                    listless5.OrderBy(i => Int16.Parse(i.Points)).ToList();
            return ascendingOrder;
        }
        public static List<Entry> GetNumbersString(List<Entry> listEntries)
        {
            foreach (var item in listEntries)
            {
                item.Order = GetOnlyNumbers(item.Order);
                item.Points = AsignCeroEmpty(GetOnlyNumbers(item.Points));
                item.Comments = AsignCeroEmpty(GetOnlyNumbers(item.Comments));
            }
            return listEntries;
        }
        private static string GetOnlyNumbers(string attribute)
        {
            return String.Join("", attribute.Where(char.IsDigit));
        }
    }
}

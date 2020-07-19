using System;
using System.Collections.Generic;
using System.Linq;


namespace Web_Crawler
{
   public class AssemblyStrings
    {
        private static string AsignCeroEmpty(string item)
        {
            item = item == "" ? "0" : item;
            return item;
        }
        public static List<Entries> Filter(List<Entries> list_entries, char Option)
        {
            List<Entries> listMore5 = new List<Entries>();
            List<Entries> listless5 = new List<Entries>();
            foreach (var item in list_entries)
            {
                item.Comments = AsignCeroEmpty(item.Comments);
                item.Points = AsignCeroEmpty(item.Points);
                if (item.Title.Split(' ', '-').Count() > 5)
                {
                    listMore5.Add(item);
                }
                else
                {
                    listless5.Add(item);
                }

            }

            return OrderEntry(Option, listMore5, listless5);
        }
        private static List<Entries> OrderEntry(char Option, List<Entries> listMore5, List<Entries> listless5)
        {
            List<Entries> ascendingOrder = Option == 'a' ?
                    listMore5.OrderBy(i => Int16.Parse(i.Comments)).ToList() :
                    listless5.OrderBy(i => Int16.Parse(i.Points)).ToList();
            return ascendingOrder;
        }

        public static List<Entries> GetNumbersString(List<Entries> list_entries)
        {
            foreach (var item in list_entries)
            {
                item.Order = GetOnlyNumbers(item.Order);
                item.Points = GetOnlyNumbers(item.Points);
                item.Comments = GetOnlyNumbers(item.Comments);
            }
            return list_entries;
        }
        private static string GetOnlyNumbers(string attribute)
        {
            return String.Join("", attribute.Where(char.IsDigit));
        }
    }
}

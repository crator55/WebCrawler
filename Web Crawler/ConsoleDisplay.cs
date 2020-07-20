using System;
using System.Collections.Generic;


namespace Web_Crawler
{
    public class ConsoleDisplay
    {
        public static void ShowOptions()
        {
            Console.WriteLine("Choose an option from the following list:");
            Console.WriteLine("\ta - Filtering with more than five words in the title.");
            Console.WriteLine("\tb - Filtering less than or equal to five words in the title.");
            Console.WriteLine("\tc - Exit Aplication.");
            Console.Write("Your option? ");
        }

        public static void ShowEntriesList(List<Entry> listEntries)
        {
            Console.Clear();
            foreach (var item in listEntries)
            {
                Console.WriteLine("Title:" + $"{item.Title}");
                Console.WriteLine("Points:" + $"{item.Points}");
                Console.WriteLine("Order:" + $"{item.Order}");
                Console.WriteLine("Comments:" + $"{item.Comments}" + "\n");
            }
        }
    }
}

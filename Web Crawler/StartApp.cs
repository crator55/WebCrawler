using System;
using System.Threading.Tasks;

namespace Web_Crawler
{
    public class StartApp
    {
        public static async Task Starts()
        {
            while (true)
            {
                ConsoleDisplay.ShowOptions();
                string Case = Console.ReadLine().ToString();
                switch (Case)
                {
                    case "a":
                        ConsoleDisplay.ShowEntriesList(await AssemblyEntries.GetEntries('a'));
                        break;
                    case "b":
                        ConsoleDisplay.ShowEntriesList(await AssemblyEntries.GetEntries('b'));
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
    }
}

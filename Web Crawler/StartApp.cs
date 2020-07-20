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
                string caseEntry = Console.ReadLine();
                switch (caseEntry)
                {
                    case Const.case1:
                        ConsoleDisplay.ShowEntriesList(AssemblyString.Filter(await AssemblyEntry.GetEntries(), Const.case1));
                        break;
                    case Const.case2:
                        ConsoleDisplay.ShowEntriesList(AssemblyString.Filter(await AssemblyEntry.GetEntries(), Const.case2));
                        break;
                    case Const.case3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine($"An unexpected value ({caseEntry})");
                        break;
                }
            }
        }
    }
}

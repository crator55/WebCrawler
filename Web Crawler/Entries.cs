
using System.Diagnostics;

namespace Web_Crawler
{
    [DebuggerDisplay("{Title},{Order},{Comments},{Points}")]
    public class Entries
    {
        public string Title { get; set; }
        public string Order { get; set; }
        public string Comments { get; set; }
        public string Points { get; set; }
    

    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Web_Crawler
{
    [DebuggerDisplay("{Title},{Order},{Comments},{Points}")]
    class Entries
    {
        public string Title { get; set; }
        public string Order { get; set; }
        public string Comments { get; set; }
        public string Points { get; set; }
    

    }
}

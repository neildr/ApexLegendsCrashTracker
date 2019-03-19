using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApexLegendsCrashTracker {
    public class CrashFile {
        public DateTime LastUpdate { get; set; }
  
        public string[] FileContents { get; set; }
    }
}

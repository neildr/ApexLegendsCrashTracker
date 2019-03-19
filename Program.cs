using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ApexLegendsCrashTracker {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Enter drive of Documents folder:");
            var drive = Console.ReadLine();
            var filePath = string.Format(@"{0}:\Documents\apex_crash.txt",drive);
            var documentPath = Path.GetDirectoryName(filePath);
            var masterFilePath = documentPath + @"\ApexLegendsCrashLogMaster.txt";
            if (File.Exists(filePath)) {
                Console.WriteLine("File found!");
                try {
                    Console.WriteLine("Loading Apex Legends Crash File");
                    //D:\Documents\apex_crash.txt
                    var file = new CrashFile {
                        LastUpdate = File.GetLastAccessTimeUtc(filePath),
                        FileContents = File.ReadAllLines(filePath)
                    };                    
                    WriteToMasterFile(masterFilePath, file);
                }
                catch (Exception ex) {
                    Console.WriteLine("Error! {0}", ex);
                }
                finally {
                    Console.WriteLine("Written to master log file at {0}\nPress any key to exit.",masterFilePath);
                    Console.ReadLine();
                }
            } else {
                Console.WriteLine("Log file Not Found!\nPress any key to exit.");
                Console.ReadLine();
            }
           
            
        }
        public static void WriteToMasterFile(string documentPath, CrashFile file) {
            var append = file.FileContents.ToList();
            append.Insert(0,string.Format("Crash Occured at {0}, log files below:\n",file.LastUpdate.ToString()));
            append.Add("--------------------------------------End of Crash--------------------------------------");
            append.Add(Environment.NewLine);
            File.WriteAllLines(documentPath, append);

        }
    }
}

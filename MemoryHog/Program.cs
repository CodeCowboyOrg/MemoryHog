using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace MemoryHog
{
    /// <summary>
    /// All this program does is eat up memory to simulate a Memory Leak
    /// The use of XmlNode is so the COMMIT MEMORY count and WORKING SET is the same
    /// that is the mem allocated by OS is actually used by the process allocating it
    /// otherwise COMMIT may be large, but WORKING SET may be next to nothing and
    /// so there will still be memory freely available on the system
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Parameters parms = new Parameters();
            ParseCommandLine(args, out parms);
            WriteCommandLine(parms);
            WriteMemoryUsage();

            long runningTotal = GC.GetTotalMemory(false);
            long endingMemoryLimit = Convert.ToInt64(parms.TotalAllocatedMemoryInMegs) * 1000 * 1000;
            List<XmlNode> memList = new List<XmlNode>();

            //15,000 XmlNode Objects is about 1 megs 
            int numObjects = 15000 * Convert.ToInt32(parms.IterationAllocatedMemoryInMegs);
            while (runningTotal <= endingMemoryLimit)
            {
                XmlDocument doc = new XmlDocument();
                for (int i = 0; i < numObjects; i++)
                {
                    XmlNode x = doc.CreateNode(XmlNodeType.Element, "hello", "");
                    memList.Add(x);
                }
                runningTotal = GC.GetTotalMemory(false);
                WriteMemoryUsage();
                Thread.Sleep(Convert.ToInt32(parms.IterationDelayInMilliseconds));
            }
            Console.ReadLine();
            
        }

        static private void ParseCommandLine(string [] args, out Parameters parms)
        {
            parms = new Parameters();
            parms.IterationAllocatedMemoryInMegs = "0";
            parms.TotalAllocatedMemoryInMegs = "0";
            parms.IterationDelayInMilliseconds = "0";
            if (args.Length >= 1) parms.IterationAllocatedMemoryInMegs = args[0];
            if (args.Length >= 2) parms.TotalAllocatedMemoryInMegs     = args[1];
            if (args.Length >= 3) parms.IterationDelayInMilliseconds   = args[2];
        }

        static private void WriteCommandLine(Parameters parms)
        {
            Console.WriteLine("Iteration Memory To Eat Up in Megs: " + parms.IterationAllocatedMemoryInMegs);
            Console.WriteLine("    Total Memory To Eat Up in Megs: " + parms.TotalAllocatedMemoryInMegs);
            Console.WriteLine("Millisecs Pause Between Increments: " + parms.TotalAllocatedMemoryInMegs);            

        }

        static private void WriteMemoryUsage()
        {
            Console.WriteLine("Memory Usage:" + Convert.ToString(GC.GetTotalMemory(false)));
        }
    }

    public class Parameters
    {
        public Parameters() { }
        public string TotalAllocatedMemoryInMegs{ get; set;}
        public string IterationAllocatedMemoryInMegs{get; set;}
        public string IterationDelayInMilliseconds{get; set;}
    }
}

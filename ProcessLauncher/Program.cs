using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ProcessLauncher
{
    /// <summary>
    /// All this class does is Launch another process which eats up memory
    /// to simulate a severe memory leak
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {            
            string exeName   = String.Empty;
            string exeParams = String.Empty;
            if (args.Length <= 0)
            {
                exeName = "MemoryHog.exe";
                exeParams = "1 200 1000";  //allocate 1 Meg at a time, up till 200 Megs, pausing 1000 milliseconds between allocations
            }
            Process process = Process.Start(exeName, exeParams);
            Console.WriteLine("Press Enter To End Job.");
            Console.Read();
            process.Kill();

        }
    }
}

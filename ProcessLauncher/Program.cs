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
                exeParams = "6000 2000";
            }
            Process process = Process.Start(exeName, exeParams);
            Console.WriteLine("Press Enter To End Job.");
            Console.Read();
            process.Kill();

        }
    }
}

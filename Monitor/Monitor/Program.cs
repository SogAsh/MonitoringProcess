using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Monitor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var nameProcess = args[0].ToString();
            var keepAlive = int.Parse(args[1]);
            var frequencyMonitoring = int.Parse(args[2]);
            while (true)
            {
                var targetProcesses = Process.GetProcessesByName(nameProcess);
                if (targetProcesses.Count() > 0)
                foreach (var proc in targetProcesses) 
                    {
                        var currentTime = DateTime.Now.Subtract(proc.StartTime).TotalMilliseconds;
                        if (currentTime > keepAlive * 60 * 1000)
                        {
                            proc.Kill();
                            Console.WriteLine(nameProcess + " is finished");
                        }
                    Console.WriteLine("Process monitoring");
                    }
                Thread.Sleep(frequencyMonitoring * 60 * 1000);
            }
        }
      
    }
}

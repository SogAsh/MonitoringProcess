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
        static void Main(string[] args)
        {
            var nameProcess = args[0].ToString();
            var keepAlive = int.Parse(args[1].ToString());
            var frequencyMonitor = int.Parse(args[2].ToString());

            while (true)
            {
                var targetProcesses = Process.GetProcessesByName(nameProcess);
                if (targetProcesses.Count() > 0)
                    foreach (var proc in targetProcesses)
                    {
                        var currentTime = DateTime.Now.Subtract(proc.StartTime).TotalMilliseconds;
                        if (currentTime > keepAlive * 60 * 1000)
                            proc.Kill();
                    }
                Thread.Sleep(frequencyMonitor * 60 * 1000);
            }
        }
      
    }
}

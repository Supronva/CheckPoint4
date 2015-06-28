using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using System.Timers;

namespace EpamCheckPoint4ServiceReadingCSVFiles
{
    public class Program
    {
      
        private static readonly Watcher watcher = new Watcher();
        static void Main(string[] args)
        {
          watcher.Run();
          Console.ReadLine();
        }
    }
}

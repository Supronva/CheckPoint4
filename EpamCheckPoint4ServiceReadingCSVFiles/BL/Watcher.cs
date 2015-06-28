using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public class Watcher
   {
       private static readonly FileSystemWatcher fsw = new FileSystemWatcher();

       public static void Run()
       {
           fsw.Path = @"D:\Watcher\New\";
           fsw.Filter = "*.csv";
           fsw.Created +=new FileSystemEventHandler(OnCreated);
           fsw.EnableRaisingEvents = true;
           Console.WriteLine("Press \'q\' to exit.");
           while (Console.Read() != 'q');
       }

       private static void OnCreated(object sender, FileSystemEventArgs e)
       {
           DirectoryInfo source = new DirectoryInfo(@"D:\Watcher\New\");
           DirectoryInfo destin = new DirectoryInfo(@"D:\Watcher\Old\");

           foreach (var item in source.GetFiles())
           {
               try
               {
                   var parser = new Parser();
                   parser.ParserFiles(e.FullPath, e.Name);
                   item.MoveTo(destin + item.Name);
               }
               catch (IOException exception)
               {
                 Console.WriteLine(exception.Message);
               }
           }
       }

       public static void Stop()
       {
           fsw.Created -=new FileSystemEventHandler(OnCreated);
           fsw.EnableRaisingEvents = false;
       }
    }
}

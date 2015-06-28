using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BL;
using System.Timers;

namespace MyService
{
    public partial class MyService : ServiceBase
    {
        private static readonly Watcher watcher = new Watcher();

        public MyService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            watcher.Run();
        }

        protected override void OnStop()
        {
            watcher.Stop();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace K163636_Q4b
{
    public partial class Service1 : ServiceBase
    {
        System.Timers.Timer timer = new System.Timers.Timer();
        
        private int _timerValue = Convert.ToInt32(ConfigurationSettings.AppSettings["_timerLimit"]);
        public Service1()
        {
            InitializeComponent();
            CreateTempFile();
        }

        public void CreateTempFile()
        {
            string path_ = System.Environment.CurrentDirectory + "log.xml";
            string Filepath_ = ConfigurationSettings.AppSettings["Path"];

        }

        public void OnDebug()
        {
            OnStart(null);
        }
        protected override void OnStart(string[] args)
        {
            timer.Elapsed += new ElapsedEventHandler(timer1_Elapsed);
            timer.Interval = 1000; // 1000 ms => 1 second
            timer.Enabled = true;
        }

        protected override void OnStop()
        {
            timer.Enabled = false;
        }

        private int lastminute = -1;
        private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var curTime = DateTime.Now; // Get current time
            if (lastminute < curTime.Minute) // If now 5 min of any hour
            {
                lastminute = curTime.Minute + _timerValue;
                // work to be done here 

                
                toDoWork();

            }
        }

        public void toDoWork()
        {
            string path_ = ConfigurationSettings.AppSettings["Path"];
            var lastModified = System.IO.File.GetLastWriteTime(path_);
            if (lastModified.Minute + 14 > DateTime.Now.Minute)
            {
                //means modified 

            }

        }
    }
}

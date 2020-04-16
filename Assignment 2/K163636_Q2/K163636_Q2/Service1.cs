using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace K163636_Q2
{
    public partial class Service1 : ServiceBase
    {
       // private int _timerValue = Convert.ToInt32(ConfigurationSettings.AppSettings["TimerLimit"]);
        public Thread WorkerThread = null;

        public Service1()
        {
            InitializeComponent();
        }

        public void OnDebug()
        {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                ThreadStart start = new ThreadStart(working);
                WorkerThread = new Thread(start);
                WorkerThread.Start();
            }
            catch (Exception ex)
            {
                string tempPath = "C:\\Users\\Bilal\\Desktop\\123.txt";
                using (StreamWriter writer = new StreamWriter(tempPath))
                {
                    writer.WriteLine("ONStart"+ ex.Message.ToString() + "  \n");
                }
            }
        }

        public void working()
        {
            try
            {
                String _configPath = ConfigurationManager.AppSettings["Path"].ToString();
                String datePick = DateTime.Now.Date.ToString("yyyy_MM_dd");
                string _path = _configPath + datePick + ".xml";
               // string PathToSaveData = ConfigurationSettings.AppSettings["PathToSaveData"];

                //trying to read XML

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(_path);
                string tempPath = "C:\\Users\\Bilal\\Desktop\\123.txt";

                foreach (XmlNode node in xmlDocument.DocumentElement)
                {
                    string name = node.Attributes[0].InnerText;
                    string age = node.Attributes[1].InnerText;
                    string gender = node.Attributes[2].InnerText;
                    string email = node.Attributes[3].InnerText;
                    using (StreamWriter writer = new StreamWriter(tempPath))
                    {
                        writer.WriteLine(name + "  \n");
                        writer.WriteLine(email + "  \n");
                        writer.WriteLine(gender + "  \n");
                        writer.WriteLine(age + "  \n");

                        foreach (XmlNode child in node.ChildNodes)
                        {
                            writer.WriteLine(child.InnerText + "  \n");
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                string tempPath = "C:\\Users\\Bilal\\Desktop\\123.txt";
                using (StreamWriter writer = new StreamWriter(tempPath))
                {
                    writer.WriteLine("Inside Method "+exception.Message.ToString() + "  \n");
                }
            }


            Thread.Sleep(30000);
        }

        protected override void OnStop()
        {
            try
            {
                if (WorkerThread != null && WorkerThread.IsAlive)
                {
                    WorkerThread.Abort();
                }
            }
            catch (Exception ex)
            {
                string tempPath = "C:\\Users\\Bilal\\Desktop\\123.txt";
                using (StreamWriter writer = new StreamWriter(tempPath))
                {
                    writer.WriteLine("ONStop "+ex.Message.ToString() + "  \n");
                }
            }
        }

        private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
        }

        private void FileCreationifNotExists(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }
        }
    }
}
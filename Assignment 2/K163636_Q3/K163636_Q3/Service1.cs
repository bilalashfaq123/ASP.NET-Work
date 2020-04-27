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
using System.Threading.Tasks;
using System.Timers;
using System.Xml;
using Newtonsoft.Json;

namespace K163636_Q3
{
    public partial class Service1 : ServiceBase
    {
        System.Timers.Timer timer = new System.Timers.Timer();

        private int _timerValue = Convert.ToInt32(value: ConfigurationSettings.AppSettings["_timerLimit"]);

        public Service1()
        {
            InitializeComponent();
        }

        public void OnDebugMode()
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
                WorkingInService();
            }
        }


        public void WorkingInService()
        {
            List<string> sList = GetDirectoryInformation();

            foreach (var dir in sList)
            {
                string _path = "G:\\Users\\" + dir + "\\User-Detail\\heart_rate-" +
                               DateTime.Now.ToString("YYYY-MM-DD") + ".json";
                List<MedicalRecord> medicalRecords = null;
                if (File.Exists(_path))
                {
                    var json = File.ReadAllText(_path);
                    medicalRecords = JsonConvert.DeserializeObject<List<MedicalRecord>>(json);
                    Console.WriteLine(medicalRecords.Count + " Count");
                }
                string savingPath = "G:\\Users\\" + dir + "\\User-Detail\\Complete_heart_rate.json";
                MedicalRecordAdd(medicalRecords, savingPath);
            }
        }
        void MedicalRecordAdd(List<MedicalRecord> medicalRecordsList, string pathToTheFile)
        {
            FileCreationifNotExists(pathToTheFile);
            var json = File.ReadAllText(pathToTheFile);

            var medicalRecords = JsonConvert.DeserializeObject<List<MedicalRecord>>(json);

            List<MedicalRecord> newmedicalRecords =
                medicalRecords != null ? medicalRecords.Distinct().ToList() : new List<MedicalRecord>();

            foreach (var medicalRecord in medicalRecordsList)
            {
                newmedicalRecords.Add(medicalRecord);
            }

            File.WriteAllText(pathToTheFile, JsonConvert.SerializeObject(newmedicalRecords.Distinct().ToList()));
        }

        private void FileCreationifNotExists(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }
        }

        public List<string> GetDirectoryInformation()
        {
            string dirPath = ConfigurationSettings.AppSettings["Path"].ToString();
            var dirName = new DirectoryInfo(dirPath).GetDirectories();
            List<string> sList = new List<string>();
            foreach (var dir in dirName)
            {
                sList.Add(dir.Name);
            }

            return sList;
        }



        //wont need it, because better solution is to read all directory names
        public void ReadingNamesOfPatients()
        {
            try
            {
                String _configPath = ConfigurationManager.AppSettings["Path"].ToString();
                String datePick = DateTime.Now.Date.ToString("yyyy_MM_dd");
                string _path = _configPath + datePick + ".xml";


                //trying to read XML

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(_path);

                List<String> patientsNames = new List<String>();

                foreach (XmlNode node in xmlDocument.DocumentElement)
                {
                    string name = node.Attributes[0].InnerText.ToString();
                    using (StreamWriter writer = File.AppendText("C:\\Users\\Bilal\\Desktop\\Q3_logs"))
                    {
                        writer.WriteLine(name);
                    }
                }
            }
            catch (Exception exception)
            {
                string tempPath = "C:\\Users\\Bilal\\Desktop\\Q3_logs";
                using (StreamWriter writer = File.AppendText(tempPath))
                {
                    writer.WriteLine("Inside Method " + exception.Message.ToString() + "  \n");
                }
            }
        }
    }
}
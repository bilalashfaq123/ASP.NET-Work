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
using System.Xml.Linq;
using Newtonsoft.Json;

namespace K163636_Q4a
{
    public partial class Service1 : ServiceBase
    {
        System.Timers.Timer timer = new System.Timers.Timer();
        private int _timerValue = Convert.ToInt32(value: ConfigurationSettings.AppSettings["_timerLimit"]);
        private static string _rootElement;
        public Service1()
        {
            InitializeComponent();
            _rootElement = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<Users>\r\n \r\n</Users>";
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

        public  void WorkingInService()
        {
            List<string> sList = GetDirectoryInformation();

            foreach (var dir in sList)
            {
                string _TempPath = ConfigurationSettings.AppSettings["Path"].ToString();
                string _path = _TempPath + dir + "\\User-Detail\\Complete_heart_rate.json";
                List<MedicalRecord> medicalRecords = null;
                if (File.Exists(_path))
                {
                    var json = File.ReadAllText(_path);
                    medicalRecords = JsonConvert.DeserializeObject<List<MedicalRecord>>(json);
                    Console.WriteLine(medicalRecords.Count + " Count");
                }
                //we need to read a patient info as well
                //
                string pathForPatient = _TempPath + dir + "\\User-Profile\\User-Profile.json";
                var json1 = File.ReadAllText(pathForPatient);
                var patient = JsonConvert.DeserializeObject<Patient>(json1);

                CreateUserChartXml(dir, medicalRecords,patient);
            }
            CreateConsolidatedChart();
        }

        private  void CreateConsolidatedChart()
        {
            string _TempPath = ConfigurationSettings.AppSettings["Path"].ToString();
            string path = _TempPath+"ConsolidatedChart.xml";
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();

                using (TextWriter tw = new StreamWriter(path))
                {
                    tw.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<Patients>\r\n \r\n</Patients>");
                }
            }
            XDocument doc = XDocument.Load(path);
            XElement school = doc.Element("Patients");
            int value = 0;
            for (int i = 0; i < 8; i++)
            {
                school.Add(new XElement("AgeGroup",
                    new XAttribute("Value", i + 1),
                    new XElement("High", value + 10),
                    new XElement("average", 0),
                    new XElement("low", value)
                ));
                value += 10;
            }
            doc.Save(path);
        }

        private void CreateUserChartXml(string dir, List<MedicalRecord> list,Patient patient)
        {
            string _TempPath = ConfigurationSettings.AppSettings["Path"].ToString();
            int highestHeartRate = 0;
            int lowestHeartRate = 220;
            int sum = 0;
            foreach (var record in list)
            {
                sum += record.HeartRate;
                if (highestHeartRate < record.HeartRate)
                    highestHeartRate = record.HeartRate;
                if (lowestHeartRate > record.HeartRate)
                    lowestHeartRate = record.HeartRate;
            }

            int averageHeartRate = sum / list.Count;
            int range = 0;

            string pathToSaveData = _TempPath +"UserChart.xml";
            saveXML(pathToSaveData, patient.Name,patient.Email, lowestHeartRate, highestHeartRate, averageHeartRate, range);
        }


        public  List<string> GetDirectoryInformation()
        {
            string _TempPath = ConfigurationSettings.AppSettings["Path"].ToString();
            var dirName = new DirectoryInfo(_TempPath).GetDirectories();
            List<string> sList = new List<string>();
            foreach (var dir in dirName)
            {
                sList.Add(dir.Name);
            }

            return sList;
        }

        private void FileCreationifNotExists(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();

                using (TextWriter tw = new StreamWriter(path))
                {
                    tw.WriteLine(_rootElement);
                }
            }
        }

        private void saveXML(String path, string name,string email, int low, int high, int avg, int range)
        {

            FileCreationifNotExists(path);
            XDocument doc = XDocument.Load(path);
            XElement school = doc.Element("Users");
            school.Add(new XElement("User",
                new XAttribute("name", name),
                new XAttribute("email", email),
                new XElement("High", high),
                new XElement("average", avg),
                new XElement("low", low),
                new XElement("Range", range)
            ));
            doc.Save(path);
        }

    }
}

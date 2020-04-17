using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.ServiceProcess;
using System.Timers;
using System.Xml;
using K163636_Q2;

namespace K163636_Q2
{
    public partial class Service1 : ServiceBase
    {
        System.Timers.Timer timer = new System.Timers.Timer();

        private int _timerValue = Convert.ToInt32(ConfigurationSettings.AppSettings["_timerLimit"]);

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
            timer.Elapsed += new ElapsedEventHandler(timer1_Elapsed_1);
            timer.Interval = 1000; // 1000 ms => 1 second
            timer.Enabled = true;
        }

        public void Working()
        {
            try
            {
                String _configPath = ConfigurationManager.AppSettings["Path"].ToString();
                String datePick = DateTime.Now.Date.ToString("yyyy_MM_dd");
                string _path = _configPath + datePick + ".xml";
                

                //trying to read XML

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(_path);
                string tempPath = "C:\\Users\\Bilal\\Desktop\\123.txt";
                List<Patient> patients = new List<Patient>();

                foreach (XmlNode node in xmlDocument.DocumentElement)
                {
                    Patient patient = new Patient(node.Attributes[0].InnerText,Convert.ToDateTime(node.Attributes[1].InnerText), node.Attributes[3].InnerText,node.Attributes[2].InnerText);

                    using (StreamWriter writer = new StreamWriter(tempPath))
                    {
                        List<string> tempList = new List<string>();
                        foreach (XmlNode child in node.ChildNodes)
                        {
                            writer.WriteLine(child.InnerText + "  \n");
                            tempList.Add(child.InnerText);
                        }
                        MedicalRecord medicalRecord = new MedicalRecord(heartRate: Convert.ToInt32(tempList[0]),confidence: Convert.ToInt32(tempList[2]),time: Convert.ToInt64(tempList[1]));
                        patient.MedicalRecord = medicalRecord;
                        writer.Write(DateTime.Now.ToString("T"));
                    }
                    patients.Add(patient);
                    DataDistribution(patients);
                }
            }
            catch (Exception exception)
            {
                string tempPath = "C:\\Users\\Bilal\\Desktop\\123.txt";
                using (StreamWriter writer = new StreamWriter(tempPath))
                {
                    writer.WriteLine("Inside Method " + exception.Message.ToString() + "  \n");
                }
            }
        }

        protected override void OnStop()
        {
            timer.Enabled = false;
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

        private int lastminute = -1;

        private void timer1_Elapsed_1(object sender, System.Timers.ElapsedEventArgs e)
        {
            var curTime = DateTime.Now; // Get current time
            if (lastminute < curTime.Minute) // If now 5 min of any hour
            {
                lastminute = curTime.Minute + _timerValue;
                Working();
            }
        }



        //main work of service
        //till now, only xml is read and data is stored in list
        private void DataDistribution(List<Patient> patients)
        {
            string pathToSaveData = ConfigurationSettings.AppSettings["PathToSaveData"].ToString();
            foreach (var patient in patients)
            {
                string _path = pathToSaveData + "\\"+ patient.Name;
                System.IO.Directory.CreateDirectory(_path);
                string _userProfile = _path + "\\" + "User-Profile";
                string _userDetail = _path + "\\" + "User-Detail";
                System.IO.Directory.CreateDirectory(_userProfile);
                System.IO.Directory.CreateDirectory(_userDetail);
                
                //writing into User Profiling
                //Person person = new Person(patient.getName(),patient.getDateofBirth(),patient.getEmail(),patient.getGender());
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(patient);
                FileCreationifNotExists(_userProfile+ "\\User-Profile.json");
                using (StreamWriter writer = new StreamWriter(_userProfile + "\\User-Profile.json"))
                {
                    writer.WriteLine(json);
                }

                //writing into user Details
                MedicalRecord tempRecord = patient.MedicalRecord;
                var jsonUser = Newtonsoft.Json.JsonConvert.SerializeObject(tempRecord);
              //  FileCreationifNotExists(_userProfile + "\\User-Profile.json");
                using (StreamWriter writer = new StreamWriter(_userDetail + "\\heart_rate-" +DateTime.Now.ToString("YYYY-MM-DD")+".json"))
                {
                    writer.WriteLine(jsonUser);
                }
            }
        }
    }
}
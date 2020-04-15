using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace K163636_Q1
{
    public partial class Form1 : Form
    {
        private readonly String _rootElement;

        public Form1()
        {
            InitializeComponent();
            _rootElement = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<Patients>\r\n \r\n</Patients>";
            String configPath = System.Configuration.ConfigurationManager.AppSettings["Path"].ToString();
            String datePick = DateTime.Now.Date.ToString("yyyy_MM_dd");
            string path = configPath + datePick + ".xml";

            try
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
            catch (FileNotFoundException)
            {
                MessageBox.Show("Please Check Path defined in App.Config");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.ToString());
            }
        }
    

        private void button1_Click(object sender, EventArgs e)
        {
            String datePick = DateTime.Now.Date.ToString("yyyy_MM_dd");
            //string newString = datePick.Replace("/", "_");
            //  MessageBox.Show(datePick);

            String configPath = System.Configuration.ConfigurationManager.AppSettings["Path"].ToString();
            ;
            string path = configPath + datePick + ".xml";

            if (!File.Exists(path))
            {
                File.Create(path).Dispose();

                using (TextWriter tw = new StreamWriter(path))
                {
                    tw.WriteLine(_rootElement);
                }
            }
            else if (File.Exists(path))
            {
                XDocument doc = XDocument.Load(path);
                XElement school = doc.Element("Patients");
                school.Add(new XElement("Patient",
                    new XAttribute("name", "David"),
                    new XAttribute("age", "10"),
                    new XAttribute("gender", "male"),
                    new XAttribute("email", "bilal75210"),
                    new XElement("bpm", "10"),
                    new XElement("time", "113210"),
                    new XElement("Confidence", "0")
                ));
                doc.Save(path);
            }

            MessageBox.Show("Done");
        }
    }
}
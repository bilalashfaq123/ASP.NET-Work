﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (!formValidation())
            {
                return;
            }

            String gender = "";
            if (radioButton1.Checked)
            {
                gender = "male";
            }
            else if (radioButton2.Checked)
            {
                gender = "female";
            }

            Patient patient = new Patient(pName.Text.ToString(), dateTimePicker1.Value, gender, emailBox.Text.ToLower().ToString());
            MedicalRecord _medicalRecord = new MedicalRecord(Convert.ToInt32(pHeartRate.Text));
            patient._MedicalRecord = _medicalRecord;
            String datePick = DateTime.Now.Date.ToString("yyyy_MM_dd");

            String configPath = System.Configuration.ConfigurationManager.AppSettings["Path"].ToString();

            string path = configPath + datePick + ".xml";

            FileCreationifNotExists(path);
            saveXML(path, patient);

            MessageBox.Show("Record Saved Successfully");
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

        private void saveXML(String path, Patient patient)
        {
            XDocument doc = XDocument.Load(path);
            XElement school = doc.Element("Patients");
            school.Add(new XElement("Patient",
                new XAttribute("name", patient.PatientName),
                new XAttribute("DateOfBirth", patient.DateofBirth),
                new XAttribute("gender", patient.Gender),
                new XAttribute("email", patient.Email),
                new XElement("bpm", patient._MedicalRecord.heartRate),
                new XElement("time", patient._MedicalRecord.time),
                new XElement("Confidence", "0")
            ));
            doc.Save(path);
        }

        public bool formValidation()
        {
            string emailPattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$"; // Email address pattern
            string Name = "^[a - z,.'-]+$";
            string heartrate = "^[0-9]*$";


            bool isEmailValid = Regex.IsMatch(emailBox.Text, emailPattern);
            bool isNameValid = Regex.IsMatch(pName.Text, Name);
            bool isHeartRateValid = Regex.IsMatch(pHeartRate.Text, heartrate);

            if (!isEmailValid || emailBox.Text == "")
            {
                MessageBox.Show("Please Enter a Valid Email");
                return false;
            }

            if (pName.Text == "")
            {
                MessageBox.Show("Please Enter a Valid Name");
                return false;
            }

            if (!isHeartRateValid || pHeartRate.Text == "")
            {
                MessageBox.Show("Please Enter a Valid HeartRate");
                return false;
            }

            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("Please Select Gender");
                return false;
            }

            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coming in Future Versions. Stay Tuned!!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coming in Future Versions. Stay Tuned!!");
        }
    }
}
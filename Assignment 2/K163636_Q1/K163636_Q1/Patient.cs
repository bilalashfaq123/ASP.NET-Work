using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace K163636_Q1
{
    [Serializable]
    [XmlRoot]
    public class Patient
    {
        [XmlAttribute]
        public String PatientName{ get; set; }
        [XmlAttribute]
        public int Age{ get; set; }
        [XmlAttribute]
        public String Email { get; set; }

        //1 for male, 0 for female
        [XmlAttribute]
        public string Gender { get; set; }

        [XmlElement]
        public int heartRate{ get; set; }
        [XmlElement]
        public int Confidence { get; set; }
        [XmlElement]
        public long time{ get; set; }

        public Patient(string patientName, DateTime dateofBirth, string gender, int heartRate,String email)
        {
            PatientName = patientName;
            this.Age = 123;//Convert.ToInt32(DateTime.Now - dateofBirth);
            Gender = gender;
            this.heartRate = heartRate;
            this.Email = email;
            //til uploading through this UI
            Confidence = 0;
            time = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
        }

        public Patient()
        {
        }
    }
}

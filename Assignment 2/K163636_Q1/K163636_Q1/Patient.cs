using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace K163636_Q1
{
    public class Patient
    {
        public String PatientName{ get; set; }
    
        public DateTime DateofBirth{ get; set; }
        public String Email { get; set; }

       
        public string Gender { get; set; }

        public MedicalRecord _MedicalRecord { get; set; }
        


        public Patient(string patientName, DateTime dateofBirth, string gender,String email)
        {
            PatientName = patientName;
            this.DateofBirth = dateofBirth;//Convert.ToInt32(DateTime.Now - dateofBirth);
            Gender = gender;
            this.Email = email;
            //til uploading through this UI
        }

        public Patient()
        {
            _MedicalRecord = new MedicalRecord();
        }
    }

    public class MedicalRecord
    {
        public int heartRate { get; set; }

        public int Confidence { get; set; }

        public long time { get; set; }

        public MedicalRecord(int heartRate)
        {
            this.heartRate = heartRate;
            Confidence = 0;
            this.time = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
        }

        public MedicalRecord()
        {
            Confidence = 0;
            this.time = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
        }
    }
}

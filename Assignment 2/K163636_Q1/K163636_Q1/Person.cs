using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace K163636_Q1
{
    [Serializable]
    class Person
    {
        public String PatientName{ get; set; }
        public DateTime DateofBirth { get; set; }

        //1 for male, 0 for female
        public bool Gender { get; set; }
        public int hearRate{ get; set; }
        public int Confidence { get; set; }
        public long time{ get; set; }

        public Person(string patientName, DateTime dateofBirth, bool gender, int hearRate)
        {
            PatientName = patientName;
            DateofBirth = dateofBirth;
            Gender = gender;
            this.hearRate = hearRate;

            //til uploading through this UI
            Confidence = 0;
            time = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
        }
    }
}

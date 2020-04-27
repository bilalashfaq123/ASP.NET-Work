using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K163636_Q3
{
    [Serializable]
    internal class Patient
    {
        public String Name { get; set; }

        public DateTime DateofBirth { get; set; }

        public String Email { get; set; }

        //1 for male, 0 for female
        public string Gender { get; set; }

        public MedicalRecord MedicalRecord { get; set; }
        public Patient(string Name, DateTime dateofBirth, string email, string gender)
        {
            this.Name = Name;
            DateofBirth = dateofBirth;
            Email = email;
            Gender = gender;
        }

    }


    [Serializable]
    internal class MedicalRecord
    {
        public int heartRate { get; set; }

        public int Confidence { get; set; }

        public long time { get; set; }


        public MedicalRecord(int heartRate, int confidence, long time)
        {
            this.heartRate = heartRate;
            Confidence = confidence;
            this.time = time;
        }
    }
}
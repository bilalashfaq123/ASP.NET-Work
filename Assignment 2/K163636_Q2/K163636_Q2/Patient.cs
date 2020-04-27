using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json;

namespace K163636_Q2
{
    [Serializable]
    internal class Patient
    {
        public String Name { get; set; }

        public DateTime DateofBirth { get; set; }

        public String Email { get; set; }

        //1 for male, 0 for female
        public string Gender { get; set; }

        [JsonIgnore]
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
    internal class MedicalRecord:IEquatable<MedicalRecord>
    {
        
        public long DateTime { get; set; }

        [JsonIgnore]
        public int Confidence { get; set; }
        [JsonIgnore]
        public int HeartRate { get; set; }


        [JsonProperty("value")]
        private Dictionary<String, int> value { get; set; }
        [OnSerializing]
        internal void OnSerializing(StreamingContext context)
        {
            value = new Dictionary<string, int>();
            value.Add("Confidence", 0);
            value.Add("bpm", HeartRate);

        }

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            Confidence = value["Confidence"];
            HeartRate = value["bpm"];
        }



        public long getDayTime()
        {
            return this.DateTime;
        }


        public MedicalRecord(int heartRate,int confidence, long time)
        {
            this.Confidence = confidence;
            this.HeartRate = heartRate;
            this.DateTime = time;
        }


        public bool Equals(MedicalRecord other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return DateTime == other.DateTime;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((MedicalRecord) obj);
        }

        public override int GetHashCode()
        {
            return DateTime.GetHashCode();
        }
    }
}
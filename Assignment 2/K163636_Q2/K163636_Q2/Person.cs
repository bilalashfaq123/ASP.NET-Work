using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace K163636_Q2
{
    [Serializable]
    internal class Person
    {
        public String Name { get; set; }

        public DateTime DateofBirth { get; set; }

        public String Email { get; set; }

        //1 for male, 0 for female
        public string Gender { get; set; }

        public Person(string Name, DateTime dateofBirth, string email, string gender)
        {
            this.Name = Name;
            DateofBirth = dateofBirth;
            Email = email;
            Gender = gender;
        }

        #region Getters
        public string getName()
        {
            return Name;
        }

        public DateTime getDateofBirth()
        {
            return DateofBirth;
        }

        public string getGender()
        {
            return Gender;
        }

        public string getEmail()
        {
            return Email;
        }
        #endregion
    }

    internal class UserPatient : Person
    {
        public int heartRate { get; set; }
        public int Confidence { get; set; }
        public long time { get; set; }

        public UserPatient(string Name, DateTime dateofBirth, string email, string gender, int heartRate, int confidence, long time) : base(Name, dateofBirth, email, gender)
        {
            this.heartRate = heartRate;
            Confidence = confidence;
            this.time = time;
        }

        public UserPatient(string Name, DateTime dateofBirth, string email, string gender) : base(Name, dateofBirth, email, gender)
        {
        }

        #region ParentClassGetters
        public string GetUserName()
        {
            return getName();
        }

        public string GetUserEmail()
        {
            return getEmail();
        }

        public DateTime GetUserDateofBirth()
        {
            return getDateofBirth();
        }

        public string GetUserGender()
        {
            return getGender();
        }
        #endregion

    }
}

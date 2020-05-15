using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace K163636_Q1.Models
{
    [Serializable]
    public class Course
    {
        public int CourseCode { get; set; }
        public string CourseName { get; set; }
        public int NumberOfStudentsEnrolled  { get; set; }
        public int CreditHours { get; set; }
        public string Description { get; set; }

        public Course(int courseCode, string courseName, int numberOfStudentsEnrolled, int creditHours,string description)
        {
            CourseCode = courseCode;
            CourseName = courseName;
            NumberOfStudentsEnrolled = numberOfStudentsEnrolled;
            CreditHours = creditHours;
            this.Description = description;
        }
    }
}
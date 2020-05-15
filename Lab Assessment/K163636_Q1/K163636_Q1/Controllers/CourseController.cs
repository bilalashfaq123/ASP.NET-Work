using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using K163636_Q1.Models;

namespace K163636_Q1.Controllers
{
    public class CourseController : ApiController
    {
        List<Course> Courses = new List<Course>
        {
            new Course(105,"English 3",113,3,"Something"),
            new Course(106,"English 4",15,3,"Something"),
            new Course(107,"English 5",38,3,"Something"),
            new Course(108,"English 6",52,3,"Something"),
            new Course(109,"English 7",72,3,"Something"),
            new Course(110,"English 8",12,3,"Something"),
        };

        [System.Web.Http.HttpGet]
        public IEnumerable<Course> GetCourses()
        {
            return Courses;
        }

        /*public Course GetCourse(string id)
        {
            return Courses.Where(item => item.CourseCode == id).FirstOrDefault();
        }*/

        public Course GetCourseDescription(int id)
        {
            return Courses.FirstOrDefault(item => item.CourseCode == id);
        }

        public IEnumerable<Course> GetCorusesLessThanThreshold(int students)
        {
            return Courses.Where(item => item.NumberOfStudentsEnrolled < students);
        }

        public void RemoveCourse(int id)
        {
            try
            {
                Courses.Remove(Courses.Where(item => item.CourseCode == id).FirstOrDefault());
            }
            catch (Exception e)
            {
                
            }
        }

    }
}
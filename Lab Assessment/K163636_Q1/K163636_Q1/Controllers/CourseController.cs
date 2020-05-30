using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Firebase.Storage;
using K163636_Q1.Models;

namespace K163636_Q1.Controllers
{
    public class CourseController : ApiController
    {


        public async Task<string> GetFileUpload()
        {
            var stream = new FileStream("C:\\Users\\Bilal\\Desktop\\Zoom Meeting.png", FileMode.Open);

            // Construct FirebaseStorage with path to where you want to upload the file and put it there
            var task = new FirebaseStorage("xdadeveloperes.appspot.com")
                .Child("data")
                .Child("random")
                .Child("file.png")
                .PutAsync(stream);

            // Await the task to wait until upload is completed and get the download url

            var downloadurl = await task;
            return downloadurl;
        }
        public async Task<string> GetFileUpload(string id)
        {
            var stream = new FileStream(id, FileMode.Open);

            // Construct FirebaseStorage with path to where you want to upload the file and put it there
            var task = new FirebaseStorage("xdadeveloperes.appspot.com")
                .Child("data")
                .Child("random")
                .Child("file.png")
                .PutAsync(stream);

            // Await the task to wait until upload is completed and get the download url

            var downloadurl = await task;
            return downloadurl;
        }


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

        [System.Web.Http.HttpPost]
        public void RemoveCourse(int id)
        {
            try
            {
                bool flag= Courses.Remove(Courses.FirstOrDefault(item => item.CourseCode == id));
                ModelState.AddModelError(string.Empty, flag.ToString());
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
            }
        }

    }
}
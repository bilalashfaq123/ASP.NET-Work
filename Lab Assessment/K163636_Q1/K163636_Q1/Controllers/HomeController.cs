using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace K163636_Q1.Controllers
{
    public class HomeController : Controller
    {
        HttpClient httpClient = new HttpClient();
        string baseUrl = "http://localhost:50284/";
        
        public ActionResult Index()
        {
            string path = "C:\\Users\\Bilal\\Desktop\\123.jpg";
            HttpResponseMessage response = httpClient.GetAsync(baseUrl + "api2/Course/GetFileUpload?id="+path).Result;
            string stateInfo = "";
            if (response.IsSuccessStatusCode)
            {
                stateInfo = response.Content.ReadAsStringAsync().Result;
            }
            ViewBag.Title =  "Bilal";
            ViewBag.State = stateInfo;
            return View();
        }

    }
}

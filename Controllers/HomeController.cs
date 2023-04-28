using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dashboard.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            
            ViewData["tempVal1"] =DashboardApiController.Temp1;
            ViewData["tempVal2"] = DashboardApiController.Temp2;
            ViewData["tempVal3"] = DashboardApiController.Temp3;

            ViewData["humVal1"] = DashboardApiController.Hum1;
            ViewData["humVal2"] = DashboardApiController.Hum2;
            ViewData["humVal3"] = DashboardApiController.Hum3;

            return View();
        }
        public ActionResult Dashboard()
        {
            //ViewBag.Title = "Home Page";

            ViewData["tempVal1"] = DashboardApiController.Temp1;
            ViewData["tempVal2"] = DashboardApiController.Temp2;
            ViewData["tempVal3"] = DashboardApiController.Temp3;

            ViewData["humVal1"] = DashboardApiController.Hum1;
            ViewData["humVal2"] = DashboardApiController.Hum2;
            ViewData["humVal3"] = DashboardApiController.Hum3;

            return View();
        }

       
        public string Get(string id)
        {
            string valueApi = id.ToString();
            return "New Value 1 :" + valueApi;
        }
        public string Get2(string id)
        {
            string valueApi = id.ToString();
            return "New Value get 2 :" + valueApi;
        }
    }
}

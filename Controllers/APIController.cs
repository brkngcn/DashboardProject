using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dashboard.Controllers
{
    public class DashboardApiController : Controller
    {
        string className = "APIController";

        public static string Temp1 = "Empty";
        public static string Temp2 = "Empty";
        public static string Temp3 = "Empty";

        public static string Hum1 = "-";
        public static string Hum2 = "-";
        public static string Hum3 = "-";

        public static int Max1 = 0;
        public static int Max2 = 0;
        public static int Max3 = 0;

        public static int Min1 = 0;
        public static int Min2 = 0;
        public static int Min3 = 0;

        static int temp1Count = 0;
        static int temp2Count = 0;
        static int temp3Count = 0;

        static int tempIteration = 0;
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }

        // GET: Dashboard/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //https://localhost:44370/dashboardapi/GetRealTimeValue
        public JsonResult GetRealTimeValue()
        {
            JsonResult jsonReturn = null;
            try
            {
                List<Models.Device> devicesValuesList = new List<Models.Device>();
                Models.Device dvc1 = new Models.Device();
                dvc1.deviceID = "C01A";
                dvc1.tempVal = Temp1;
                dvc1.humVal = Hum1;
                devicesValuesList.Add(dvc1);
                Models.Device dvc2 = new Models.Device();
                dvc2.deviceID = "C01B";
                dvc2.tempVal = Temp2;
                dvc2.humVal = Hum2;
                devicesValuesList.Add(dvc2);
                Models.Device dvc3 = new Models.Device();
                dvc3.deviceID = "C01C";
                dvc3.tempVal = Temp3;
                dvc3.humVal = Hum3;
                devicesValuesList.Add(dvc3);

                jsonReturn = Json(
                    new
                    {
                        Result = from obj in devicesValuesList
                                 select new
                                 {
                                     obj.deviceID,
                                     obj.tempVal,
                                     obj.humVal
                                     
                                 }
                    }, JsonRequestBehavior.AllowGet
                    );
            }
            catch (Exception)
            {
                throw;
                
            }
            return jsonReturn;
        }

        //https://localhost:44370/dashboardapi/SendDataToServer?deviceName=C01A&temp=5&hum=90
        public string SendDataToServer(string deviceName, string temp, string hum)
        {
            string metodName = "SendDataToServer";

            if (deviceName=="C01A")
            {
                Hum1 = hum;
                if (temp1Count>=tempIteration)
                {
                    Temp1 = Dashboard.Models.ProcessLayer.findAverageTemp1(temp);
                    Logger.Instance().LogWrite($"{className} > {metodName} : Received data from {deviceName} , Temp:{temp} , Hum:{hum} | Average Temp: {Temp1} | List1 Count:{Dashboard.Models.ProcessLayer.temperatureList1.Count()} | List1 Last Item:{Dashboard.Models.ProcessLayer.temperatureList1.Last()} | List1 First Item:{Dashboard.Models.ProcessLayer.temperatureList1.First()}", Logger.LogType.Info);
                    temp1Count = 0;

                    if (Max1< double.Parse(Temp1, System.Globalization.CultureInfo.InvariantCulture))
                    {
                        //Max1=Temp1
                    }
                }
                else
                {
                    Logger.Instance().LogWrite($"{className} > {metodName} : (WILL NOT BE CALCULATED) Received data from {deviceName} , Temp:{temp} , Hum:{hum}", Logger.LogType.Warning);
                }
                temp1Count++;
            }
            if (deviceName == "C01B")
            {
                Hum2 = hum;
                if (temp2Count >= tempIteration)
                {
                    Temp2 = Dashboard.Models.ProcessLayer.findAverageTemp2(temp); ;
                    Logger.Instance().LogWrite($"{className} > {metodName} : Received data from {deviceName} , Temp:{temp} , Hum:{hum} | Average Temp: {Temp2} | List2 Count:{Dashboard.Models.ProcessLayer.temperatureList2.Count()} | List2 Last Item:{Dashboard.Models.ProcessLayer.temperatureList2.Last()} | List2 First Item:{Dashboard.Models.ProcessLayer.temperatureList2.First()}", Logger.LogType.Info);
                    temp2Count = 0;
                }
                else
                {
                    Logger.Instance().LogWrite($"{className} > {metodName} : (WILL NOT BE CALCULATED) Received data from {deviceName} , Temp:{temp} , Hum:{hum}", Logger.LogType.Warning);
                }
                temp2Count++;
            }
            if (deviceName == "C01C")
            {
                Hum3 = hum;
                if (temp3Count >= tempIteration)
                {
                    Temp3 = Dashboard.Models.ProcessLayer.findAverageTemp3(temp);
                    Logger.Instance().LogWrite($"{className} > {metodName} : Received data from {deviceName} , Temp:{temp} , Hum:{hum} | Average Temp: {Temp3} | List3 Count:{Dashboard.Models.ProcessLayer.temperatureList3.Count()} | List3 Last Item:{Dashboard.Models.ProcessLayer.temperatureList3.Last()} | List3 First Item:{Dashboard.Models.ProcessLayer.temperatureList3.First()}", Logger.LogType.Info);
                    temp3Count = 0;
                }
                else
                {
                    Logger.Instance().LogWrite($"{className} > {metodName} : (WILL NOT BE CALCULATED) Received data from {deviceName} , Temp:{temp} , Hum:{hum}", Logger.LogType.Warning);
                }
                temp3Count++;
            }
            return "200 OK";
        }
        // GET: Dashboard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dashboard/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Dashboard/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Dashboard/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Dashboard/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Dashboard/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dashboard.Models
{
    public class ProcessLayer
    {
        string className = "ProcessLayer";

        static int maxTempAverage = 2;
       public static List<Double> temperatureList1 = new List<Double>();
       public static List<Double> temperatureList2 = new List<Double>();
       public static List<Double> temperatureList3 = new List<Double>();

        static public string findAverageTemp1(string valueofTemp)
        {
            string metodName = "findAverageTemp1";

            valueofTemp = valueofTemp.Replace(',','.');
            temperatureList1.Add(double.Parse(valueofTemp, System.Globalization.CultureInfo.InvariantCulture));
            
            if (temperatureList1.Count < maxTempAverage)
            {
                double tempAverage = temperatureList1.Average();
                double roundResult = Math.Round(tempAverage,2);
                return roundResult.ToString();
            }
            else
            {
                temperatureList1.RemoveAt(0);
                double tempAverage = temperatureList1.Average();
                double roundResult = Math.Round(tempAverage,2);
                return roundResult.ToString();
            }


        }
        static public string findAverageTemp2(string valueofTemp)
        {
            string metodName = "findAverageTemp2";

            valueofTemp = valueofTemp.Replace(',', '.');
            temperatureList2.Add(double.Parse(valueofTemp, System.Globalization.CultureInfo.InvariantCulture));

            if (temperatureList2.Count < maxTempAverage)
            {
                double tempAverage = temperatureList2.Average();
                double roundResult = Math.Round(tempAverage, 2);
                return roundResult.ToString();
            }
            else
            {
                temperatureList2.RemoveAt(0);
                double tempAverage = temperatureList2.Average();
                double roundResult = Math.Round(tempAverage, 2);
                return roundResult.ToString();
            }


        }
        static public string findAverageTemp3(string valueofTemp)
        {
            string metodName = "findAverageTemp3";

            valueofTemp = valueofTemp.Replace(',', '.');
            temperatureList3.Add(double.Parse(valueofTemp, System.Globalization.CultureInfo.InvariantCulture));

            if (temperatureList3.Count < maxTempAverage)
            {
                double tempAverage = temperatureList3.Average();
                double roundResult = Math.Round(tempAverage, 2);
                return roundResult.ToString();
            }
            else
            {
                temperatureList3.RemoveAt(0);
                double tempAverage = temperatureList3.Average();
                double roundResult = Math.Round(tempAverage, 2);
                return roundResult.ToString();
            }

        }
    }
}
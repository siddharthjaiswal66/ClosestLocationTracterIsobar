using ClosestLocationTracker.Areas.DistanceCalculator.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace ClosestLocationTracker.Areas.DistanceCalculator.Infrastructure
{
    public static class ReadLocation
    {
        public static StringBuilder Locations { get; set; }

        public static void init() {
            Locations = ReadLocationFromCSV();
            ApiHelper.InitializeGoogleClient();
            ApiHelper.intializeLocalInt();
        }
        //Read the CSV File to Get All the Location Pre Defined in the File
        public static StringBuilder ReadLocationFromCSV()
        {

            StringBuilder sb = new StringBuilder();
            try
            {
                //Reading the File Line By Line
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Constant.AssetFolder, ConfigurationManager.AppSettings["FilePath"]);
                using (StreamReader streamreader = new StreamReader(path))
                {
                    string address = null;
                    //Read until the end of the file is reached.                
                    while ((address = streamreader.ReadLine()) != null)
                    {
                        //Add Data to the List and cast it to the Location Details Option 
                        sb.Append(address+"|");
                    }
                }
                return sb;

            }
            catch (Exception)
            {
                throw new Exception("Error Reading File");
            }
        }

    }
}
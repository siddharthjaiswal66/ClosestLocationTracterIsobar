using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace ClosestLocationTracker.Areas.DistanceCalculator.Infrastructure
{
        public static class ApiHelper
        {
            public static HttpClient ApiClient { get; set; }

            public static WebClient webClient { get; set; }

        public static void InitializeGoogleClient()
            {
                ApiClient = new HttpClient();
                ApiClient.DefaultRequestHeaders.Accept.Clear();
                ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }

        public static void intializeLocalInt() {
            webClient = new WebClient();
            webClient.BaseAddress = "http://localhost:50726/api/Location";
        }
        public static string GenrateGoogleUrl() {
            return ConfigurationManager.AppSettings["GenrateGoogleUrl"] +"?origins={origin}&destinations={destination}&key="+ConfigurationManager.AppSettings["ApiKey"];
        }
    }
}
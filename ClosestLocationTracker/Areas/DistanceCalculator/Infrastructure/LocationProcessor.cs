using ClosestLocationTracker.Areas.DistanceCalculator.Models;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace ClosestLocationTracker.Areas.DistanceCalculator.Infrastructure
{
    public class LocationProcessor
    {
        readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public async Task<List<LocationViewModel>>  FindDistances(string origin)
        {
            String statuscode = string.Empty;
            List<LocationViewModel> locationDetails = null;
            StringBuilder PreCompliledDistance = new StringBuilder();
            if (string.IsNullOrEmpty(origin))
            {
                logger.Error("Invalid Origin Address");
                statuscode = "INVALID_ORIGIN_ADDRESS";
                return locationDetails;
            }
            else
            {
                //Get the Distance Between the two location from the Google API with the Personal Key
                //string uri = "https://maps.googleapis.com/maps/api/distancematrix/xml?origins=" + origin + "&destinations=" + destination + "&key=AIzaSyD8kbnC-LIVjdbx5H9UbTGYSu9hVDHuoKk";
                try
                {
                    
                    statuscode = "SOME_ERROR_OCCURED_IN_FILE_READING";
                    PreCompliledDistance = ReadLocation.Locations;
                    List<LocationViewModel> FinalLocationDetails = new List<LocationViewModel>();
                    string uri = ApiHelper.GenrateGoogleUrl().Replace("{origin}",origin).Replace("{destination}",PreCompliledDistance.ToString()); 
                        int count = 0;
                        using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(uri))
                        {
                            if (response.IsSuccessStatusCode)
                            {

                                LocationDetails result = await response.Content.ReadAsAsync<LocationDetails>();
                                foreach (var item in result.Rows.FirstOrDefault().Elements)
                                {
                                    if (item.Status == "OK")
                                    {
                                        FinalLocationDetails.Add(
                                                   new LocationViewModel()
                                                   {
                                                       Destination = result.Destination.ElementAt(count++),
                                                       Origin = result.Origin.FirstOrDefault(),
                                                       Distance = Convert.ToDouble(item.Distance.Text.Split(' ').FirstOrDefault())
                                                   });

                                    }
                                    else
                                    {
                                        logger.Error("Some Error Getting Distance for the Item" + result.Destination.ElementAt(count++));
                                    }
                                }
                            }
                            //logger.Info(Destination + "has the distance" + result.Rows.FirstOrDefault().Elements.FirstOrDefault().Distance.Text.Split(' ').FirstOrDefaul
                            else
                            {
                                logger.Error("Some Error Getting Distance for the Item");
                                throw new Exception(response.ReasonPhrase);
                            }

                        }
                    return FinalLocationDetails;
                }
                catch (Exception ex)
                {
                    logger.Error("Some Error From the Google API side");
                    if (String.IsNullOrEmpty(ex.Message))
                    {
                        throw new Exception("Error Fetching the Data");
                    }
                    else
                    {
                        throw ex;
                    }
                }
            }

        }


        public List<LocationViewModel> GetLocationsItems(string origin)
        {
           string uri = ApiHelper.webClient.BaseAddress+ "?origin=" + origin;
            try
            {
                using (WebClient webClient = ApiHelper.webClient)
                {
                    return JsonConvert.DeserializeObject<List<LocationViewModel>>(webClient.DownloadString(uri));
                }

            }
            catch (Exception ex)
            {
                if (String.IsNullOrEmpty(ex.Message))
                {
                    throw new Exception("Error Calling Location Service");
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }
        }

      }

    }
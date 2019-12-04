using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClosestLocationTracker.Areas.DistanceCalculator.Models
{
    public class LocationDetails 
    {
        [JsonProperty("origin_addresses")]
        public List<string> Origin { get; set; }

        [JsonProperty("destination_addresses")]
        public List<string> Destination { get; set; }

        [JsonProperty("rows")]
        public List<LocationModel> Rows { get; set; }

        [JsonProperty("status")]
        public string  Status { get; set; }
    }
}
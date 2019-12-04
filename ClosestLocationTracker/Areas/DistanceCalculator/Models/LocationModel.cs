using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClosestLocationTracker.Areas.DistanceCalculator.Models
{
    public class LocationModel
    {
        
        [JsonProperty("elements")] 
        public List<Elements> Elements { get; set; }
    }
}
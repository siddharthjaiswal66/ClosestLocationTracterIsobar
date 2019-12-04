using Newtonsoft.Json;
using System.Collections.Generic;

namespace ClosestLocationTracker.Areas.DistanceCalculator.Models
{
    public class Elements
    {


        [JsonProperty("distance")]
        public DistanceAttribute Distance { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
using Newtonsoft.Json;

namespace ClosestLocationTracker.Areas.DistanceCalculator.Models
{
    public class DistanceAttribute
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
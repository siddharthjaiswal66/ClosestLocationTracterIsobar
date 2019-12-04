using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClosestLocationTracker.Areas.DistanceCalculator.Models
{
    public class LocationViewModel
    {
        public string Origin { get; set; }

        public string Destination { get; set; }

        public double Distance { get; set; }
    }
}
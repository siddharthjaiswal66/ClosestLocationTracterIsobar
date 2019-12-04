using ClosestLocationTracker.Areas.DistanceCalculator.Infrastructure;
using ClosestLocationTracker.Areas.DistanceCalculator.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ClosestLocationTracker.Areas.DistanceCalculator.Controllers
{
    public class LocationController : ApiController
    {
        // GET: api/Location
        public async Task<IEnumerable<LocationViewModel>> Get(string origin)
        {
            return await new LocationProcessor().FindDistances(origin);

        }
    }
}

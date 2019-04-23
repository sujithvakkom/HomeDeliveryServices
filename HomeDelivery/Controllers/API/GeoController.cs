using DataProvider;
using DataProvider.Entities;
using HomeDelivery.Helpers;
using HomeDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HomeDelivery.Controllers.API
{
    public class GeoController : ApiController
    {
        //Post
        [HttpPost]
        public string PostUserLocation(List<LocationTracker> LocationTrackers)
        {
            string result = "Failed";
            using (SalesManageDataContext db = new SalesManageDataContext(AppConfigSettings.WebConfigConnectionSting("GSLSR")))
            {
                foreach (var loc in LocationTrackers)
                    result = db.PutUserLoction(loc);
            }
            return result;
        }
    }
}

using DataProvider;
using HomeDelivery.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HomeDelivery.Controllers.API
{
    public class RetailerInfoProviderController : ApiController
    {
        [HttpGet]
        public List<string> GetRetailer()
        {
            List<String> result = null;
            using (SalesManageDataContext db = new SalesManageDataContext(AppConfigSettings.WebConfigConnectionSting("GSLSR")))
            {
                result = db.getRetailers();
            }
            return result;
        }
    }
}
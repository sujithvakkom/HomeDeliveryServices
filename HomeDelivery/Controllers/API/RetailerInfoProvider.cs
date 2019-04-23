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
    public class RetailerInfoProvider : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
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
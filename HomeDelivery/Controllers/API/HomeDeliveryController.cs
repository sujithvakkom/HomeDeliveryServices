using DataProvider;
using DataProvider.Entities;
using HomeDelivery.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HomeDelivery.Controllers.API
{
    public class HomeDeliveryController : ApiController
    {
        [HttpGet()]
        public List<delivery> GetDelivery(string receipt, int status)
        {
            List<delivery> result = null;
            using (SalesManageDataContext db = new SalesManageDataContext(AppConfigSettings.WebConfigConnectionSting("GSLSR")))
            {
                result = db.GetDelivery(receipt, status, null);
            }
            return result;
        }
        [HttpGet]
        public List<delivery> GetDelivery(string receipt, int status, string driver)
        {
            List<delivery> result = null;
            using (SalesManageDataContext db = new SalesManageDataContext(AppConfigSettings.WebConfigConnectionSting("GSLSR")))
            {
                result = db.GetDelivery(receipt, status, driver);
            }
            return result;
        }

        [HttpPost]
        public string UpdateDelivery(string receipt, int status, string driver)
        {
            string result = null;
            using (SalesManageDataContext db = new SalesManageDataContext(AppConfigSettings.WebConfigConnectionSting("GSLSR")))
            {
                result = db.UpdateDelivery(receipt, status, driver);
            }
            return result;
        }

        [HttpPost]
        public string UpdateLog(int status, string driver, string remark, int headerId,int? detailsId)
        {
            string result = null;
            if (detailsId == -1) detailsId = null;
            using (SalesManageDataContext db = new SalesManageDataContext(AppConfigSettings.WebConfigConnectionSting("GSLSR")))
            {
                result = db.UpdateLog( status, driver, remark, headerId,detailsId);
            }
            return result;
        }
        [HttpGet]
        public UserDetail GetAuthFor(string UserName, string Password)
        {
            UserDetail result = null;
            using (SalesManageDataContext db = new SalesManageDataContext(AppConfigSettings.WebConfigConnectionSting("GSLSR")))
            {
                result = db.getAuthUserDetail(UserName, Password);
            }
            return result;
        }

    }
}

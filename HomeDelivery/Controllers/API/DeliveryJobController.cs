using DataProvider;
using DataProvider.Entities.DeliveryJob;
using HomeDelivery.Helpers;
using NotificationProvider;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace HomeDelivery.Controllers.API
{
    public class DeliveryJobController : ApiController
    {
        //string OrderNumber, string VehicleCode, int Status = 8

        [HttpGet()]
        public List<DeliveryHeader> GetMobileOrders(string EmpID, string TransType)
        {
            List<DeliveryHeader> result = null;
            using (SalesManageDataContext db = new SalesManageDataContext(AppConfigSettings.WebConfigConnectionSting("GSLSR")))
            {
                result = db.getMobileOrders(EmpID, TransType);
            }
            return result;
        }
        //string OrderNumber, string VehicleCode, int Status = 8

        [HttpGet()]
        public List<DeliveryLine> GetMobileOrderDetails(string Receipt)
        {
            List<DeliveryLine> result = null;
            using (SalesManageDataContext db = new SalesManageDataContext(AppConfigSettings.WebConfigConnectionSting("GSLSR")))
            {
                result = db.getMobileOrderDetails(Receipt);
            }
            return result;
        }
        //string OrderNumber, string VehicleCode, int Status = 8


        //string OrderNumber, string VehicleCode, int Status = 8

        [HttpGet()]
        public DeliveryHeader GetDeliveryJob(string OrderNumber, string VehicleCode, int Status = 8)
        {
            DeliveryHeader result = null;
            using (SalesManageDataContext db = new SalesManageDataContext(AppConfigSettings.WebConfigConnectionSting("GSLSR")))
            {
                result = db.getDelivery(OrderNumber, VehicleCode, Status);
            }
            return result;
        }
        //string OrderNumber, string VehicleCode, int Status = 8

        [HttpGet()]
        public List<DeliveryHeader> GetDeliveryJobs(string VehicleCode, int Status = 8)
        {
            List<DeliveryHeader> result = null;
            using (SalesManageDataContext db = new SalesManageDataContext(AppConfigSettings.WebConfigConnectionSting("GSLSR")))
            {
                result = db.getDeliveries(VehicleCode, Status);
            }
            return result;
        }
        //string OrderNumber, string VehicleCode, int Status = 8

        [HttpPost()]
        public DeliveryHeader SetDeliveryJobs(DeliveryHeader DeliveryJob)
        {
            List<DeliveryHeader> result = null;
            using (SalesManageDataContext db = new SalesManageDataContext(AppConfigSettings.WebConfigConnectionSting("GSLSR")))
            {
                DeliveryJob = db.UpdateDelivery(DeliveryJob);
            }
            return DeliveryJob;
        }

        [HttpPost()]
        public String AddDeliveryJob(DeliveryHeader DeliveryJob)
        {
            string Receipt = "";
            using (SalesManageDataContext db = new SalesManageDataContext(AppConfigSettings.WebConfigConnectionSting("GSLSR")))
            {
                Receipt = db.AddDelivery(DeliveryJob);
            }

            return Receipt;
        }
        
        [HttpPost()]
        public HttpResponseMessage AddDeliveryJobWithAttachment(DeliveryHeader DeliveryJob)
        {
            string Receipt = "";
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                var docfiles = new List<string>();
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    var filePath = HttpContext.Current.Server.MapPath("~/delivery_attachments/" + postedFile.FileName);
                    postedFile.SaveAs(filePath);
                    docfiles.Add(filePath);
                    DeliveryJob.attachmentName = filePath;
                    using (SalesManageDataContext db = new SalesManageDataContext(AppConfigSettings.WebConfigConnectionSting("GSLSR")))
                    {
                        Receipt = db.AddDelivery(DeliveryJob);
                    }
                }
                result = Request.CreateResponse(HttpStatusCode.Created, docfiles);
                result.Content.Headers.Add("Receipt", Receipt);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return result;
        }
    }
}

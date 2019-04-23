using DataProvider;
using DataProvider.Entities.DeliveryJob;
using HomeDelivery.Helpers;
using Newtonsoft.Json;
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
    public class DeliveryJobAttachmentController : ApiController
    {
        [HttpPost]
        public async Task<String> AddDeliveryJobWithAttachment()
        {

            string Receipt = "";
            HttpResponseMessage result = null;

            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);

            DeliveryHeader DeliveryJob = new DeliveryHeader();

            try
            {
                await Request.Content.ReadAsMultipartAsync(provider);

                // Show all the key-value pairs.
                foreach (var key in provider.FormData.AllKeys)
                {
                    foreach (var val in provider.FormData.GetValues(key))
                    {
                        DeliveryHeader temp = new DeliveryHeader();
                        DeliveryJob = JsonConvert.DeserializeAnonymousType<DeliveryHeader>(val,temp);
                        Trace.WriteLine(string.Format("{0}: {1}", key, val));
                    }
                }


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

                }

                if (Receipt != null && DeliveryJob.Status == 1)
                    try
                    {
                        using (var emailProvider = new EmailProvider(
                            "oraclepos@grandstores.ae",
                            "Pass@1234",
                            "mail.grandstores.ae",
                            25
                            ))
                        {
                            emailProvider.CreateMessage(
                                "oraclepos@grandstores.ae",
                                "Mobile order crated " + Receipt + ".",
                                "Please process the mobile order : " + Receipt + ".",
                                false,
                                new string[] { "srkrishnan@grandstores.ae" }
                                );
                            emailProvider.AddAttachments(DeliveryJob.attachmentName);
                            emailProvider.Send();
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }

                return Receipt;
            }
            catch (System.Exception e)
            {
                return "";
            }

            /*
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
                    //DeliveryJob.attachmentName = filePath;
                    //using (SalesManageDataContext db = new SalesManageDataContext(AppConfigSettings.WebConfigConnectionSting("GSLSR")))
                    //{
                    //    Receipt = db.AddDelivery(DeliveryJob);
                    //}
                }
                result = Request.CreateResponse(HttpStatusCode.Created, docfiles);
                result.Content.Headers.Add("Receipt", Receipt);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            */
        }

        [HttpPost()]
        public async Task<DeliveryHeader> SetDeliveryJobsWithAttachment(DeliveryHeader DeliveryJob)
        {
            List<DeliveryHeader> result = null;
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);

            try
            {
                await Request.Content.ReadAsMultipartAsync(provider);

                // Show all the key-value pairs.
                foreach (var key in provider.FormData.AllKeys)
                {
                    foreach (var val in provider.FormData.GetValues(key))
                    {
                        DeliveryHeader temp = new DeliveryHeader();
                        DeliveryJob = JsonConvert.DeserializeAnonymousType<DeliveryHeader>(val, temp);
                        Trace.WriteLine(string.Format("{0}: {1}", key, val));
                    }
                }


                var httpRequest = HttpContext.Current.Request;

            }
            catch (System.Exception e)
            {
                Debug.Print(e.Message);
            }
            using (SalesManageDataContext db = new SalesManageDataContext(AppConfigSettings.WebConfigConnectionSting("GSLSR")))
            {
                DeliveryJob = db.UpdateDelivery(DeliveryJob);
            }
            return DeliveryJob;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace DataProvider.Entities.DeliveryJob
{
    public class DeliveryHeader : DeliverySchedule
    {
        [Display(Name = "HeaderId")]
        public Int32 HeaderId { get; set; }

        [Display(Name = "Receipt")]
        public String Receipt { get; set; }

        [Display(Name = "OrderNumber")]
        public String OrderNumber { get; set; }

        [Display(Name = "CustomerName")]
        public String CustomerName { get; set; }

        [Display(Name = "SaleDate")]
        public DateTime? SaleDate { get; set; }

        [Display(Name = "Phone")]
        public String Phone { get; set; }

        [Display(Name = "DeliveryAddress")]
        public String DeliveryAddress { get; set; }

        [Display(Name = "DeliveryLines")]
        public List<DeliveryLine> DeliveryLines { get; set; }

        [Display(Name = "saleType")]
        public String saleType { get; set; }

        [Display(Name = "deliveryType")]
        public String deliveryType { get; set; }

        [Display(Name = "attachmentName")]
        public String attachmentName { get; set; }
    }
}
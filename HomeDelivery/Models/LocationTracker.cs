using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HomeDelivery.Models
{
    [Table("LOCATION_TRACKER")]
    public class LocationTracker
    {

        [Column("user_id", Order = 1)]
        private String VehicleCode;
        [Column("user_id", Order = 1)]
        private Double Latitude;
        [Column("user_id", Order = 1)]
        private Double Longitude;
        [Column("user_id", Order = 1)]
        private float accuracy;
    }
}
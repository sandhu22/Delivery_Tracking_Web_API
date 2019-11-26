using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delivery_Tracking_Web_API.Model
{
    //Tracking infomation details
    public class TrackingInfo
    {
        public int Id { get; set; }


        public string TrackingId { get {

                return "TR00000"+Id;
            
            } }

        public string Description { get; set; }


        public string DeliveryStatus { get; set; }

        public DateTime DispatchedOn { get; set; }


    }
}

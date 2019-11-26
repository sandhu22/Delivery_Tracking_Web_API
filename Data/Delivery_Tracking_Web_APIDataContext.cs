using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Delivery_Tracking_Web_API.Model;

namespace Delivery_Tracking_Web_API.Models
{
    //Database connection
    public class Delivery_Tracking_Web_APIDataContext : DbContext
    {
        public Delivery_Tracking_Web_APIDataContext (DbContextOptions<Delivery_Tracking_Web_APIDataContext> options)
            : base(options)
        {
        }

        public DbSet<Delivery_Tracking_Web_API.Model.TrackingInfo> TrackingInfo { get; set; }
    }
}

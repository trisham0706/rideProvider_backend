using CommunityCommuting_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityCommuting_DAL.Models
{
    public class Booking
    {
        public string bookingId { get; set; }
        public string tripId { get; set; }
        public int numberOfSeat { get; set; }
        public string seekerId { get; set; }
        public string status { get; set; }
        public Trip trips { get; set; }
    }
}
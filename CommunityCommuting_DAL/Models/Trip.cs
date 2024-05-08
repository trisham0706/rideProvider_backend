using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityCommuting_DAL.Models
{
    public class Trip
    {
        public string tripId { get; set; }

        public string creatorUserId { get; set; }

        public string vehicleId { get; set; }

        public DateOnly rideDate { get; set; }

        public TimeOnly rideTime { get; set; }

        public string rideStatus { get; set; }

        public int noOfSeat { get; set; }

        public int seatsFilled { get; set; }

        public string fromLoc { get; set; }

    

        public string toLoc { get; set; }
        public ICollection<Booking> bookings { get; set; }

    }
}


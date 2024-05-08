using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityCommuting_BAL.DTO
{
    public class TripBookingDTO
    {
        public string TripId { get; set; }

        public string CreatorUserId { get; set; }

        public string VehicleId { get; set; }

        public DateOnly RideDate { get; set; }

        public TimeOnly RideTime { get; set; }

        public string RideStatus { get; set; }

        public int NoOfSeat { get; set; }

        public int SeatsFilled { get; set; }

        public string FromLoc { get; set; }

        public string ToLoc { get; set; }
    }
}

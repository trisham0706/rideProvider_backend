using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityCommuting_DAL.Models
{
    public class billMaster
    {
        public string billId { get; set; }
        public string rideId { get; set; }
        public int month { get; set; }
        public int noOfKm { get; set; }
        public int totalbill { get; set; }
        public int noOfOccupants { get; set; }
        public int feeId { get; set; }
        public int costPerOccupant { get; set; }
        public Fee fees { get; set; }
    }
}


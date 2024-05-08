using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityCommuting_BAL.DTO
{
    public class BillDTOs
    {
        public string rideId { get; set; }
        public int month { get; set; }
        public int noOfKm { get; set; }
        public int totalbill { get; set; }
        public int noOfOccupants { get; set; }
    }
}

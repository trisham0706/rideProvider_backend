using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityCommuting_DAL.Models
{
    public class Smile
    {
        public int smileId { get; set; }

        public string rpId { get; set; }

        public string source { get; set; }

        public string destination { get; set; }

        public int occupancy { get; set; }

        public int month { get; set; }
        public RideInfo rideInfo { get; set; }
    
    }
}

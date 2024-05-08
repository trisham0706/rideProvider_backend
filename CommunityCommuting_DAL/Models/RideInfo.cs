using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityCommuting_DAL.Models
{
    public class RideInfo
    {
        public string vehicleNo { get; set; }

        public string rpId { get; set; }

        public string carType { get; set; }

        public string carName { get; set; }

        public string fuelType { get; set; }

        public int noOfSeats { get; set; }
        public RideProvide rideProvide { get; set; }
        public ICollection<Smile> Smiles { get; set; }
    }
}

using CommunityCommuting_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityCommuting_DAL.Models
{
    public class Fee
    {
        public int feeId { get; set; }
        public string carType { get; set; }
        public string carName { get; set; }
        public string fuelType { get; set; }
        public int averageInKm { get; set; }
        public int wearTearCost { get; set; }
        public int drivercharges { get; set; }
        public int carPoolCommision { get; set; }

        public ICollection<billMaster> billMasters { get; set; }
    }
}
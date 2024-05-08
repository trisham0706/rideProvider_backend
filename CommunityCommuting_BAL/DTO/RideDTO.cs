using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityCommuting_BAL.DTO
{
    public class RideDTO
    {
        public string rpId { get; set; }
        public DateOnly birthDate { get; set; }
        public long adharcard { get; set; }
        public string emailId { get; set; }
        public long phone { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string dlNo { get; set; }
        public string status { get; set; }
        public int age { get; set; }
        public DateOnly validUpto { get; set; }
    }
}

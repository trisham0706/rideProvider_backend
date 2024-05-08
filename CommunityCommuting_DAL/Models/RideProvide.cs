using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityCommuting_DAL.Models
{
    public class RideProvide
    {

        public string rpId { get; set; }

        public long adharcard { get; set; }

        public string emailId { get; set; }

        public long phone { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string dlNo { get; set; }

        public DateOnly validUpto { get; set; }

        public string status { get; set; }

        public int age { get; set; }
        public DateOnly birthDate { get; set; }
        public ICollection<RideInfo> RideInfos { get; set; }
    }
}

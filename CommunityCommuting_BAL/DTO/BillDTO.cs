using CommunityCommuting_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommuntiyCommuting_BAL.DTO
{
    public class BillDTO
    {
        public int month { get; set; }
        public int noOfKm { get; set; }
        public int totalbill { get; set; }
        public int noOfOccupants { get; set; }
    }
}

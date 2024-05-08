using CommunityCommuting_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityCommuting_BAL.DTO
{
    public class SmileDTO
    {
        public string rpId { get; set; }
        public string source { get; set; }
        public string destination { get; set; }
        public int month { get; set; }
        public int occupancy { get; set; }
    }
}

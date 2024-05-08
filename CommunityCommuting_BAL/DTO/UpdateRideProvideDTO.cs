using CommunityCommuting_BAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityCommuting_BAL.DTO
{
    public class UpdateRideProvideDTO : RideProvideDTO
    {
        public string status { get; set; }
    }
}

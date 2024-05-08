using CommunityCommuting_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityCommuting_DAL.Interface
{
    public interface IRideProvide
    {
        Task<int>AddRider(RideProvide rideProvide);
        Task<int> UpdateRider(RideProvide rideProvide);
        Task<RideProvide> FindRideProviderById(string rideProvideId);

        Task<List<RideProvide>> GetRiderDetails(string rpId);

    }
}

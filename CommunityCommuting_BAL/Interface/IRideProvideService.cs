using CommunityCommuting_BAL.DTO;
using CommunityCommuting_BAL.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityCommuting_BAL.Interface
{
    public interface IRideProvideService
    {
        Task<Output> CreateNewRideProvider(RideProvideDTO rideProvideDTO);
        Task<Output> UpdateNewRideProvider(string providerId,UpdateRideProvideDTO rideProvideDTO);
        Task<RideDTO?> GetRiderById(string rpId);


    }
}

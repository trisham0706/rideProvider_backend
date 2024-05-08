using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityCommuting_BAL.DTO;
using CommunityCommuting_BAL.Result;

namespace CommunityCommuting_BAL.Interface
{
    public interface ITripService
    {
        Task<Output> CreateTrip(TripBookingDTO tripBookingDTO);
        Task<List<TripBookingDTO>> getTrip(string tripId);

        Task<Output> updateTrip(string tripId, TripBookingDTO tripBookingDTO);
        Task<Output> deleteTrip(string tripId);
    }
}
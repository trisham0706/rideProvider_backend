using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityCommuting_DAL.Models;

namespace CommunityCommuting_DAL.Interface
{
    public interface ITripManager
    {
        Task<int> AddTripDetails(Trip trip);
        Task<List<Trip>> GetTripDetails(string tripId);
        Task<int> UpdateTripDetails(Trip trip);
        Task<Trip> FindTripById(string tripId);
        Task<int> DeleteTripDetails(Trip trip);

    }
}
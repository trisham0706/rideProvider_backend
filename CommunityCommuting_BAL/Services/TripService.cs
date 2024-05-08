using CommunityCommuting_BAL.DTO;
using CommunityCommuting_DAL.Interface;
using CommunityCommuting_BAL.Interface;
using CommunityCommuting_BAL.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityCommuting_DAL.Models;



namespace CommunityCommuting_BAL.Service
{
    public class TripService : ITripService
    {
        private readonly ITripManager _tripRepository;
        public TripService(ITripManager tripRepository)
        {
            _tripRepository = tripRepository;
        }

        public async Task<Output> CreateTrip(TripBookingDTO tripBookingDTO)
        {
            if(!IsSeatNegative(tripBookingDTO.NoOfSeat)) 
            {
                return new Output()
                {
                    Result = false,
                    errorMessage = "No. of seats cannot be negative or less than zero"
                };
            }

            if(!IsSeatsFilledGreater(tripBookingDTO.NoOfSeat, tripBookingDTO.SeatsFilled))
            {
                return new Output()
                {
                    Result = false,
                    errorMessage = "No. of seats cannot filled cannot be greater than no of seats and also cannot be less than zero"
                };
            }

            if(!checkDateTimeInFuture(tripBookingDTO.RideDate, tripBookingDTO.RideTime))
            { 
                return new Output()
                {
                    Result = false,
                    errorMessage = "Date and time should be in the future"
                };

            }

            Trip models = new Trip()
            {
                tripId = tripBookingDTO.TripId,
                creatorUserId = tripBookingDTO.CreatorUserId,
                vehicleId = tripBookingDTO.VehicleId,
                rideDate = tripBookingDTO.RideDate,
                rideTime = tripBookingDTO.RideTime,
                rideStatus = tripBookingDTO.RideStatus,
                noOfSeat = tripBookingDTO.NoOfSeat,
                seatsFilled = tripBookingDTO.SeatsFilled,
                fromLoc = tripBookingDTO.FromLoc,
                toLoc = tripBookingDTO.ToLoc
            };
            var changes = await _tripRepository.AddTripDetails(models);
            return new Output
            {
                Result = true,
            };
        }
        

        public async Task<List<TripBookingDTO>> getTrip(string tripId)
        {
            List<Trip> ans = await _tripRepository.GetTripDetails(tripId);
            List<TripBookingDTO> l = new List<TripBookingDTO>();
            foreach (Trip i in ans)
            {
                TripBookingDTO tbk = new TripBookingDTO()
                {
                    TripId = tripId,
                    CreatorUserId = i.creatorUserId,
                    VehicleId = i.vehicleId,
                    RideDate = i.rideDate,
                    RideTime = i.rideTime,
                    RideStatus = i.rideStatus,
                    NoOfSeat = i.noOfSeat,
                    SeatsFilled = i.seatsFilled,
                    FromLoc = i.fromLoc,
                    ToLoc = i.toLoc
                };
                l.Add(tbk);
            }
            return l;
        }
        public async Task<Output> updateTrip(string tripId, TripBookingDTO tripBookingDTO)
        {
            try
            {
                var obj = await _tripRepository.FindTripById(tripId);
                obj.vehicleId = tripBookingDTO.VehicleId;
                obj.creatorUserId = tripBookingDTO.CreatorUserId;
                obj.rideDate = tripBookingDTO.RideDate;
                obj.rideTime = tripBookingDTO.RideTime;
                obj.rideStatus = tripBookingDTO.RideStatus;
                obj.noOfSeat = tripBookingDTO.NoOfSeat;
                obj.seatsFilled = tripBookingDTO.SeatsFilled;
                obj.fromLoc = tripBookingDTO.FromLoc;
                obj.toLoc = tripBookingDTO.ToLoc;
                var changes = await _tripRepository.UpdateTripDetails(obj);
                return new Output
                {
                    Result = true,
                };
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Output> deleteTrip(string tripId)
        {
            var obj = await _tripRepository.FindTripById(tripId);

            if (obj.rideStatus == "Unbooked" || obj.rideStatus == "unbooked")
            {
                obj.vehicleId = null;
                obj.creatorUserId = null;
                obj.rideDate = new DateOnly();
                obj.rideTime = new TimeOnly();
                obj.rideStatus = "";
                obj.noOfSeat = 0;
                obj.seatsFilled = 0;
                obj.fromLoc = null;
                obj.toLoc = null;
                var changes = await _tripRepository.DeleteTripDetails(obj);
                return new Output
                {
                    Result = true,
                };
            }

            return new Output
            {
                Result = false,
                errorMessage = "Booked Ride cannot be deleted"
            };
        }
      

        private bool IsSeatNegative(int noOfSeat)
        {
            if (noOfSeat <= 0)
            {
                return false;
            }
            return true;
        }

        private bool IsSeatsFilledGreater(int noOfSeat, int seatsFilled)
        {
            if (noOfSeat < seatsFilled && seatsFilled < 0)
            {
                return false;
            }
            return true;
        }

        private bool IsBooked(string rideStatus)
        {
            if(rideStatus == "booked" || rideStatus == "Booked")
            {
                return false;
            }
            return true;
        }

        private bool checkDateTimeInFuture(DateOnly date, TimeOnly time)
        {
            if(date < DateOnly.FromDateTime(DateTime.Today))
            {
                return false;
            }

            else if(date == DateOnly.FromDateTime(DateTime.Today))
            {
                if(time<TimeOnly.FromDateTime(DateTime.Today))
                {
                    return false;
                }
            }
            return true;
        }
    }
}

using CommunityCommuting_BAL.DTO;
using CommunityCommuting_BAL.Interface;
using CommunityCommuting_BAL.Service;
using CommunityCommuting_DAL.Interface;
using CommunityCommuting_DAL.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    internal class TripServiceTest
    {
        private Mock<ITripManager> _tripRepositoryMock;
        private ITripService _tripService;

        [SetUp]
        public void Setup()
        {
            _tripRepositoryMock = new Mock<ITripManager>();
            _tripService = new TripService(_tripRepositoryMock.Object);
        }

        [Test]
        public async Task CreateTrip_ValidInput_ReturnsSuccessOutput()
        {
            // Arrange
            var tripBookingDTO = new TripBookingDTO
            {
                TripId = " T1",
                 CreatorUserId = "U2",
                VehicleId = "V1",
                RideDate = DateOnly.Parse("2024-09-29"),
                RideTime = TimeOnly.Parse("13:10"),
                RideStatus = "Booked",
                NoOfSeat = 5,
                SeatsFilled = 3,
               FromLoc = "Mumbai",
               ToLoc = "Pune"
            };

            // Act
            var result = await _tripService.CreateTrip(tripBookingDTO);

            // Assert
            Assert.IsTrue(result.Result);
           
        }

        [Test]
        public async Task GetTrip_ValidTripId_ReturnsListOfTripBookingDTO()
        {
            // Arrange
            var tripId = "T123";
            var trips = new List<Trip>
            {
                new Trip
                {
                    creatorUserId = "U1",
                    vehicleId = "V1",
                    rideDate =DateOnly.Parse("2024-09-29"),
                    rideTime = TimeOnly.Parse("13:10"),
                    rideStatus = "Booked",
                    noOfSeat = 5,
                    seatsFilled = 3,
                    fromLoc = "Mumbai",
                    toLoc = "Pune"
                }
                // Add more test data as needed
            };
            _tripRepositoryMock.Setup(repo => repo.GetTripDetails(tripId)).ReturnsAsync(trips);

            // Act
            var result = await _tripService.getTrip(tripId);

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(tripId, result[0].TripId);
            Assert.AreEqual("U1", result[0].CreatorUserId);
            Assert.AreEqual("V1", result[0].VehicleId);
            
        }

        [Test]
        public async Task UpdateTrip_ValidInput_ReturnsSuccessOutput()
        {
            // Arrange
            var tripId = "T123";
            var tripBookingDTO = new TripBookingDTO
            {
                VehicleId = "V1",
                CreatorUserId = "U1",
                RideDate = DateOnly.Parse("2024-09-29"),
                RideTime = new TimeOnly(13, 10), // Use TimeOnly to represent time
                RideStatus = "Booked",
                NoOfSeat = 5,
                SeatsFilled = 3,
                FromLoc = "Mumbai",
                ToLoc = "Pune"
            };
            var existingTrip = new Trip(); // Set up an existing trip object
            _tripRepositoryMock.Setup(repo => repo.FindTripById(tripId)).ReturnsAsync(existingTrip);

            // Act
            var result = await _tripService.updateTrip(tripId, tripBookingDTO);

            // Assert
            Assert.IsTrue(result.Result);
            
        }


    }
}

using System;
using System.Threading.Tasks;
using CommunityCommuting_BAL.DTO;
using CommunityCommuting_BAL.Interface;
using CommunityCommuting_BAL.Result;
using CommunityCommuting_BAL.Service;
using CommunityCommuting_DAL.Interface;
using CommunityCommuting_DAL.Models;
using Moq;
using NUnit.Framework;

namespace UnitTesting
{
    [TestFixture]
    public class RideProvideServiceTest
    {
        private Mock<IRideProvide> _rideProvideRepositoryMock;
        private Mock<ISmile> _smileRepositoryMock;
        private IRideProvideService _rideProvideService;

        [SetUp]
        public void Setup()
        {
            _rideProvideRepositoryMock = new Mock<IRideProvide>();
            _smileRepositoryMock = new Mock<ISmile>();
            _rideProvideService = new RideProvideService(_rideProvideRepositoryMock.Object, _smileRepositoryMock.Object);
        }

        [Test]
        public async Task CreateNewRideProvider_ValidInput_ReturnsSuccessOutput()
        {
            // Arrange
            var rideProviderDTO = new RideProvideDTO
            {
                BirthDate = DateOnly.Parse("2002-12-01"),
                Adharcard = 123456789012,
                EmailId = "hnj@cognizant.com",
                Phone = 8902345167,
                FirstName = "Trisha",
                LastName = "Mallick",
                DlNo = "1245-567-890-567",
                ValidUpto = DateOnly.Parse("2025-12-11")

            };


            // Mock the repository methods
            _rideProvideRepositoryMock.Setup(repo => repo.AddRider(It.IsAny<RideProvide>())).ReturnsAsync(1); // Return a dummy RideProvide object

            // Act
            var result = await _rideProvideService.CreateNewRideProvider(rideProviderDTO);

            // Assert
            Assert.IsTrue(result.Result);
            
        }

        [Test]
        public async Task UpdateNewRideProvider_ValidInput_ReturnsSuccessOutput()
        {
            // Arrange
            var providerId = "P123";
            var rideProviderDTO = new UpdateRideProvideDTO
            {
                // Set properties for test data
                BirthDate = DateOnly.Parse("2002-12-01"),
                Adharcard = 123456789012,
                EmailId = "hnj@cognizant.com",
                Phone = 8902345167,
                FirstName = "Trisha",
                LastName = "Mallick",
                DlNo = "1245-567-890-567",
                ValidUpto = DateOnly.Parse("2025-12-11"),
                status = "Approved"
            };
            var existingProvider = new RideProvide(); // Set up an existing provider object
            _rideProvideRepositoryMock.Setup(repo => repo.FindRideProviderById(providerId)).ReturnsAsync(existingProvider);

            // Act
            var result = await _rideProvideService.UpdateNewRideProvider(providerId, rideProviderDTO);

            // Assert
            Assert.IsTrue(result.Result);
            
        }

        [Test]
        public async Task GetRiderById_ValidRpId_ReturnsRideDTO()
        {
            // Arrange
            var rpId = "RP123";
            var rideProvider = new RideProvide
            {
                rpId = rpId,
                adharcard = 123456789012,
                birthDate = DateOnly.Parse("1990-5-15"),
                firstName = "John",
                lastName = "Doe",
                dlNo = "DL-ABC-1234",
                emailId = "john.doe@cognizant.com",
                age = 31,
                status = "Registered",
                phone = 1234567890,
                validUpto = DateOnly.Parse("2024-12-01"),
            };
            _rideProvideRepositoryMock.Setup(repo => repo.GetRiderDetails(rpId)).ReturnsAsync(new List<RideProvide> { rideProvider });

            // Act
            var result = await _rideProvideService.GetRiderById(rpId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(rpId, result.rpId);
            Assert.AreEqual("John", result.firstName);
            
        }



    }
}

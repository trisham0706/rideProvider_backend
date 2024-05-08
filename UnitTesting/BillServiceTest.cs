using System.Collections.Generic;
using System.Threading.Tasks;
using CommunityCommuting_BAL.DTO;
using CommunityCommuting_BAL.Interface;
using CommunityCommuting_BAL.Service;
using CommunityCommuting_DAL.Interface;
using CommunityCommuting_DAL.Models;
using Moq;
using NUnit.Framework;

namespace UnitTesting
{
    [TestFixture]
    internal class BillServiceTest
    {
        private Mock<IBill> _billRepositoryMock;
        private Mock<ITripManager> _tripManagerMock;
        private IBillService _billService;

        [SetUp]
        public void Setup()
        {
            _billRepositoryMock = new Mock<IBill>();
            _tripManagerMock = new Mock<ITripManager>();
            _billService = new BillService(_billRepositoryMock.Object, _tripManagerMock.Object);
        }

        [Test]
        public async Task RetrieveBill_Should_Return_BillDTO()
        {
            // Arrange
            var month = 5;
            var bills = new List<billMaster>
            {
                new billMaster { noOfKm = 100, totalbill = 200, noOfOccupants = 3 }
                // Add more test data as needed
            };
            _billRepositoryMock.Setup(repo => repo.GetBill(month)).ReturnsAsync(bills);

            // Act
            var result = await _billService.RetrieveBill(month);

            // Assert
            Assert.AreEqual(month, result.month);
            Assert.AreEqual(100, result.noOfKm);
            Assert.AreEqual(200, result.totalbill);
            Assert.AreEqual(3, result.noOfOccupants);
        }

        [Test]
        public async Task GenerateBillDetails_Should_Return_ListOfBillDTOs()
        {
            // Arrange
            var tripId = "123";
            var bills = new List<billMaster>
            {
                new billMaster { rideId = "456", month = 5, noOfKm = 100, totalbill = 200, noOfOccupants = 3 }
                // Add more test data as needed
            };
            _billRepositoryMock.Setup(repo => repo.GetBillDetils(tripId)).ReturnsAsync(bills);

            // Act
            var result = await _billService.generateBillDetails(tripId);

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("456", result[0].rideId);
            Assert.AreEqual(5, result[0].month);
            Assert.AreEqual(100, result[0].noOfKm);
            Assert.AreEqual(200, result[0].totalbill);
            Assert.AreEqual(3, result[0].noOfOccupants);
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using CommunityCommuting_BAL.DTO;
using CommunityCommuting_BAL.Service;
using CommunityCommuting_DAL.Interface;
using CommunityCommuting_DAL.Models;
using Moq;
using NUnit.Framework;

namespace UnitTesting
{
    [TestFixture]
    public class SmileServiceTesting
    {
        private Mock<ISmile> _smileRepositoryMock;
        private SmileService _smileService;

        [SetUp]
        public void Setup()
        {
            _smileRepositoryMock = new Mock<ISmile>();
            _smileService = new SmileService(_smileRepositoryMock.Object);
        }

        [Test]
        public async Task GetSmile_Should_Return_TripDTO_List()
        {
            // Arrange
            int month = 5; // Example month
            string rpId = "123"; // Example provider ID
            var smiles = new List<Smile>
            {
                new Smile { source = "A", destination = "B", occupancy = 2 },
                new Smile { source = "C", destination = "D", occupancy = 3 }
                // Add more sample data as needed
            };
            _smileRepositoryMock.Setup(repo => repo.RetrieveSmileBasedOnMonthAndProviderId(month, rpId))
                .ReturnsAsync(smiles);

            // Act
            var result = await _smileService.GetSmile(month, rpId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<List<TripDTO>>(result);
            Assert.AreEqual(smiles.Count, result.Count);
            
        }
    }
}

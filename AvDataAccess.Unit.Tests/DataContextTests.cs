using System;
using System.Collections.Generic;
using Xunit;
using AvEntities;

namespace AvDataAccess.Unit.Tests
{

    public class DataContextTests : DatabaseFixture
    {
        [Fact]
        public void Ctor_DoesNotReturnNull()
        {

            Assert.NotNull(AvDataContext);
        }

        [Fact]
        public void Dc_Returns_DateList()
        {
            // Arrange 

            // Act
            var dateList = AvDataContext.RunDateList();

            // Assert
            Assert.NotEmpty(dateList);
        }

        [Fact]
        public void Dc_Returns_RequestGroup()
        {
            var requestGroup = AvDataContext.RequestGroup();

            Assert.IsType<List<StoreYbAnalyticReq>>(requestGroup);
            Assert.NotEmpty(requestGroup);
            Assert.True(requestGroup.Count > 0);
        }

        [Fact]
        public void Dc_ReturnsRequestsForRequestGroup()
        {
            // Arrange
            var requestGroup = new StoreYbAnalyticReq() { RunDate = new DateTime(2018, 2, 23, 0, 30, 5), ValDate = new DateTime(2018, 2, 21), Slot = 2, PortfolioId = 1, };

            // Act
            var requests = AvDataContext.GetRequests(requestGroup);

            // Assert
            Assert.IsType<List<StoreYbAnalyticReq>>(requests);
            Assert.NotEmpty(requests);
            Assert.True(requests.Count > 0);
        }

        [Fact]
        public void Dc_ReturnsRequestsForCadisId()
        {
            // Arrange
            int cadisId = 31;

            // Act
            var requests = AvDataContext.GetRequestsByCadisId(cadisId);

            // Assert
            Assert.IsType<List<StoreYbAnalyticReq>>(requests);
            Assert.NotEmpty(requests);
            Assert.True(requests.Count > 0);
        }

        [Fact]
        public void Dc_ReturnsRequestsForYieldbookId()
        {
            // Arrange
            string yieldbookId = "AR4164364";

            // Act
            var requests = AvDataContext.GetRequestsByYieldbookId(yieldbookId);

            // Assert
            Assert.IsType<List<StoreYbAnalyticReq>>(requests);
            Assert.NotEmpty(requests);
            Assert.True(requests.Count > 0);
        }


    }
}

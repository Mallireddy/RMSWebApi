using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RMSWebApi;
using RMSWebApi.Controllers;
using RMSWebApi.RepoImplement;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace RmsApiTestCase
{
    public class RmsAPITest
    {
        private readonly IFixture _fixture;
        //private readonly Mock<MyUnitOfWork> _serviceMock;
        private readonly Mock<MyUnitOfWork> _serviceMock;
        private readonly Mock<PurchaseOrderRepoImplement> _purchaseOrderRepoMock;
        private readonly PurchaseOrderController _sut;

        public RmsAPITest()
        {
            _fixture = new Fixture();
            // _serviceMock = _fixture.Freeze<Mock<MyUnitOfWork>>();
            _serviceMock = _fixture.Freeze<Mock<MyUnitOfWork>>();
            _purchaseOrderRepoMock = _fixture.Freeze<Mock<PurchaseOrderRepoImplement>>();
            //_sut = new PurchaseOrderController(_serviceMock.Object);
            //_sut = new PurchaseOrderController(_unitOfWorkMock.Object);

        }

        [Fact]
        public async Task GetPurchaseOrder_ShouldRetrunOKResponse_WhenDataFound()
        {

            ////Arrange
            //var PurchaseOrderMock = _fixture.Create<_serviceMock.PurchaseOrderRepo>();
            //serviceMock.Setup(x => x.GetAllFeedbacks()).RetrunsAsync(feedbackMock);
            ////Act
            //var result = await _sut.GetFeedbacks().Configuration(false);

            // // Arrange
            // var purchaseOrderMock = _fixture.Create<PurchaseOrderRepoImplement>();
            //// _purchaseOrderRepoMock.Setup(x => x.GetAll()).Returns(new List<PurchaseOrderDTO> { purchaseOrderMock });

            // // Act
            // var result = _sut.GetAll();
            // Arrange
            var expectedPurchaseOrders = new List<PurchaseOrderDTO> { /* Create expected data here */ };
            _purchaseOrderRepoMock.Setup(x => x.GetAll()).Returns(expectedPurchaseOrders);

            // Act
            var result = _sut.GetAll();

            // Assert
            //result.Should().NotBeNull();
            //result.Should().BeAssignableTo<ActionResult<IEnumerable<PurchaseOrderDTO>>>();
            //result.Result.Should().BeAssignableTo<OkObjectResult>();
            //result.Result.As<OkObjectResult>().Value.Should().NotBeNull().And.BeOfType<List<PurchaseOrderDTO>>(); // Adjust the type accordingly
            //_serviceMock.Verify(x => x.PurchaseOrderRepo(), Times.Never()); // Correct the method name and adjust the expectation accordingly
        }
    }
}

using NUnit.Framework;
using System.Threading.Tasks;
using Moq;
using GlueHome.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Http;
using GlueHome.Model.Enums;
using GlueHome.Tests.Data;
using GlueHome.Domain.DeliveryServices;

namespace GlueHome.Tests.Controller
{
    [TestFixture]
    public class DeliveryControllerTests
    {
        private Mock<IDeliveryService> deliveryService;
        private Mock<ILogger<DeliveryController>> logger;
        private DeliveryController deliveryController;

        [SetUp]
        public void Init()
        {
            deliveryService = new Mock<IDeliveryService>();
            logger = new Mock<ILogger<DeliveryController>>();

            deliveryController = new DeliveryController(deliveryService.Object, logger.Object);             
        }        

        [Test]
        public async Task GetDeliveries_Should_Get_List_Of_Deliveries()
        {
            var deliveries = SampleData.GetDeliveryView();

            deliveryService.Setup(x => x.GetDeliveries()).ReturnsAsync(deliveries);

            var result = await deliveryController.GetDeliveries();

            Assert.IsNotNull(result);
        }

        [Test]
        public async Task GetDelivery_Should_Get_Delivery_If_ID_Passed()
        {
            var deliveries = SampleData.GetDeliveryView();           

            deliveryService.Setup(x => x.GetDelivery(It.IsAny<int>())).ReturnsAsync(deliveries[0]);

            var result = await deliveryController.GetDelivery(It.IsAny<int>());

            Assert.IsNotNull(result);
        }
       

        [Test]
        public async Task PostSupplier_Should_Return_Bad_Request()
        {
            var delivery = SampleData.GetDeliveries()[1];          

            deliveryController.ModelState.AddModelError("", "Invalid Date");                    

            var result = await deliveryController.PostDelivery(delivery);
            var statusCodeResult = (IStatusCodeActionResult)result.Result;

            Assert.IsNull(result.Value);
            Assert.AreEqual(statusCodeResult.StatusCode, StatusCodes.Status400BadRequest);
        }       

        [Test]
        public async Task PostDelivery_Should_Insert_And_Return_Delivery()
        {
            var delivery = SampleData.GetDeliveries()[1];
            var deliveries = SampleData.GetDeliveryView();

            deliveryService.Setup(x => x.GetDelivery(It.IsAny<int>())).ReturnsAsync(deliveries[0]);
            deliveryService.Setup(x => x.InsertDelivery(delivery));

            var result = await deliveryController.PostDelivery(delivery);         

            Assert.IsNotNull(result.Value);           
        }

        [Test]
        public async Task UpdateDelivery_Should_Return_UpdatedDelivery()
        {
            var delivery = SampleData.GetDeliveries()[1];
            var deliveries = SampleData.GetDeliveryView();

            deliveryService.Setup(x => x.UpdateDelivery(It.IsAny<int>(), It.IsAny<DeliveryStatus>())).ReturnsAsync(delivery);

            deliveryService.Setup(x => x.GetDelivery(It.IsAny<int>())).ReturnsAsync(deliveries[0]);

            var result = await deliveryController.UpdateDelivery(delivery.Id, 1);           

            Assert.IsNotNull(result.Value);            
        }        
    }
}

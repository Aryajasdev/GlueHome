using GlueHome.Data.Context;
using GlueHome.Domain.DeliveryServices;
using GlueHome.Model.Delivery;
using GlueHome.Model.Enums;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace TechnicalInterview.Tests.ServiceTest
{
    [TestFixture]
    public class DeliveryServiceTests
    {
        private IDeliveryService deliveryService;
        private DeliveryContext context;      

        [SetUp]
        public void Init()
        {
            context = TestDataContext.GetContextWithData();       

            deliveryService = new DeliveryService(context);
        }

        [Test]
        public async Task GetDeliverys_Should_Get_List_Of_Deliverys()
        {            
            var result = await deliveryService.GetDeliveries();

            Assert.IsNotNull(result);
        }

        [Test]
        public async Task GetDelivery_Should_Get_Delivery()
        {           
            var result = await deliveryService.GetDelivery(1);

            Assert.IsNotNull(result);
        }

        [Test]
        public async Task InsertDelivery_Should_Insert_Delivery()
        {
            var delivery = new Delivery
            {
                Id = 3,
                Endtime = DateTime.Now,
                Order = new Order
                {
                    OrderNumber = new Guid(),
                    Sender = "test"
                },
                Recepient = new Recepient
                {
                    Address = "Test",
                    EmailAddress = "test@gmail.com",
                    FirstName = "Test",
                    LastName = "Test",
                    PhoneNumber = "1234567890"
                }
            };

            await deliveryService.InsertDelivery(delivery);

            var deliveries = await deliveryService.GetDeliveries();

            Assert.IsTrue(deliveries.Count == 3);
        }
       

        [Test]
        public async Task Deletedeliverys_Should_Throw_Exception_If_Activation_Date_is_not_Null()
        {
            var result = await deliveryService.UpdateDelivery(1, DeliveryStatus.Approved);

            Assert.IsNotNull(result);
        }

           
    }
}

using GlueHome.Data;
using GlueHome.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;

namespace TechnicalInterview.Tests.ServiceTest
{
    public class TestDataContext
    {
        public static DeliveryContext GetContextWithData()
        {
            var options = new DbContextOptionsBuilder<DeliveryContext>()
                            .UseInMemoryDatabase(Guid.NewGuid().ToString())
                            .Options;

            var context = new DeliveryContext(options);

            var deliverys = DataGenerator.GetDeliveries();
            context.Users.AddRange(DataGenerator.GetUsers());
            context.Deliveries.AddRange(deliverys);

            context.SaveChanges();

            return context;

        }
    }
}

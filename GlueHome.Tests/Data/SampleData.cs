using GlueHome.Model.Delivery;
using System;
using System.Collections.Generic;

namespace GlueHome.Tests.Data
{
    public class SampleData
    {
        public static List<Delivery> GetDeliveries()
        {
            var deliveries = new List<Delivery>()
            {
                new Delivery
                {
                    Id =1,
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
                },
                new Delivery
                {
                    Id =1,
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
                }
            };

            return deliveries;
        }

        public static List<DeliveryView> GetDeliveryView()
        {
            var deliveries = new List<DeliveryView>()
            {
                new DeliveryView
                {
                    AccessWindow = new DeliveryTime
                    {
                        EndTime = DateTime.Now.AddHours(2)
                    },
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
                },
                new DeliveryView
                {
                    AccessWindow = new DeliveryTime
                    {
                        EndTime = DateTime.Now.AddHours(2)
                    },
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
                }
            };

            return deliveries;
        }
    }
}

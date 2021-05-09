using GlueHome.Data.Context;
using GlueHome.Model.Delivery;
using GlueHome.Model.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GlueHome.Data
{
    public class DataGenerator
    {
        public static List<Role> GetRoles()
        {
            return new List<Role>
            {
                new Role
                {
                    Id = 1,
                    Name = "User"
                },
                new Role
                {
                    Id = 2,
                    Name = "Partner"
                }
            };
        }

        public static List<User> GetUsers()
        {
            return new List<User>
            {
                new User
                {
                    Id = 1,
                    EmailAddress ="user@test.com",
                    Password = "userpass",
                    Role = GetRoles()[0]
                },
                new User
                {
                    Id = 2,
                    EmailAddress ="partner@test.com",
                    Password = "partnerpass",
                    Role = GetRoles()[1]
                }
            };
        }

        public static List<Delivery> GetDeliveries()
        {
            return new List<Delivery>
            {
                new Delivery
                {
                    Id = 1,                    
                    Endtime = DateTime.Now.AddHours(2),                    
                    Order = GetOrders()[0],                     
                    Recepient = GetRecepients()[0]
                },
                new Delivery
                {
                    Id = 2,
                    Endtime = DateTime.Now.AddHours(2),                    
                    Order = GetOrders()[1],                   
                    Recepient = GetRecepients()[1]
                }
            };
        }

        public static List<Order> GetOrders()
        {
            return new List<Order>
            {
                new Order
                {
                    OrderNumber = new Guid(),                   
                    Sender = "test"
                },
                new Order
                {
                    OrderNumber = new Guid(),                  
                    Sender = "Ikea"
                }
            };
        }

        public static List<Recepient> GetRecepients()
        {           
            return new List<Recepient>
            {
                new Recepient
                {   
                    Id = 11,
                    FirstName = "P",
                    LastName ="Kumar",
                    EmailAddress = "test@test.com",
                    PhoneNumber = "1234567890",
                    Address = "1, test road, sutton, sm5 3ks"
                },
                new Recepient
                {  
                    Id = 12,
                    FirstName = "Patrick",
                    LastName ="Star",
                    EmailAddress = "test@test.com",
                    PhoneNumber = "1234567890",
                    Address = "2, test road, sutton, sm5 3ks"
                }
            };
        }

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DeliveryContext(
                serviceProvider.GetRequiredService<DbContextOptions<DeliveryContext>>()))
            {
                if (context.Deliveries.Any())
                {
                    return;   // Data was already seeded
                }               

                var deliveries = GetDeliveries();                
                context.Users.AddRange(GetUsers());
                context.Deliveries.AddRange(deliveries);

                context.SaveChanges();
            }
        }
    }
}

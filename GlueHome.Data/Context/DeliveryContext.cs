using GlueHome.Model.Delivery;
using GlueHome.Model.Users;
using Microsoft.EntityFrameworkCore;

namespace GlueHome.Data.Context
{
    public class DeliveryContext : DbContext
    {   
        public DeliveryContext(){
        }

        public DeliveryContext (DbContextOptions<DeliveryContext> options)
            : base(options)
        {
        }

        public DbSet<Recepient> Recepients { get; set; }

        public DbSet<Delivery> Deliveries { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<User> Users { get; set; }
    }
}

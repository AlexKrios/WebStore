using Microsoft.EntityFrameworkCore;
using WebStoreAPI.Models;

namespace WebStoreAPI
{
    public class WebStoreContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<City> Cites { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<OrderList> OrderLists { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public WebStoreContext(DbContextOptions options)
            : base(options)
        { }
    }
}

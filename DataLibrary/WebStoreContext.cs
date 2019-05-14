using DataLibrary.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLibrary
{
    public class WebStoreContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<OrderItems> OrdersItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRoles> UsersRoles { get; set; }

        public WebStoreContext(DbContextOptions options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Remove cycles path in Delivery
            modelBuilder.Entity<Delivery>()
                .HasOne(d => d.User)
                .WithMany(u => u.Deliveries)
                .HasForeignKey(d => d.ModifiedBy)
                .OnDelete(DeleteBehavior.Restrict);

            //Remove cycles path in Order
            modelBuilder.Entity<Order>(x =>
                {
                    x.HasOne(o => o.Payment)
                        .WithMany(p => p.Orders)
                        .HasForeignKey(o => o.PaymentId)
                        .OnDelete(DeleteBehavior.Restrict);

                    x.HasOne(o => o.User)
                        .WithMany(u => u.Orders)
                        .HasForeignKey(o => o.UserId)
                        .OnDelete(DeleteBehavior.Restrict);
                }
            );

            //Remove cycles path in OrderItems
            modelBuilder.Entity<OrderItems>()
                .HasOne(o => o.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(o => o.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

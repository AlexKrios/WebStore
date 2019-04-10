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
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public WebStoreContext(DbContextOptions options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>()
                .HasOne(c => c.Country)
                .WithMany(c => c.Cities)
                .HasForeignKey(c => c.CountryId);

            modelBuilder.Entity<Delivery>()
                .HasOne(d => d.User)
                .WithMany(u => u.Deliveries)
                .HasForeignKey(d => d.ModifiedBy)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>(x =>
                {
                    x.HasOne(o => o.Delivery)
                        .WithMany(d => d.Orders)
                        .HasForeignKey(o => o.DeliveryId);

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

            modelBuilder.Entity<OrderItem>(x =>
                {
                    x.HasOne(o => o.Product)
                        .WithMany(p => p.OrderItems)
                        .HasForeignKey(p => p.ProductId)
                        .OnDelete(DeleteBehavior.Restrict);

                    x.HasOne(o => o.Order)
                        .WithMany(p => p.OrderItems)
                        .HasForeignKey(p => p.OrderId);
                }
            );

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.User)
                .WithMany(u => u.Payments)
                .HasForeignKey(d => d.ModifiedBy);

            modelBuilder.Entity<Product>(x =>
                {
                    x.HasOne(p => p.Manufacturer)
                        .WithMany(m => m.Products)
                        .HasForeignKey(p => p.ManufacturerId);

                    x.HasOne(p => p.Type)
                        .WithMany(t => t.Products)
                        .HasForeignKey(p => p.TypeId);

                    x.HasOne(p => p.User)
                        .WithMany(u => u.Products)
                        .HasForeignKey(p => p.ModifiedBy);
                }
            );

            modelBuilder.Entity<User>()
                .HasOne(p => p.City)
                .WithMany(u => u.Users)
                .HasForeignKey(d => d.CityId);

            modelBuilder.Entity<UserRole>(x =>
                {
                    x.HasOne(u => u.User)
                        .WithMany(u => u.UserRoles)
                        .HasForeignKey(u => u.UserId);

                    x.HasOne(u => u.Role)
                        .WithMany(r => r.UserRoles)
                        .HasForeignKey(u => u.RoleId);
                }
            );
        }
    }
}

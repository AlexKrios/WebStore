using Microsoft.EntityFrameworkCore;
using WebStoreAPI.Models;

namespace WebStoreAPI
{
    public class WebStoreContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        public WebStoreContext(DbContextOptions options)
            : base(options)
        { }
    }
}

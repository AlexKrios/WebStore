using Microsoft.EntityFrameworkCore;

namespace WebStoreAPI.Model
{
    public class WebStoreContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public WebStoreContext(DbContextOptions<WebStoreContext> options)
            : base(options)
        { }
    }
}

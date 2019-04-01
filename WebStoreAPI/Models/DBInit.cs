using System.Linq;

namespace WebStoreAPI.Models
{
    public class DBInit
    {
        //Add field in table if table empty
        public static void Init(WebStoreContext context)
        {
            if (!context.Users.Any())
            {
                context.Users.Add(new User { FirstName = "Alex", LastName = "Admin", Role = "Administrator", Age = 23 });
            }

            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product { Name = "Samsung", Model = "S7", Type = "Smartphone", Price = 1000 },
                    new Product { Name = "IPhone", Model = "X", Type = "Smartphone", Price = 1500 },
                    new Product { Name = "Lenovo", Model = "Tab 4", Type = "Tablet", Price = 1250 }
                );
            }
            context.SaveChanges();
        }
    }
}

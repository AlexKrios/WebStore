using System;
using System.Linq;
using WebStoreAPI.Models;

namespace WebStoreAPI
{
    public class DBInit
    {
        //Add field in table if table empty
        public static void Init(WebStoreContext context)
        {
            if (!context.Users.Any())
            {
                context.Users.Add(new User
                {
                    Name = "Alex Krios",
                    Age = 23, Email = "Test@gmail.com",
                    TelephoneNumber = "+375298807848",
                    RegistrationTime = DateTime.Now,
                    Address = "Test address", 
                    CityId = 1,
                    RoleId = 1
                });
            }

            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Samsung S7",
                        Description = "Bla bla bla",
                        Availability = 100,
                        Price = 1000m,
                        TypeId = 1,
                        ManufacturerId = 1
                    },

                    new Product
                    {
                        Name = "IPhone X",
                        Description = "Bla bla bla",
                        Availability = 200,
                        Price = 1500m,
                        TypeId = 1,
                        ManufacturerId = 2
                    },

                    new Product
                    {
                        Name = "Lenovo Tab",
                        Description = "Bla bla bla",
                        Availability = 50,
                        Price = 1250.50m,
                        TypeId = 2,
                        ManufacturerId = 3
                    }
                );
            }
            context.SaveChanges();
        }
    }
}
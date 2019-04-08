using System;
using System.Linq;
using DataLibrary.Entities;

namespace DataLibrary
{
    public class DbInit
    {
        //Add field in table if table empty
        public static void Init(WebStoreContext context)
        {
            if (!context.Cites.Any())
            {
                context.Cites.AddRange(
                    new City
                    {
                        Name = "Grodno"
                    },

                    new City
                    {
                        Name = "Minsk"
                    },

                    new City
                    {
                        Name = "Brest"
                    });
            }

            /*if (!context.Countries.Any())
            {
                context.Countries.Add(
                    new Country
                    {
                        Name = "Belarus",
                    });
            }*/

            if (!context.Deliveries.Any())
            {
                context.Deliveries.Add(
                    new Delivery
                    {
                        Name = "AutoLight",
                        Description = "Test description",
                        Price = 100m,
                        Rating = 4f,
                        CreatedDateTime = DateTime.Now,
                        ModifiedDateTime = DateTime.Now,
                        ModifiedBy = 1
                    });
            }

            if (!context.Manufacturers.Any())
            {
                context.Manufacturers.Add(
                    new Manufacturer
                    {
                        Name = "Samsung INC",
                        Address = "Test address",
                        Contact = "Test contact",
                        Rating = 3f
                    });
            }

            if (!context.Payments.Any())
            {
                context.Payments.Add(
                    new Payment
                    {
                        Name = "Visa",
                        Description = "Test description",
                        Taxes = 1m,
                        CreatedDateTime = DateTime.Now,
                        ModifiedDateTime = DateTime.Now,
                        ModifiedBy = 1
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
                        ManufacturerId = 1,
                        UserId = 1,
                        CreatedDateTime = DateTime.Now,
                        ModifiedDateTime = DateTime.Now,
                        ModifiedBy = 1
                    },

                    new Product
                    {
                        Name = "IPhone X",
                        Description = "Bla bla bla",
                        Availability = 200,
                        Price = 1500m,
                        TypeId = 1,
                        ManufacturerId = 1,
                        UserId = 1,
                        CreatedDateTime = DateTime.Now,
                        ModifiedDateTime = DateTime.Now,
                        ModifiedBy = 1
                    },

                    new Product
                    {
                        Name = "Lenovo Tab",
                        Description = "Bla bla bla",
                        Availability = 50,
                        Price = 1250.50m,
                        TypeId = 1,
                        ManufacturerId = 1,
                        UserId = 1,
                        CreatedDateTime = DateTime.Now,
                        ModifiedDateTime = DateTime.Now,
                        ModifiedBy = 1
                    }
                );
            }

            if (!context.Roles.Any())
            {
                context.Roles.AddRange(
                    new Role
                    {
                        Name = "Admin"
                    },
                    
                    new Role()
                    {
                        Name = "User"
                    });
            }

            if (!context.Types.Any())
            {
                context.Types.Add(
                    new Entities.Type
                    {
                        Name = "Smart-phone"
                    });
            }

            if (!context.Users.Any())
            {
                context.Users.Add(new User
                {
                    Name = "Alex Krios",
                    Age = 23,
                    Email = "Test@gmail.com",
                    TelephoneNumber = "+375298807848",
                    RegistrationTime = DateTime.Now,
                    Address = "Test address",
                    CityId = 1
                });
            }

            if (!context.UserRoles.Any())
            {
                context.UserRoles.Add(
                    new UserRole
                    {
                        UserId = 1,
                        RoleId = 1
                    });
            }

            context.SaveChanges();
        }
    }
}
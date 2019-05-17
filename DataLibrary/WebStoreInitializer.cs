using System;
using System.Linq;
using DataLibrary.Entities;

namespace DataLibrary
{
    public static class WebStoreInitializer
    {
        //Add field in table if table empty
        public static void Seed(WebStoreContext context)
        {
            if (!context.Countries.Any())
            {
                context.Countries.Add(
                    new Country
                    {
                        Name = "Belarus"
                    });
            }
            context.SaveChanges();

            if (!context.Cities.Any())
            {
                context.Cities.AddRange(
                    new City
                    {
                        Name = "Grodno",
                        CountryId = 1
                    },

                    new City
                    {
                        Name = "Minsk",
                        CountryId = 1
                    },

                    new City
                    {
                        Name = "Brest",
                        CountryId = 1
                    });
            }
            context.SaveChanges();

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
            context.SaveChanges();

            if (!context.Roles.Any())
            {
                context.Roles.AddRange(
                    new Role
                    {
                        Name = "Admin"
                    },

                    new Role
                    {
                        Name = "User"
                    });
            }
            context.SaveChanges();

            if (!context.Users.Any())
            {
                context.Users.Add(new User
                {
                    Name = "Alex Krios",
                    Password = "pass",
                    Age = 23,
                    Email = "Test@gmail.com",
                    TelephoneNumber = "+375298807848",
                    RegistrationTime = DateTime.Now,
                    Address = "Test address",
                    CityId = 1
                });
            }
            context.SaveChanges();

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
            context.SaveChanges();

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
            context.SaveChanges();

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

            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Samsung S7",
                        Description = "Bla bla bla",
                        Availability = 100,
                        Price = 1000m,
                        ManufacturerId = 1,
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
                        ManufacturerId = 1,
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
                        ManufacturerId = 1,
                        CreatedDateTime = DateTime.Now,
                        ModifiedDateTime = DateTime.Now,
                        ModifiedBy = 1
                    }
                );
            }
            context.SaveChanges();

            if (!context.Orders.Any())
            {
                context.Orders.Add(
                    new Order
                    {
                        CustomerNumber = "Num",
                        Note = "Note",
                        TotalPrice = 5000,
                        OrderTime = DateTime.Now,
                        UserId = 1,
                        DeliveryId = 1,
                        PaymentId = 1
                    });
            }
            context.SaveChanges();

            if (!context.OrderItems.Any())
            {
                context.OrderItems.Add(
                    new OrderItem
                    {
                        Count = 3,
                        Price = 1500,
                        ProductId = 1,
                        OrderId = 1
                    });
            }
            context.SaveChanges();
        }
    }
}
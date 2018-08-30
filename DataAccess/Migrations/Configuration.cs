namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        
        protected override void Seed(DataAccess.AppDbContext context)
        { 

            // Seeding Dummy Data for Testing purposes

            SeedUser(context);

            SeedProduct(context);

            SeedCustomer(context);
        }

        private static void SeedUser(AppDbContext context)
        {
            context.Users
               .AddOrUpdate(
                new User
                {
                    UserName = "admin",
                    Password = "123",
                    IsAdmin = true,
                    FirstName = "fname",
                    LastName = "lname",
                    BirthDate = DateTime.Now,
                    Contact = 4546,
                    Email = "testing@gmail.com",
                    Gender = "Male"
                    
                },
                new User
                {
                    UserName = "user",
                    Password = "123",
                    IsAdmin = false,
                    FirstName = "fname",
                    LastName = "lname",
                    BirthDate = DateTime.Now,
                    Contact = 4546,
                    Email = "testing@gmail.com",
                    Gender = "Male"
                    
                }
            );
        }

        private static void SeedCustomer(AppDbContext context)
        {
            context.Customers
               .AddOrUpdate(
                new Customer
                {
                   
                    FirstName = "fname",
                    LastName = "lname",
                    BirthDate = new DateTime(2000, 10, 13),
                    Contact = 4546,
                    Email = "testing@gmail.com",
                    Gender = "Male"
                    
                },
                new Customer
                {
                    FirstName = "fname",
                    LastName = "lname",
                    BirthDate = new DateTime(2003, 10, 13),
                    Contact = 4546,
                    Email = "testing@gmail.com",
                    Gender = "Male"
                }
            );
        }

        private static void SeedProduct(AppDbContext context)
        {
            context.Products
              .AddOrUpdate(
               new Product
               {
                    CodeItem = "Product1",
                    Description = "description",
                    Quantity = 5,
                    Price = 95.6,
                    Supplier = new Supplier { Name = "Sup1" },
                    DatePurchased = DateTime.Now,
                    Image  = "hero.jpeg"
               },
               new Product
               {
                   CodeItem = "Product2",
                   Description = "description",
                   Quantity = 4,
                   Price = 77.6,
                   Supplier = new Supplier { Name = "Sup2" },
                   DatePurchased = DateTime.Now,
                   Image = "hero.jpeg"
               }
            );
        }
    }
}

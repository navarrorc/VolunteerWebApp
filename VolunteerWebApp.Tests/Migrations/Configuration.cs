namespace VolunteerWebApp.Tests.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MyDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Volunteers.AddOrUpdate(
                v => v.FirstName,
                new Volunteer { 
                    FirstName="Roberto", 
                    LastName="Navarro", 
                    HomePhone = "210-555-4444",
                    CellPhone = "210-555-4444", 
                    HomeAddress="8000 Forest Hill Dr Live Oak TX 78233",
                    WorkAddress = "1355 Central Pkwy N, San Antonio, TX, 78232", 
                    StartDate=DateTime.Now, 
                    EndDate=DateTime.Now.AddDays(30) 
                },
                new Volunteer { 
                    FirstName="Roy Serna", 
                    LastName="Navarro", 
                    HomePhone = "210-666-7777",
                    CellPhone = "210-555-4444", 
                    HomeAddress="8001 Forest Hill Dr Live Oak TX 78233",
                    WorkAddress = "1355 Central Pkwy N, San Antonio, TX, 78232",
                    StartDate=DateTime.Now, 
                    EndDate=DateTime.Now.AddDays(30)
                },
                new Volunteer
                {
                    FirstName = "Hilario",
                    LastName = "Urquieta",
                    HomePhone = "210-333-9990",
                    CellPhone = "210-555-4444", 
                    HomeAddress = "8002 Forest Hill Dr Live Oak TX 78233",
                    WorkAddress = "1355 Central Pkwy N, San Antonio, TX, 78232",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(30)
                }
                );

        }
    }
}

using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VolunteerWebApp.Models;
using System.Data.Entity;
using VolunteerWebApp.Tests.Migrations;
using System.Collections;

namespace VolunteerWebApp.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void InitalizeDb() 
        {
            // Init Database, run the Seed Method
           // Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyDbContext, Configuration>());
        }

        [TestMethod]
        public void TestMethod1()
        {
            IEnumerable data;
            using(var ctx = new MyDbContext())
            {
                data = ctx.Volunteers.ToList(); // helps create the database when its run
            }

            Assert.IsNotNull(data, "No records found!");
        }
    }
}

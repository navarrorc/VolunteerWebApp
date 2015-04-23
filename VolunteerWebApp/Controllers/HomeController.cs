using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VolunteerWebApp.Migrations;
using VolunteerWebApp.Models;

namespace VolunteerWebApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {

            // Init Database, run the Seed Method
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyDbContext, Configuration>());

            HomeVM model = new HomeVM();
            using (var ctx = new MyDbContext())
            {
                model.Volunteers = ctx.Volunteers.ToList();
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(HomeVM data)
        {
            HomeVM model = new HomeVM();

            var firstName = data.Volunteer.FirstName == null ? "" : data.Volunteer.FirstName.ToUpper();
            var lastName = data.Volunteer.LastName == null ? "" : data.Volunteer.LastName.ToUpper();
            var startDate = data.Volunteer.StartDate;
            var endDate = data.Volunteer.EndDate;

            using (var ctx = new MyDbContext())
            {
                if (firstName != "" || lastName != "")
                {
                    model.Volunteers = ctx.Volunteers.Where(v => v.FirstName.ToUpper() == firstName || v.LastName == lastName).ToList();
                }
                else if (startDate != null || endDate != null)
                {                    
                    startDate = startDate != null ? startDate.Value.Date : (DateTime?)null;
                    endDate = endDate != null ? endDate.Value.Date : (DateTime?)null;

                    model.Volunteers = ctx.Volunteers.Where(v => DbFunctions.TruncateTime(v.StartDate) == startDate 
                        || DbFunctions.TruncateTime(v.EndDate) == endDate ).ToList();
                }
                else
                {
                    model.Volunteers = ctx.Volunteers.ToList();
                }

            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Volunteer data)
        {
            using (var ctx = new MyDbContext())
            {
                ctx.Volunteers.Add(data);
                ctx.SaveChanges();
            }

            HomeVM model = new HomeVM();
            using (var ctx = new MyDbContext())
            {
                model.Volunteers = ctx.Volunteers.ToList();
            }

            return RedirectToAction("Index");            
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            Volunteer data;
            using (var ctx = new MyDbContext())
            {
                data = ctx.Volunteers.FirstOrDefault(v => v.VolunteerId == Id);
            }

            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(Volunteer data)
        {
            HomeVM model = new HomeVM();
            using (var ctx = new MyDbContext())
            {
                ctx.Volunteers.Attach(data);
                var entry = ctx.Entry(data);
                entry.State = EntityState.Modified;
                ctx.SaveChanges();

                model.Volunteers = ctx.Volunteers.ToList();
            }
            
            return RedirectToAction("Index");
        }

        public ActionResult Details(int Id)
        {
            Volunteer model;
            using (var ctx = new MyDbContext())
            {
                model = ctx.Volunteers.FirstOrDefault(v => v.VolunteerId == Id);
            }
            return View(model);
        }

        public ActionResult Delete(int Id)
        {
            HomeVM model = new HomeVM();
            using (var ctx = new MyDbContext())
            {
                var volunteer = ctx.Volunteers.FirstOrDefault(v => v.VolunteerId == Id);
                ctx.Volunteers.Attach(volunteer);
                ctx.Volunteers.Remove(volunteer);
                ctx.SaveChanges();

                model.Volunteers = ctx.Volunteers.ToList();
            }

            return RedirectToAction("Index");
        }
    }
}

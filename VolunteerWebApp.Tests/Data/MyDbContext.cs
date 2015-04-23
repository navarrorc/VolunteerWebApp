using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


public class MyDbContext : DbContext
{
    public MyDbContext()
        : base("VolunteerDb")
    {
    }

    public DbSet<Volunteer> Volunteers { get; set; }


}

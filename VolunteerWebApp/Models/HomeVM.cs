using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VolunteerWebApp.Models
{
    public class HomeVM
    {
        public IEnumerable<Volunteer> Volunteers { get; set; }
        public Volunteer Volunteer { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VolunteerSystem.DAL;
using VolunteerSystem.ViewModels;
namespace VolunteerSystem.Controllers
{
   


    public class HomeController : Controller

    {
        private CompanyContext db = new CompanyContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            IQueryable<EnrollmentDateGroup> data = from volunteer in db.Volunteers
                                                   group volunteer by volunteer.EnrollmentDate into dateGroup
                                                   select new EnrollmentDateGroup()
                                                   {
                                                       EnrollmentDate = dateGroup.Key,
                                                       VolunteerCount = dateGroup.Count()
                                                   };
            return View(data.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
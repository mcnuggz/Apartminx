using Apartment.Models;
using System.Web.Mvc;

namespace Apartment.Controllers
{
    public class ApplicationController : Controller
    {
        private ApartmentContext db = new ApartmentContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Payment()
        {
            return View();
        }

        public ActionResult Complete()
        {
            return View();
        }
    }
}
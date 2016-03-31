using Apartment.Models;
using Apartment.Utilities;
using System.Web.Mvc;

namespace Apartment.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Amenities()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(EmailForm model)
        {
            if (ModelState.IsValid)
            {
                Mailer.SendUserEmail(model.FromName, model.FromEmail, model.Subject, model.Message);
                return RedirectToAction("Sent");
            }
            return View(model);
        }

        public ActionResult Sent()
        {
            return View();
        }
    }
}
using System.Web.Mvc;

namespace Apartment.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult MyProfile()
        {
            return View();
        }
    }
}
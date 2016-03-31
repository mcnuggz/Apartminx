using System.Web.Mvc;

namespace Apartment.Controllers
{
    public class DepositController : Controller
    {
        // GET: Deposit
        public ActionResult Deposit()
        {
            return View();
        }

        public ActionResult Complete()
        {
            return View();
        }
    }
}
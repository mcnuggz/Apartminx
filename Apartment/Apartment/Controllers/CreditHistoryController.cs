using Apartment.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Apartment.Controllers
{
    [Authorize(Roles ="Admin, Landlord")]
    public class CreditHistoryController : Controller
    {
        private ApartmentContext db = new ApartmentContext();

        // GET: CreditHistory
        public ActionResult Index()
        {
            return View(db.CreditHistories.ToList());
        }

        // GET: CreditHistory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreditHistory creditHistory = db.CreditHistories.Find(id);
            if (creditHistory == null)
            {
                return HttpNotFound();
            }
            return View(creditHistory);
        }

        // GET: CreditHistory/Create
        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CreditHistory/Create
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BankName,City,State,SocialSecurity,OtherComments")] CreditHistory creditHistory)
        {
            if (ModelState.IsValid)
            {
                db.CreditHistories.Add(creditHistory);
                db.SaveChanges();
                return RedirectToAction("Create", "CriminalHistory");
            }

            return View(creditHistory);
        }

        // GET: CreditHistory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreditHistory creditHistory = db.CreditHistories.Find(id);
            if (creditHistory == null)
            {
                return HttpNotFound();
            }
            return View(creditHistory);
        }

        // POST: CreditHistory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BankName,City,State,SocialSecurity,OtherComments")] CreditHistory creditHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(creditHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(creditHistory);
        }

        // GET: CreditHistory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreditHistory creditHistory = db.CreditHistories.Find(id);
            if (creditHistory == null)
            {
                return HttpNotFound();
            }
            return View(creditHistory);
        }

        // POST: CreditHistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CreditHistory creditHistory = db.CreditHistories.Find(id);
            db.CreditHistories.Remove(creditHistory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

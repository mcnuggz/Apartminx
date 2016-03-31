using Apartment.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Apartment.Controllers
{
    [Authorize(Roles ="Admin, Landlord")]
    public class WhyAppliedController : Controller
    {
        private ApartmentContext db = new ApartmentContext();

        // GET: WhyApplieds
        public ActionResult Index()
        {
            return View(db.WhyApplieds.ToList());
        }

        // GET: WhyApplieds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WhyApplied whyApplied = db.WhyApplieds.Find(id);
            if (whyApplied == null)
            {
                return HttpNotFound();
            }
            return View(whyApplied);
        }

        // GET: WhyApplieds/Create
        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }

        // POST: WhyApplieds/Create
        
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,WasReferred,RentalAgency,LocalAgency,OtherPerson,NoReferral,OnInternet,StoppedBy,Newspaper,NewspaperName,RentalPublication,PublicaitonName,Other,OtherDetails")] WhyApplied whyApplied)
        {
            if (ModelState.IsValid)
            {
                db.WhyApplieds.Add(whyApplied);
                db.SaveChanges();
                return RedirectToAction("Create", "EmergencyContact");
            }

            return View(whyApplied);
        }

        // GET: WhyApplieds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WhyApplied whyApplied = db.WhyApplieds.Find(id);
            if (whyApplied == null)
            {
                return HttpNotFound();
            }
            return View(whyApplied);
        }

        // POST: WhyApplieds/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,WasReferred,RentalAgency,LocalAgency,OtherPerson,NoReferral,OnInternet,StoppedBy,Newspaper,NewspaperName,RentalPublication,PublicaitonName,Other,OtherDetails")] WhyApplied whyApplied)
        {
            if (ModelState.IsValid)
            {
                db.Entry(whyApplied).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(whyApplied);
        }

        // GET: WhyApplieds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WhyApplied whyApplied = db.WhyApplieds.Find(id);
            if (whyApplied == null)
            {
                return HttpNotFound();
            }
            return View(whyApplied);
        }

        // POST: WhyApplieds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WhyApplied whyApplied = db.WhyApplieds.Find(id);
            db.WhyApplieds.Remove(whyApplied);
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

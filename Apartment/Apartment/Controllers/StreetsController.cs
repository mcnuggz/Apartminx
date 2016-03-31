using Apartment.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Apartment.Controllers
{
    [Authorize(Roles ="Admin")]
    public class StreetsController : Controller
    {
        private ApartmentContext db = new ApartmentContext();

        // GET: Streets
        public ActionResult Index()
        {
            return View(db.Streets.ToList());
        }

        // GET: Streets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Streets/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Street street)
        {
            if (ModelState.IsValid)
            {
                db.Streets.Add(street);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(street);
        }

        // GET: Streets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Street street = db.Streets.Find(id);
            if (street == null)
            {
                return HttpNotFound();
            }
            return View(street);
        }

        // POST: Streets/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Street street)
        {
            if (ModelState.IsValid)
            {
                db.Entry(street).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(street);
        }

        // GET: Streets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Street street = db.Streets.Find(id);
            if (street == null)
            {
                return HttpNotFound();
            }
            return View(street);
        }

        // POST: Streets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Street street = db.Streets.Find(id);
            db.Streets.Remove(street);
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

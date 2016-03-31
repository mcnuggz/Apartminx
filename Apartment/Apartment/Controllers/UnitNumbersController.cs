using Apartment.Models;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Apartment.Controllers
{
    [Authorize(Roles ="Admin")]
    public class UnitNumbersController : Controller
    {
        private ApartmentContext db = new ApartmentContext();

        // GET: UnitNumbers
        public ActionResult Index()
        {
            return View(db.Units.OrderBy(x => x.Unit).ToList());
        }

        // GET: UnitNumbers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UnitNumbers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Unit")] UnitNumber unitNumber)
        {
            if (ModelState.IsValid)
            {
                db.Units.Add(unitNumber);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(unitNumber);
        }

        // GET: UnitNumbers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnitNumber unitNumber = db.Units.Find(id);
            if (unitNumber == null)
            {
                return HttpNotFound();
            }
            return View(unitNumber);
        }

        // POST: UnitNumbers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Unit")] UnitNumber unitNumber)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unitNumber).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(unitNumber);
        }

        // GET: UnitNumbers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnitNumber unitNumber = db.Units.Find(id);
            if (unitNumber == null)
            {
                return HttpNotFound();
            }
            return View(unitNumber);
        }

        // POST: UnitNumbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UnitNumber unitNumber = db.Units.Find(id);
            db.Units.Remove(unitNumber);
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

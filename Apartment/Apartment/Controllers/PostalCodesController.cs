using Apartment.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Apartment.Controllers
{
    [Authorize(Roles ="Admin")]
    public class PostalCodesController : Controller
    {
        private ApartmentContext db = new ApartmentContext();

        // GET: PostalCodes
        public ActionResult Index()
        {
            return View(db.ZipCodes.ToList());
        }

        // GET: PostalCodes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PostalCodes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Zip")] PostalCode postalCode)
        {
            if (ModelState.IsValid)
            {
                db.ZipCodes.Add(postalCode);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(postalCode);
        }

        // GET: PostalCodes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostalCode postalCode = db.ZipCodes.Find(id);
            if (postalCode == null)
            {
                return HttpNotFound();
            }
            return View(postalCode);
        }

        // POST: PostalCodes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Zip")] PostalCode postalCode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(postalCode).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(postalCode);
        }

        // GET: PostalCodes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostalCode postalCode = db.ZipCodes.Find(id);
            if (postalCode == null)
            {
                return HttpNotFound();
            }
            return View(postalCode);
        }

        // POST: PostalCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PostalCode postalCode = db.ZipCodes.Find(id);
            db.ZipCodes.Remove(postalCode);
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

using Apartment.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Apartment.Controllers
{
    [Authorize(Roles ="Admin, Landlord")]
    public class EmergencyContactController : Controller
    {
        private ApartmentContext db = new ApartmentContext();

        // GET: EmergencyContact
        public ActionResult Index()
        {
            return View(db.EmergencyContacts.ToList());
        }

        // GET: EmergencyContact/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmergencyContact emergencyContact = db.EmergencyContacts.Find(id);
            if (emergencyContact == null)
            {
                return HttpNotFound();
            }
            return View(emergencyContact);
        }

        // GET: EmergencyContact/Create
        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmergencyContact/Create
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Relationship,Phone,Name2,Relationship2,Phone2,Name3,Relationship3,Phone3")] EmergencyContact emergencyContact)
        {
            if (ModelState.IsValid)
            {
                db.EmergencyContacts.Add(emergencyContact);
                db.SaveChanges();
                return RedirectToAction("Create", "Authorization");
            }

            return View(emergencyContact);
        }

        // GET: EmergencyContact/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmergencyContact emergencyContact = db.EmergencyContacts.Find(id);
            if (emergencyContact == null)
            {
                return HttpNotFound();
            }
            return View(emergencyContact);
        }

        // POST: EmergencyContact/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Relationship,Phone,Name2,Relationship2,Phone2,Name3,Relationship3,Phone3")] EmergencyContact emergencyContact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emergencyContact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emergencyContact);
        }

        // GET: EmergencyContact/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmergencyContact emergencyContact = db.EmergencyContacts.Find(id);
            if (emergencyContact == null)
            {
                return HttpNotFound();
            }
            return View(emergencyContact);
        }

        // POST: EmergencyContact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmergencyContact emergencyContact = db.EmergencyContacts.Find(id);
            db.EmergencyContacts.Remove(emergencyContact);
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

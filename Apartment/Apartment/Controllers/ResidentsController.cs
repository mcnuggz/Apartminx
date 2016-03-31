using Apartment.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Apartment.Controllers
{
    [Authorize(Roles ="Admin, Landlord")]
    public class ResidentsController : Controller
    {
        private ApartmentContext db = new ApartmentContext();

        // GET: Residents
        public ActionResult Index()
        {
            var residents = db.Residents.Include(r => r.PetCost);
            return View(residents.ToList());
        }

        // GET: Residents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resident resident = db.Residents.Find(id);
            if (resident == null)
            {
                return HttpNotFound();
            }
            return View(resident);
        }

        [AllowAnonymous]
        // GET: Residents/Create
        public ActionResult Create()
        {
            
     
            ViewBag.PetCostId = new SelectList(db.PetCosts, "Id", "Id");
            return View();
        }

        // POST: Residents/Create
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Name,PhoneNumber,Email,HasPets,petCount,AddressId,PetCostId")] Resident resident)
        {
            if (ModelState.IsValid)
            {
                db.Residents.Add(resident);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.PetCostId = new SelectList(db.PetCosts, "Id", "Id", resident.PetCostId);
            return View(resident);
        }

        // GET: Residents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resident resident = db.Residents.Find(id);
            if (resident == null)
            {
                return HttpNotFound();
            }
            ViewBag.PetCostId = new SelectList(db.PetCosts, "Id", "Id", resident.PetCostId);
            return View(resident);
        }

        // POST: Residents/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Name,PhoneNumber,Email,HasPets,petCount,AddressId,PetCostId")] Resident resident)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resident).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PetCostId = new SelectList(db.PetCosts, "Id", "Id", resident.PetCostId);
            return View(resident);
        }

        // GET: Residents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resident resident = db.Residents.Find(id);
            if (resident == null)
            {
                return HttpNotFound();
            }
            return View(resident);
        }

        // POST: Residents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resident resident = db.Residents.Find(id);
            db.Residents.Remove(resident);
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

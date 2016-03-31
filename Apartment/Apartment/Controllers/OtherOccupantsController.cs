using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Apartment.Models;

namespace Apartment.Controllers
{
    [Authorize(Roles ="Admin, Landlord")]
    public class OtherOccupantsController : Controller
    {
        private ApartmentContext db = new ApartmentContext();

        // GET: OtherOccupants
        public ActionResult Index()
        {
            return View(db.OtherOccupants.ToList());
        }

        // GET: OtherOccupants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OtherOccupants otherOccupants = db.OtherOccupants.Find(id);
            if (otherOccupants == null)
            {
                return HttpNotFound();
            }
            return View(otherOccupants);
        }

        // GET: OtherOccupants/Create
        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }

        // POST: OtherOccupants/Create
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Relationship,Gender,Birthdate,IDNum,State,Name2,Relationship2,Gender2,Birthdate2,IDNum2,State2,Name3,Relationship3,Gender3,Birthdate3,IDNum3,State3")] OtherOccupants otherOccupants)
        {
            if (ModelState.IsValid)
            {
                db.OtherOccupants.Add(otherOccupants);
                db.SaveChanges();
                return RedirectToAction("Create", "Vehicles");
            }

            return View(otherOccupants);
        }

        // GET: OtherOccupants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OtherOccupants otherOccupants = db.OtherOccupants.Find(id);
            if (otherOccupants == null)
            {
                return HttpNotFound();
            }
            return View(otherOccupants);
        }

        // POST: OtherOccupants/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Relationship,Gender,Birthdate,IDNum,State,Name2,Relationship2,Gender2,Birthdate2,IDNum2,State2,Name3,Relationship3,Gender3,Birthdate3,IDNum3,State3")] OtherOccupants otherOccupants)
        {
            if (ModelState.IsValid)
            {
                db.Entry(otherOccupants).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(otherOccupants);
        }

        // GET: OtherOccupants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OtherOccupants otherOccupants = db.OtherOccupants.Find(id);
            if (otherOccupants == null)
            {
                return HttpNotFound();
            }
            return View(otherOccupants);
        }

        // POST: OtherOccupants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OtherOccupants otherOccupants = db.OtherOccupants.Find(id);
            db.OtherOccupants.Remove(otherOccupants);
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

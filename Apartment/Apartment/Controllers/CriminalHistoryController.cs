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
    public class CriminalHistoryController : Controller
    {
        private ApartmentContext db = new ApartmentContext();

        // GET: CriminalHistory
        public ActionResult Index()
        {
            return View(db.CriminalHistories.ToList());
        }

        // GET: CriminalHistory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CriminalHistory criminalHistory = db.CriminalHistories.Find(id);
            if (criminalHistory == null)
            {
                return HttpNotFound();
            }
            return View(criminalHistory);
        }

        // GET: CriminalHistory/Create
        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CriminalHistory/Create
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Evicted,EarlyMoveOut,Bankrupt,SuedForRent,SuedForDamage,RegisteredSexOffender,ArrestedForViolence,ArrestedForFelony,ArrestInformation")] CriminalHistory criminalHistory)
        {
            if (ModelState.IsValid)
            {
                db.CriminalHistories.Add(criminalHistory);
                db.SaveChanges();
                return RedirectToAction("Create", "Spouse");
            }

            return View(criminalHistory);
        }

        // GET: CriminalHistory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CriminalHistory criminalHistory = db.CriminalHistories.Find(id);
            if (criminalHistory == null)
            {
                return HttpNotFound();
            }
            return View(criminalHistory);
        }

        // POST: CriminalHistory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Evicted,EarlyMoveOut,Bankrupt,SuedForRent,SuedForDamage,RegisteredSexOffender,ArrestedForViolence,ArrestedForFelony,ArrestInformation")] CriminalHistory criminalHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(criminalHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(criminalHistory);
        }

        // GET: CriminalHistory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CriminalHistory criminalHistory = db.CriminalHistories.Find(id);
            if (criminalHistory == null)
            {
                return HttpNotFound();
            }
            return View(criminalHistory);
        }

        // POST: CriminalHistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CriminalHistory criminalHistory = db.CriminalHistories.Find(id);
            db.CriminalHistories.Remove(criminalHistory);
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

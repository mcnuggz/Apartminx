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
    public class SpouseController : Controller
    {
        private ApartmentContext db = new ApartmentContext();

        // GET: Spouse
        public ActionResult Index()
        {
            return View(db.Spouses.ToList());
        }

        // GET: Spouse/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spouse spouse = db.Spouses.Find(id);
            if (spouse == null)
            {
                return HttpNotFound();
            }
            return View(spouse);
        }

        // GET: Spouse/Create
        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Spouse/Create
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IsMarried,FirstName,MiddleName,LastName,FormerNames,SpouseSecurity,SpouseDriverLicense,State,GovtId,Birthdate,Height,Weight,Gender,EyeColor,USCitizen,SpouseEmployed,Employer,Address,City,WorkState,Zip,WorkPhone,Position,StartDate,GrossIncome,SupervisorName,SupervisorPhone")] Spouse spouse)
        {
            if (ModelState.IsValid)
            {
                db.Spouses.Add(spouse);
                db.SaveChanges();
                return RedirectToAction("Create", "OtherOccupants");
            }

            return View(spouse);
        }

        // GET: Spouse/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spouse spouse = db.Spouses.Find(id);
            if (spouse == null)
            {
                return HttpNotFound();
            }
            return View(spouse);
        }

        // POST: Spouse/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IsMarried,FirstName,MiddleName,LastName,FormerNames,SpouseSecurity,SpouseDriverLicense,State,GovtId,Birthdate,Height,Weight,Gender,EyeColor,USCitizen,SpouseEmployed,Employer,Address,City,WorkState,Zip,WorkPhone,Position,StartDate,GrossIncome,SupervisorName,SupervisorPhone")] Spouse spouse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(spouse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(spouse);
        }

        // GET: Spouse/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spouse spouse = db.Spouses.Find(id);
            if (spouse == null)
            {
                return HttpNotFound();
            }
            return View(spouse);
        }

        // POST: Spouse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Spouse spouse = db.Spouses.Find(id);
            db.Spouses.Remove(spouse);
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

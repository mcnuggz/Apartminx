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
    public class WorkHistoryController : Controller
    {
        private ApartmentContext db = new ApartmentContext();

        // GET: WorkHistory
        public ActionResult Index()
        {
            return View(db.WorkHistories.ToList());
        }

        // GET: WorkHistory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkHistory workHistory = db.WorkHistories.Find(id);
            if (workHistory == null)
            {
                return HttpNotFound();
            }
            return View(workHistory);
        }

        // GET: WorkHistory/Create
        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkHistory/Create
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PresentlyEmployed,Employer,Address,City,State,ZipCode,WorkPhone,Position,GrossIncome,BeginDate,SupervisorName,SupervisorNumber,PreviouslyEmployed,PreviousEmployer,PrevAddress,PrevCity,PrevState,PrevZip,PrevWorkPhone,PrevPosition,PrevIncome,PrevStartDate,PrevEndDate,PrevSupervisor,PrevPhoneNumber")] WorkHistory workHistory)
        {
            if (ModelState.IsValid)
            {
                db.WorkHistories.Add(workHistory);
                db.SaveChanges();
                return RedirectToAction("Create", "CreditHistory");
            }

            return View(workHistory);
        }

        // GET: WorkHistory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkHistory workHistory = db.WorkHistories.Find(id);
            if (workHistory == null)
            {
                return HttpNotFound();
            }
            return View(workHistory);
        }

        // POST: WorkHistory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PresentlyEmployed,Employer,Address,City,State,ZipCode,WorkPhone,Position,GrossIncome,BeginDate,SupervisorName,SupervisorNumber,PreviouslyEmployed,PreviousEmployer,PrevAddress,PrevCity,PrevState,PrevZip,PrevWorkPhone,PrevPosition,PrevIncome,PrevStartDate,PrevEndDate,PrevSupervisor,PrevPhoneNumber")] WorkHistory workHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workHistory);
        }

        // GET: WorkHistory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkHistory workHistory = db.WorkHistories.Find(id);
            if (workHistory == null)
            {
                return HttpNotFound();
            }
            return View(workHistory);
        }

        // POST: WorkHistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkHistory workHistory = db.WorkHistories.Find(id);
            db.WorkHistories.Remove(workHistory);
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

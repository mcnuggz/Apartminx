using Apartment.Models;
using Apartment.Utilities;
using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Apartment.Controllers
{
    [Authorize(Roles = "Landlord")]
    public class CasesController : Controller
    {
        private ApartmentContext db = new ApartmentContext();
        private string thankyouMessage = "<p>Thank you for visiting DevCode Apartments. You can apply online with the link below!</p><p><a href='http://localhost:17455/TenantInformation/Create/' target='_blank'>Application</a></p>";

        private string depositMessage = "<p>You have been approved! But first, we must receive your security deposit. Click the link below to continue.</p><p><a href='http://localhost:17455/Deposit/Deposit' target='_blank'>Pay Your Security Deposit</a></p><p>If we do not hear from you within two weeks, we will assume you have changed your mind and we will close your case.";

        private string receivedDeposit = "We have received your deposit. Please come in at your earliest convience so we can finish the paperwork and discuss your move-in date.";

        private string welcomeAboard = "<p>Welcome to the community! Between now and when you move in, please register an account (if you haven't already) using the link below. As a reminder, your first months' rent is due when you pick up your keys.</p><p><a href='http://localhost:17455/Account/Register'>Register A New Account!</a></p>";
        // GET: Cases
        public ActionResult Index()
        {
            return View(db.Cases.ToList());
        }

        // GET: Cases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case @case = db.Cases.Find(id);
            if (@case == null)
            {
                return HttpNotFound();
            }
            return View(@case);
        }

        // GET: Cases/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cases/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,ApplicationFilled,BackgroundStatus,CreditReportStatus,LeaseSigned,Status")] Case @case, HttpPostedFileBase file)
        {

            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    string lease = Path.GetFileName(file.FileName);
                    string path = Path.Combine(Server.MapPath("~/Leases"), lease);
                    file.SaveAs(path);
                    @case.LeasePath = file.FileName;
                }

                db.Cases.Add(@case);
                db.SaveChanges();
                Mailer.SendLink("Thank you for visiting!", @case.Email, thankyouMessage);
                return RedirectToAction("Index");
            }

            return View(@case);
        }

        // GET: Cases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case @case = db.Cases.Find(id);
            if (@case == null)
            {
                return HttpNotFound();
            }
            return View(@case);
        }

        // POST: Cases/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,ApplicationFilled,BackgroundStatus,CreditReportStatus,LeaseSigned,Status")] Case @case, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    string lease = Path.GetFileName(file.FileName);
                    string path = Path.Combine(Server.MapPath("~/Leases"), lease);
                    file.SaveAs(path);
                    @case.LeasePath = file.FileName;
                }

                db.Entry(@case).State = EntityState.Modified;
                db.SaveChanges();
                if (@case.Status == Case.AppStatus.WaitingForDeposit)
                {
                    Mailer.SendLink("You're approved!", @case.Email, depositMessage);
                }
                else if (@case.Status == Case.AppStatus.DepositReceived)
                {
                    Mailer.SendLink("Payment Received", @case.Email, receivedDeposit);
                }
                else if (@case.Status == Case.AppStatus.LeaseSigned)
                {
                    Mailer.SendLink("Welcome aboard!", @case.Email, welcomeAboard);
                }
                return RedirectToAction("Index");
            }
            return View(@case);
        }

        // GET: Cases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case @case = db.Cases.Find(id);
            if (@case == null)
            {
                return HttpNotFound();
            }
            return View(@case);
        }

        // POST: Cases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Case @case = db.Cases.Find(id);
            db.Cases.Remove(@case);
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

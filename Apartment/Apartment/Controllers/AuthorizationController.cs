using Apartment.Models;
using Apartment.Utilities;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Apartment.Controllers
{
    
    public class AuthorizationController : Controller
    {
        private ApartmentContext db = new ApartmentContext();

        private string pendingApprovalMessage = "Thank you for submitting your application. We will contact you shortly.";
        [Authorize(Roles = "Admin, Landlord")]
        // GET: Authorization
        public ActionResult Index()
        {
            return View(db.Authorizations.ToList());
        }
        [Authorize(Roles = "Admin, Landlord")]
        // GET: Authorization/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Authorization authorization = db.Authorizations.Find(id);
            if (authorization == null)
            {
                return HttpNotFound();
            }
            return View(authorization);
        }

        // GET: Authorization/Create
        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authorization/Create
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,Phone,AcceptTerms,ESignature,SpouseSignature,AdditionalComments")] Models.Authorization authorization)
        {
            if (ModelState.IsValid)
            {
                db.Authorizations.Add(authorization);
                db.SaveChanges();
                Mailer.SendEmail(authorization.ESignature, authorization.Email);
                Mailer.SendLink("We're Reviewing Your Application", authorization.Email, pendingApprovalMessage);
                return RedirectToAction("Payment", "Application");
            }

            return View(authorization);
        }

        // GET: Authorization/Edit/5
        [Authorize(Roles = "Admin, Landlord")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Authorization authorization = db.Authorizations.Find(id);
            if (authorization == null)
            {
                return HttpNotFound();
            }
            return View(authorization);
        }

        // POST: Authorization/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Landlord")]
        public ActionResult Edit([Bind(Include = "Id,Email,Phone,AcceptTerms,ESignature,SpouseSignature,AdditionalComments")] Models.Authorization authorization)
        {
            if (ModelState.IsValid)
            {
                db.Entry(authorization).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(authorization);
        }

        // GET: Authorization/Delete/5
        [Authorize(Roles = "Admin, Landlord")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Authorization authorization = db.Authorizations.Find(id);
            if (authorization == null)
            {
                return HttpNotFound();
            }
            return View(authorization);
        }

        // POST: Authorization/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Landlord")]
        public ActionResult DeleteConfirmed(int id)
        {
            Models.Authorization authorization = db.Authorizations.Find(id);
            db.Authorizations.Remove(authorization);
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

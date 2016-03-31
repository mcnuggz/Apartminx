using Apartment.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Apartment.Controllers
{
    [Authorize(Roles ="Admin, Landlord")]
    public class TenantInformationController : Controller
    {
        private ApartmentContext db = new ApartmentContext();

        // GET: TenantInformation
        public ActionResult Index()
        {
            return View(db.TenantInformations.ToList());
        }

        // GET: TenantInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TenantInformation tenantInformation = db.TenantInformations.Find(id);
            if (tenantInformation == null)
            {
                return HttpNotFound();
            }
            return View(tenantInformation);
        }

        // GET: TenantInformation/Create
        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }

        // POST: TenantInformation/Create
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,MiddleName,LastName,StreetAddress,DriversLicense,State,GovtIDCard,SocialSecurity,BirthDate,Height,Weight,Gender,EyeColor,MartialStatus,IsCitizen,DoesSmoke,HasPet,PetDescription,CurrentAddress,CurrentCity,CurrentState,CurrentZip,PhoneNumber,Email,RentCurrentAddress,ApartmentName,AptManagerName,AptManagerPhone,CurrentRent,MovedInDate,MoveOutReason,PreviousAddress,PreviousCity,PreviousState,PreviousZip,RentPrevious,PreviousAptName,PreviousAptManager,PreviousAptPhone,PreviousRent,DateMovedIn,DateMovedOut")] TenantInformation tenantInformation)
        {
            if (ModelState.IsValid)
            {
                db.TenantInformations.Add(tenantInformation);
                db.SaveChanges();
                return RedirectToAction("Create", "WorkHistory");
            }

            return View(tenantInformation);
        }

        // GET: TenantInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TenantInformation tenantInformation = db.TenantInformations.Find(id);
            if (tenantInformation == null)
            {
                return HttpNotFound();
            }
            return View(tenantInformation);
        }

        // POST: TenantInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,MiddleName,LastName,StreetAddress,DriversLicense,State,GovtIDCard,SocialSecurity,BirthDate,Height,Weight,Gender,EyeColor,MartialStatus,IsCitizen,DoesSmoke,HasPet,PetDescription,CurrentAddress,CurrentCity,CurrentState,CurrentZip,PhoneNumber,Email,RentCurrentAddress,ApartmentName,AptManagerName,AptManagerPhone,CurrentRent,MovedInDate,MoveOutReason,PreviousAddress,PreviousCity,PreviousState,PreviousZip,RentPrevious,PreviousAptName,PreviousAptManager,PreviousAptPhone,PreviousRent,DateMovedIn,DateMovedOut")] TenantInformation tenantInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tenantInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tenantInformation);
        }

        // GET: TenantInformation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TenantInformation tenantInformation = db.TenantInformations.Find(id);
            if (tenantInformation == null)
            {
                return HttpNotFound();
            }
            return View(tenantInformation);
        }

        // POST: TenantInformation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TenantInformation tenantInformation = db.TenantInformations.Find(id);
            db.TenantInformations.Remove(tenantInformation);
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

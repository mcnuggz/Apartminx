using Apartment.Models;
using Apartment.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Apartment.Controllers
{
    public class AddressesController : Controller
    {
        private ApartmentContext db = new ApartmentContext();

        // GET: Addresses
        [Authorize(Roles = "Admin, Landlord")]
        public ActionResult Index()
        {
            var addresses = db.Addresses.Include(a => a.BathCount).Include(a => a.City).Include(a => a.PostalCode).Include(a => a.RentCost).Include(a => a.RoomCount).Include(a => a.Section).Include(a => a.Street).Include(a => a.UnitNumber);
            return View(addresses.ToList());
        }

        // GET: Addresses/Details/5
        [Authorize(Roles = "Admin, Landlord")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResidentApartmentViewModel viewModel = new ResidentApartmentViewModel
            {
                ApartmentAddress = db.Addresses.Find(id),
                Resident = db.Residents.Select(x => x).Where(y => y.AddressId == id).FirstOrDefault()
            };
            if (viewModel == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        // GET: Addresses/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.BathCountId = new SelectList(db.BathCount, "Id", "Count");
            ViewBag.CityId = new SelectList(db.City, "Id", "Name");
            ViewBag.PostalCodeId = new SelectList(db.ZipCodes, "Id", "Zip");
            ViewBag.RentCostId = new SelectList(db.Costs, "Id", "RentAmount");
            ViewBag.RoomCountId = new SelectList(db.RoomCounts, "Id", "Count");
            ViewBag.SectionId = new SelectList(db.Sections, "Id", "Number");
            ViewBag.StreetId = new SelectList(db.Streets, "Id", "Name");
            ViewBag.UnitNumberId = new SelectList(db.Units, "Id", "Unit");
            ViewBag.Availability = true;
            return View();
        }

        // POST: Addresses/Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SectionId,StreetId,UnitNumberId,CityId,State,PostalCodeId,RoomCountId,BathCountId,RentCostId,Availability,ResidentId")] ApartmentAddress address)
        {
            if (ModelState.IsValid)
            {
                db.Addresses.Add(address);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            ViewBag.BathCountId = new SelectList(db.BathCount, "Id", "Id", address.BathCount.Count);
            ViewBag.CityId = new SelectList(db.City, "Id", "Name", address.CityId);
            ViewBag.PostalCodeId = new SelectList(db.ZipCodes, "Id", "Zip", address.PostalCodeId);
            ViewBag.RentCostId = new SelectList(db.Costs, "Id", "Id", address.RentCostId);
            ViewBag.RoomCountId = new SelectList(db.RoomCounts, "Id", "Id", address.RoomCountId);
            ViewBag.SectionId = new SelectList(db.Sections, "Id", "Id", address.SectionId);
            ViewBag.StreetId = new SelectList(db.Streets, "Id", "Name", address.StreetId);
            ViewBag.UnitNumberId = new SelectList(db.Units, "Id", "Unit", address.UnitNumberId);
            ViewBag.ResidentId = new SelectList(db.Residents, "Id", "ResidentId", address.ResidentId);
            return View(address);
        }

        // GET: Addresses/Edit/5
        [Authorize(Roles = "Admin, Landlord")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //List<Resident> res = db.Residents.Select(x => x).ToList();
            ResidentApartmentViewModel viewModel = new ResidentApartmentViewModel
            {
                ApartmentAddress = db.Addresses.Find(id),
                Resident = db.Residents.Select(x => x).Where(y => y.AddressId == id).FirstOrDefault()
            };
            if (viewModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.BathCountId = new SelectList(db.BathCount, "Id", "Count");
            ViewBag.CityId = new SelectList(db.City, "Id", "Name");
            ViewBag.PostalCodeId = new SelectList(db.ZipCodes, "Id", "Zip");
            ViewBag.RentCostId = new SelectList(db.Costs, "Id", "RentAmount");
            ViewBag.RoomCountId = new SelectList(db.RoomCounts, "Id", "Count");
            ViewBag.SectionId = new SelectList(db.Sections, "Id", "Number");
            ViewBag.StreetId = new SelectList(db.Streets, "Id", "Name");
            ViewBag.UnitNumberId = new SelectList(db.Units, "Id", "Unit");
            ViewBag.ResidentId = new SelectList(db.Residents, "Id", "Name");
            return View(viewModel);
        }

        // POST: Addresses/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Landlord")]
        public ActionResult Edit([Bind(Include = "Id, ApartmentAddress, Resident")] ResidentApartmentViewModel residentAddress)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(residentAddress).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Addresses");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            ViewBag.BathCountId = new SelectList(db.BathCount, "Id", "Id", residentAddress.ApartmentAddress.BathCountId);
            ViewBag.CityId = new SelectList(db.City, "Id", "Name", residentAddress.ApartmentAddress.CityId);
            ViewBag.PostalCodeId = new SelectList(db.ZipCodes, "Id", "Zip", residentAddress.ApartmentAddress.PostalCodeId);
            ViewBag.RentCostId = new SelectList(db.Costs, "Id", "Id", residentAddress.ApartmentAddress.RentCostId);
            ViewBag.RoomCountId = new SelectList(db.RoomCounts, "Id", "Id", residentAddress.ApartmentAddress.RoomCountId);
            ViewBag.SectionId = new SelectList(db.Sections, "Id", "Id", residentAddress.ApartmentAddress.SectionId);
            ViewBag.StreetId = new SelectList(db.Streets, "Id", "Name", residentAddress.ApartmentAddress.StreetId);
            ViewBag.UnitNumberId = new SelectList(db.Units, "Id", "Unit", residentAddress.ApartmentAddress.UnitNumberId);
            ViewBag.ResidentId = new SelectList(db.Residents, "Id", "Name", residentAddress.Resident.Name);
            return View(residentAddress);
        }

        // GET: Addresses/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResidentApartmentViewModel viewModel = new ResidentApartmentViewModel
            {
                ApartmentAddress = db.Addresses.Find(id),
                Resident = db.Residents.Select(x => x).Where(y => y.AddressId == id).FirstOrDefault()
            };
            if (viewModel == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ApartmentAddress address = db.Addresses.Find(id);
            db.Addresses.Remove(address);
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

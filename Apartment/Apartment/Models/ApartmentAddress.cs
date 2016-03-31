using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Apartment.Models
{
    public class ApartmentAddress
    {
        public int Id { get; set; }
        [Display(Name = "Building #: "), Required]
        public int SectionId { get; set; }
        [Display(Name ="Street Name: "), Required]
        public int StreetId { get; set; }
        [Display(Name ="Unit #: "), Required]
        public int UnitNumberId { get; set; }
        [Display(Name = "Address:")]
        public string FullAddress
        {
            get
            {
                return Section.Number.ToString() + " " + Street.Name + " " + UnitNumber.Unit;
            }
        }
        [Display(Name ="City: "), Required]
        public int CityId { get; set; }
        [Display(Name ="State: "), Required]
        public States State { get; set; }
        [Display(Name ="Postal/Zip Code: "), DataType(DataType.PostalCode), Required]
        public int PostalCodeId { get; set; }
        [Display(Name ="Number of Rooms:")]
        public int RoomCountId { get; set; }
        [Display(Name ="Number of Baths:")]
        public int BathCountId { get; set; }
        [Display(Name ="Rent:")]
        public int? RentCostId { get; set; }
        [Display(Name ="Available?")]
        public bool Availability { get; set; }

        [Display(Name ="Resident:")]
        public int ResidentId { get; set; }
        public virtual ICollection<Resident> Residents { get; set; }

        public virtual Section Section { get; set; }
        public virtual UnitNumber UnitNumber { get; set; }
        public virtual Street Street { get; set; }
        public virtual City City { get; set; }
        public virtual PostalCode PostalCode { get; set; }
        public virtual RoomCount RoomCount { get; set; }
        public virtual BathCount BathCount { get; set; }
        public virtual RentCost RentCost { get; set; }

    }
}
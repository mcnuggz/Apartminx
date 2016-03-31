using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Apartment.Models
{
    public class TenantInformation
    {
        public int Id { get; set; }
        [Display(Name ="First Name:")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name:")]
        public string MiddleName { get; set; }
        [Display(Name = "Last Name:")]
        public string LastName { get; set; }
        [Display(Name = "Street Address:")]
        public string StreetAddress { get; set; }
        [Display(Name = "Driver's License #:")]
        public string DriversLicense { get; set; }
        [Display(Name ="State:")]
        public States State { get; set; }
        [Display(Name = "Govt. Photo ID Card #:")]
        public string GovtIDCard { get; set; }
        [Display(Name = "Social Security #:")]
        public string SocialSecurity { get; set; }
        [Display(Name ="Birthdate:")]
        public string BirthDate { get; set; }
        [Display(Name = "Phone Number:"), DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [DataType(DataType.EmailAddress), Display(Name = "Email: ")]
        public string Email { get; set; }
        [Display(Name = "Height: ")]
        public string Height { get; set; }
        [Display(Name = "Weight:")]
        public int? Weight { get; set; }
        [Display(Name ="Gender:")]
        public Genders Gender { get; set; }
        [Display(Name = "Eye Color:")]
        public string EyeColor { get; set; }
        [Display(Name = "Martial Status:"), ]
        public MStatus MartialStatus { get; set; }
        [Display(Name = "Are you a U.S. citizen?"), ]
        public bool IsCitizen { get; set; }
        [Display(Name = "Do you or any occupant smoke?")]
        public bool DoesSmoke { get; set; }
        [Display(Name ="Will you or any occupant have an animal?")]
        public bool HasPet { get; set; }
        [Display(Name ="Kind, weight, breed, age:")]
        public string PetDescription { get; set; }

        [Display(Name ="Current Home Address:")]
        public string CurrentAddress { get; set; }
        [Display(Name ="City:")]
        public string CurrentCity { get; set; }
        [Display(Name ="State:")]
        public States CurrentState { get; set; }
        [Display(Name ="Zip Code:"), DataType(DataType.PostalCode)]
        public string CurrentZip { get; set; }
        [Display(Name ="Do you rent your current address?")]
        public bool RentCurrentAddress { get; set; }
        [Display(Name ="Apartment Name:")]
        public string ApartmentName { get; set; }
        [Display(Name ="Current Apartment Manager's Name:")]
        public string AptManagerName { get; set; }
        [Display(Name ="Manager's Phone Number:"), DataType(DataType.PhoneNumber)]
        public string AptManagerPhone { get; set; }
        [Display(Name ="Current Rent Amount:")]
        public decimal? CurrentRent { get; set; }
        [Display(Name ="Date Moved In:")]
        public string MovedInDate { get; set; }
        [Display(Name ="Reason for Moving Out:")]
        public string MoveOutReason { get; set; }

        [Display(Name ="Previous Address:")]
        public string PreviousAddress { get; set; }
        [Display(Name = "City:")]
        public string PreviousCity { get; set; }
        [Display(Name = "State:")]
        public States PreviousState { get; set; }
        [Display(Name ="Zip Code:"), DataType(DataType.PostalCode)]
        public string PreviousZip { get; set; }
        [Display(Name = "Do you rent at your previous address?")]
        public bool RentPrevious { get; set; }
        [Display(Name ="Apartment Name:")]
        public string PreviousAptName { get; set; }
        [Display(Name = "Previous Apartment Manager's Name:")]
        public string PreviousAptManager { get; set; }
        [Display(Name = "Manager's Phone Number:"), DataType(DataType.PhoneNumber)]
        public string PreviousAptPhone { get; set; }
        [Display(Name ="Previous Monthly Rent:")]
        public decimal? PreviousRent { get; set; }
        [Display(Name ="Date Moved In:")]
        public string DateMovedIn { get; set; }
        [Display(Name ="Date Moved Out:")]
        public string DateMovedOut { get; set; }

        public enum MStatus
        {
            Single,
            Married,
            Divorced,
            Widowed,
            Separated
        }

    }
}
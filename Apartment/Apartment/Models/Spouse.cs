using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Apartment.Models
{
    public class Spouse
    {
        public int Id { get; set; }
        [Display(Name ="Do you have a spouse?")]
        public bool IsMarried { get; set; }
        [Display(Name ="First Name:")]
        public string FirstName { get; set; }
        [Display(Name ="Middle Name:")]
        public string MiddleName { get; set; }
        [Display(Name ="Last Name:")]
        public string LastName { get; set; }
        [Display(Name ="Maiden Name:")]
        public string FormerNames { get; set; }
        [Display(Name ="Spouse's Social Security #:")]
        public string SpouseSecurity { get; set; }
        [Display(Name ="Driver's License #:")]
        public string SpouseDriverLicense { get; set; }
        public States State { get; set; }
        [Display(Name ="Govt Photo ID card #:")]
        public string GovtId { get; set; }
        [Display(Name ="Birthdate:")]
        public string Birthdate { get; set; }
        [Display(Name ="Height:")]
        public int? Height { get; set; }
        [Display(Name ="Weight:")]
        public int? Weight { get; set; }
        [Display(Name ="Gender:")]
        public Genders Gender { get; set; }
        [Display(Name ="Eye color:")]
        public string EyeColor { get; set; }
        [Display(Name ="Is spouse a U.S. Citizen?")]
        public bool USCitizen { get; set; }

        [Display(Name ="Is spouse presently employed?")]
        public bool SpouseEmployed { get; set; }
        [Display(Name ="Present Employer:")]
        public string Employer { get; set; }
        [Display(Name ="Work Address:")]
        public string Address { get; set; }
        [Display(Name ="City:")]
        public string City { get; set; }
        [Display(Name ="State:")]
        public States WorkState { get; set; }
        [DataType(DataType.PostalCode), Display(Name ="Zip Code:")]
        public string Zip { get; set; }
        [DataType(DataType.PhoneNumber), Display(Name ="Work Phone:")]
        public string WorkPhone { get; set; }
        [Display(Name ="Position:")]
        public string Position { get; set; }
        [Display(Name ="Start Date")]
        public string StartDate { get; set; }
        [Display(Name ="Gross Income")]
        public decimal? GrossIncome { get; set; }
        [Display(Name ="Supervisor's Name")]
        public string SupervisorName { get; set; }
        [DataType(DataType.PhoneNumber), Display(Name ="Phone")]
        public string SupervisorPhone { get; set; }
    }
}
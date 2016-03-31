using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Apartment.Models
{
    public class Vehicles
    {
        public int Id { get; set; }

        [Display(Name ="Make and color of vehicle:")]
        public string VehilceDescription { get; set; }
        [Display(Name ="Year:")]
        public int? Year { get; set; }
        [Display(Name ="License #:")]
        public string LicenseNum { get; set; }
        [Display(Name ="State:")]
        public States State { get; set; }


        [Display(Name = "Make and color of vehicle:")]
        public string VehilceDescription2 { get; set; }
        [Display(Name = "Year:")]
        public int? Year2 { get; set; }
        [Display(Name = "License #:")]
        public string LicenseNum2 { get; set; }
        [Display(Name = "State:")]
        public States State2 { get; set; }


        [Display(Name = "Make and color of vehicle:")]
        public string VehilceDescription3 { get; set; }
        [Display(Name = "Year:")]
        public int? Year3 { get; set; }
        [Display(Name = "License #:")]
        public string LicenseNum3 { get; set; }
        [Display(Name = "State:")]
        public States State3 { get; set; }
    }
}
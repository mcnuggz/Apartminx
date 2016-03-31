using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Apartment.Models
{
    public class OtherOccupants
    {
        public int Id { get; set; }
        [Display(Name="Name:")]
        public string Name { get; set; }
        [Display(Name="Relationship:")]
        public string Relationship { get; set; }
        [Display(Name="Gender:")]
        public Genders Gender { get; set; }
        [Display(Name="Birthdate:")]
        public string Birthdate { get; set; }
        [Display(Name="DL or Govt ID card #:")]
        public string IDNum { get; set; }
        [Display(Name="State:")]
        public States State { get; set; }

        [Display(Name = "Name:")]
        public string Name2 { get; set; }
        [Display(Name = "Relationship:")]
        public string Relationship2 { get; set; }
        [Display(Name = "Gender:")]
        public Genders Gender2 { get; set; }
        [Display(Name = "Birthdate:")]
        public string Birthdate2 { get; set; }
        [Display(Name = "DL or Govt ID card #:")]
        public string IDNum2 { get; set; }
        [Display(Name = "State:")]
        public States State2 { get; set; }

        [Display(Name = "Name:")]
        public string Name3 { get; set; }
        [Display(Name = "Relationship:")]
        public string Relationship3 { get; set; }
        [Display(Name = "Gender:")]
        public Genders Gender3 { get; set; }
        [Display(Name = "Birthdate:")]
        public string Birthdate3 { get; set; }
        [Display(Name = "DL or Govt ID card #:")]
        public string IDNum3 { get; set; }
        [Display(Name = "State:")]
        public States State3 { get; set; }
    }
}
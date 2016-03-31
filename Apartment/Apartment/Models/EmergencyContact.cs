using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Apartment.Models
{
    public class EmergencyContact
    {
        public int Id { get; set; }

        [Display(Name="Name:"), Required]
        public string Name { get; set; }
        [Display(Name="Relationship:"), Required]
        public string Relationship { get; set; }
        [Display(Name="Phone"), Required]
        public string Phone { get; set; }

        [Display(Name = "Name:")]
        public string Name2 { get; set; }
        [Display(Name = "Relationship:")]
        public string Relationship2 { get; set; }
        [Display(Name = "Phone")]
        public string Phone2 { get; set; }

        [Display(Name = "Name:")]
        public string Name3 { get; set; }
        [Display(Name = "Relationship:")]
        public string Relationship3 { get; set; }
        [Display(Name = "Phone")]
        public string Phone3 { get; set; }
    }
}
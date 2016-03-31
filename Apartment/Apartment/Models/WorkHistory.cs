using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Apartment.Models
{
    public class WorkHistory
    {
        public int Id { get; set; }
        [Display(Name ="Are you currently employed?")]
        public bool PresentlyEmployed { get; set; }
        [Display(Name ="Present Employer:")]
        public string Employer { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public States State { get; set; }
        [DataType(DataType.PostalCode), Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
        [Display(Name ="Work Phone:"), DataType(DataType.PhoneNumber)]
        public string WorkPhone { get; set; }
        public string Position { get; set; }
        [Display(Name ="Gross Annual Income:")]
        public decimal? GrossIncome { get; set; }
        [Display(Name ="Date Started:")]
        public string BeginDate { get; set; }
        [Display(Name ="Supervisor's Name:")]
        public string SupervisorName { get; set; }
        [Display(Name ="Phone:"), DataType(DataType.PhoneNumber)]
        public string SupervisorNumber { get; set; }

        [Display(Name ="Were you previously employed?")]
        public bool PreviouslyEmployed { get; set; }
        [Display(Name ="Previous Employer:")]
        public string PreviousEmployer { get; set; }
        [Display(Name ="Address:")]
        public string PrevAddress { get; set; }
        [Display(Name ="City:")]
        public string PrevCity { get; set; }
        [Display(Name ="State:")]
        public States PrevState { get; set; }
        [Display(Name ="Zip:"), DataType(DataType.PostalCode)]
        public string PrevZip { get; set; }
        [Display(Name ="Work Phone:"), DataType(DataType.PhoneNumber)]
        public string PrevWorkPhone { get; set; }
        [Display(Name ="Position:")]
        public string PrevPosition { get; set; }
        [Display(Name ="Gross Annual Income:")]
        public decimal? PrevIncome { get; set; }
        [Display(Name ="Start Date:")]
        public string PrevStartDate { get; set; }
        [Display(Name ="End Date:")]
        public string PrevEndDate { get; set; }
        [Display(Name ="Previous Supervisor's Name:")]
        public string PrevSupervisor { get; set; }
        [Display(Name ="Phone:"), DataType(DataType.PhoneNumber)]
        public string PrevPhoneNumber { get; set; }
    }
}
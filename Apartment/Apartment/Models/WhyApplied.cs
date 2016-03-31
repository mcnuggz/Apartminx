using System.ComponentModel.DataAnnotations;

namespace Apartment.Models
{
    public class WhyApplied
    {
        public int Id { get; set; }
        [Display(Name ="Were you referred?")]
        public bool WasReferred { get; set; }
        [Display(Name ="Name of National Rental Agency:")]
        public string RentalAgency { get; set; }
        [Display(Name ="Name of Local Rental Agency:")]
        public string LocalAgency { get; set; }
        [Display(Name ="Who did you hear about us from?")]
        public string OtherPerson { get; set; }

        [Display(Name ="Not Referred: ")]
        public bool NoReferral { get; set; }
        [Display(Name ="Did you find us on the Internet?")]
        public bool OnInternet { get; set; }
        [Display(Name ="Did you stop in and visit us?")]
        public bool StoppedBy { get; set; }
        [Display(Name ="Did you find our ad in the newspaper?")]
        public bool Newspaper { get; set; }
        public string NewspaperName { get; set; }
        [Display(Name ="Did you find us in a rental publication?")]
        public bool RentalPublication { get; set; }
        public string PublicaitonName { get; set; }
        [Display(Name ="If none of the above, how did you find us?")]
        public string OtherDetails { get; set; }


    }
}
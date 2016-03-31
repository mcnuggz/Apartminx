using System.ComponentModel.DataAnnotations;

namespace Apartment.Models
{
    public class CreditHistory
    {
        public int Id { get; set; }
        [Display(Name ="Bank Name:")]
        public string BankName { get; set; }
        [Display(Name ="City:")]
        public string City { get; set; }
        [Display(Name = "State:")]
        public States State { get; set; }
        [Display(Name ="Social Security #:")]
        public string SocialSecurity { get; set; }
        [Display(Name ="Other Comments:")]
        public string OtherComments { get; set; }
    }
}
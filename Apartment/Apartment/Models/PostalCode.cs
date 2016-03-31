using System.ComponentModel.DataAnnotations;

namespace Apartment.Models
{
    public class PostalCode
    {
        public int Id { get; set; }
        [Display(Name ="Postal/Zip Code:")]
        public string Zip { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace Apartment.Models
{
    public class UnitNumber
    {
        public int Id { get; set; }
        [Display(Name ="Unit Number:")]
        public string Unit { get; set; }
    }
}
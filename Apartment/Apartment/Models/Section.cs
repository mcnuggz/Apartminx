using System.ComponentModel.DataAnnotations;

namespace Apartment.Models
{
    public class Section
    {
        public int Id { get; set; }
        [Display(Name ="Building Number:")]
        public int Number { get; set; }
    }
}
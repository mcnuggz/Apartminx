using System.ComponentModel.DataAnnotations;

namespace Apartment.Models
{
    public class Street
    {
        public int Id { get; set; }
        [Display(Name ="Street Name:")]
        public string Name { get; set; }
    }
}
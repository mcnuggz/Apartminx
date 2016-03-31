using System.ComponentModel.DataAnnotations;

namespace Apartment.Models
{
    public class City
    {
        public int Id { get; set; }
        [Display(Name="Name:")]
        public string Name { get; set; }
    }
}
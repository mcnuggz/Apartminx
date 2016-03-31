using System.ComponentModel.DataAnnotations;

namespace Apartment.Models
{
    public enum Cards
    {
        Visa,
        MasterCard,
        Discover,
        [Display(Name ="American Express")]
        AmericanExpress
    }
}
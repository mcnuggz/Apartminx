using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Apartment.Models
{
    public class Resident
    {
        public int Id { get; set; }
        [Display(Name ="First Name: "), Required]
        public string FirstName { get; set; }
        [Display(Name ="Last Name: "), Required]
        public string LastName { get; set; }
        [Display(Name ="Name:")]
        public string Name {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        [Display(Name ="Phone Number: "), DataType(DataType.PhoneNumber), Required]
        public string PhoneNumber { get; set; }
        [Display(Name ="Email: "), DataType(DataType.EmailAddress), Required]
        public string Email { get; set; }
        [Display(Name = "Have Pets?")]
        public bool HasPets { get; set; }
        [Display(Name ="If yes, how many?")]
        public int? petCount { get; set; }

        public int? AddressId { get; set; }
        public int? PetCostId { get; set; }
        public virtual ICollection<ApartmentAddress> Addresses { get; set; }
        public virtual PetCost PetCost { get; set;}

    }
}